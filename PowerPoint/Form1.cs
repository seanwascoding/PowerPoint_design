﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Collections;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        const string DELETE = "Delete";
        const string LINE = "Line";
        const string CIRCLE = "Circle";
        const string LEFT = "(";
        const string RIGHT = ")";
        const string COMMA = ",";
        const string TAB = " ";
        const string ERROR = "Select Item First";
        const string RECTANGLE = "Rectangle";
        const string CLICK = "user click position:";
        const string WORKING = "work to delete";
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;
        const int SIZE_THREE = 3;
        const int SIZE_FIVE = 5;
        const int SIZE_SEVEN = 7;
        const int SIZE_TEN = 10;
        const double SIZE_SIXTEEN = 16.0;
        const double SIZE_NINE = 9.0;
        FormPresentationModel _presentationModel;
        Model _model;
        Button _selectButton;
        List<Button> _allButtons;
        private string _uploadFileName;
        private string _downloadPath;
        GoogleDriveService _service;
        ListBox _fileListBox;
        List<Google.Apis.Drive.v2.Data.File> rootFoldersFiles;

        public Form1(FormPresentationModel presentationModel)
        {
            InitializeComponent();
            //
            _model = presentationModel.GetModel();
            _presentationModel = presentationModel;
            _fileListBox = new ListBox();
            rootFoldersFiles = new List<Google.Apis.Drive.v2.Data.File>();

            //
            _shapeGridView.CellClick += DeleteInstance;
            _shapeGridView.KeyDown += DetectKey;

            //
            _canvas.BackColor = Color.White;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;

            //
            _allButtons = new List<Button>();
            _allButtons.Add(_show);
            _show.BackColor = Color.White;
            _show.FlatStyle = FlatStyle.Flat;
            _show.FlatAppearance.BorderSize = SIZE_TWO;
            _show.FlatAppearance.BorderColor = Color.Red;
            _show.BackgroundImageLayout = ImageLayout.Stretch;
            _show.Padding = new Padding(10);
            _show.Click += UpdateSelectButton;
            _selectButton = _show;

            // _modelChanged
            _model._modelChanged += HandleModelChanged;

            // databinding
            _presentationModel.PropertyChanged += (sender, args) =>
            {
                _lineButton.Checked = _presentationModel.GetLineState;
                _rectangleButton.Checked = _presentationModel.GetRectangleState;
                _circleButton.Checked = _presentationModel.GetCircleState;
                _cursorButton.Checked = _presentationModel.GetCursorState;
                _load.Enabled = _presentationModel.GetLoadState;
                _save.Enabled = _presentationModel.GetSaveState;
            };

            //
            _splitContainer1.Paint += SplitContainerPaint;
            _splitContainer2.Paint += SplitContainerPaint;

            _splitContainer1.SplitterMoved += SplitContainerMoving;
            _splitContainer2.SplitterMoved += SplitContainerMoving;

            //
            const string APPLICATION_NAME = "DrawAnywhere";
            const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);

            _save.Enabled = false;
            _load.Enabled = false;
            _cursorButton.Checked = true;
        }

        // SplitContainer_Paint
        private void SplitContainerPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            System.Drawing.Rectangle rectangle = ((SplitContainer)sender).SplitterRectangle;
            using (SolidBrush brush = new SolidBrush(Color.Gray))
            {
                graphics.FillRectangle(brush, rectangle);
            }
        }

        // SplitContainer_SplitterMoving
        private void SplitContainerMoving(object sender, EventArgs e)
        {
            int desiredHeight = (int)((_splitContainer2.Panel1.Width / SIZE_SIXTEEN) * SIZE_NINE);
            int desiredHeight1 = (int)((_splitContainer1.Panel1.Width / SIZE_SIXTEEN) * SIZE_NINE);
            AdjustAllCanvasShapeSize(desiredHeight);
            AdjustControlSize(_canvas, _splitContainer2.Panel1.Width, desiredHeight);
            AdjustCanvasSize(desiredHeight1);
            AdjustControlSize(_shapeGridView, _splitContainer2.Panel2.Width - SIZE_SEVEN, _shapeGridView.Height);
            HandleModelChanged();
        }

        // AdjustControlSize
        private void AdjustControlSize(Control control, int width, int height)
        {
            control.Width = width;
            control.Height = height;
        }

        // AdjustShapeSize
        private void AdjustShapeSize(int resize, Button button)
        {
            List<Shape> shapes = _presentationModel.GetCompound();
            float times = (float)resize / _canvas.Height;
            foreach (Shape shape in shapes)
            {
                shape._x1 = (int)(shape._x1 * times);
                shape._y1 = (int)(shape._y1 * times);
                shape._x2 = (int)(shape._x2 * times);
                shape._y2 = (int)(shape._y2 * times);
                if (button == _selectButton)
                    Refresh(shape, shapes.IndexOf(shape));
            }
        }

        // AdjustCanvasSize
        private void AdjustCanvasSize(int resize)
        {
            foreach (Button button in _allButtons)
            {
                AdjustControlSize(button, _splitContainer1.Panel1.Width, resize);
                if (_allButtons.IndexOf(button) > 0)
                    button.Location = new Point(_allButtons[_allButtons.IndexOf(button) - 1].Location.X, _allButtons[_allButtons.IndexOf(button) - 1].Bottom + 10);
            }
        }

        // AdjustAllCanvasShapeSize
        private void AdjustAllCanvasShapeSize(int resize)
        {
            int i = 0;
            foreach (Button button in _allButtons)
            {
                Console.WriteLine("test" + i + ":" + _allButtons.IndexOf(button));
                _presentationModel.SetCurrentCanvas(_allButtons.IndexOf(button));
                AdjustShapeSize(resize, button);
                i++;
            }
            _presentationModel.SetCurrentCanvas(_allButtons.IndexOf(_selectButton));
        }

        // Create Cells
        private DataGridViewRow CreateCells(Shape shape)
        {
            //_presentationModel.AddShape(shape);
            double[] temp = shape.GetCoordinates();
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewButtonCell test = new DataGridViewButtonCell();
            test.Value = DELETE;
            test.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
            cell1.Value = shape.GetShapeName();
            cell1.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
            if (temp.Length == SIZE_TWO)
                cell2.Value = string.Concat(LEFT, temp[SIZE_ZERO], COMMA, temp[SIZE_ONE], RIGHT);
            else
                cell2.Value = string.Concat(LEFT, temp[SIZE_ZERO], COMMA, temp[SIZE_ONE], RIGHT, TAB, LEFT, temp[SIZE_TWO], COMMA, temp[SIZE_THREE], RIGHT);
            cell2.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            row.Cells.AddRange(test, cell1, cell2);
            return row;
        }

        // Refresh
        private void Refresh(Shape shape, int position)
        {
            double[] temp = shape.GetCoordinates();
            DataGridViewRow row = _shapeGridView.Rows[position];
            DataGridViewCell cell = row.Cells[SIZE_TWO];
            if (temp.Length == SIZE_TWO)
                cell.Value = string.Concat(LEFT, temp[SIZE_ZERO], COMMA, temp[SIZE_ONE], RIGHT);
            else
                cell.Value = string.Concat(LEFT, temp[SIZE_ZERO], COMMA, temp[SIZE_ONE], RIGHT, TAB, LEFT, temp[SIZE_TWO], COMMA, temp[SIZE_THREE], RIGHT);
        }

        // RefreshDataGridView
        private void RefreshDataGridView()
        {
            _shapeGridView.Rows.Clear();
            foreach (Shape shape in _presentationModel.GetCompound())
                _shapeGridView.Rows.Add(CreateCells(shape));
        }

        // UpdateCanvas
        private void UpdateCanvas()
        {
            Bitmap bitmap = new Bitmap(_canvas.Width, _canvas.Height);
            _canvas.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, _canvas.Width, _canvas.Height));
            Bitmap resizedBitmap = new Bitmap(_selectButton.Size.Width, _selectButton.Size.Height);
            using (Graphics g = Graphics.FromImage(resizedBitmap))
            {
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, resizedBitmap.Width, resizedBitmap.Height));
            }
            _selectButton.BackgroundImage = resizedBitmap;
        }

        // Add item to GridView
        private void AddButtonClick(object sender, EventArgs e)
        {
            if (_shapeComboBox.Text.ToString() == "")
            {
                MessageBox.Show(ERROR);
                return;
            }
            Form2 newForm = new Form2();
            Console.WriteLine(_canvas.Width + ":" + _canvas.Height);
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                if (newForm.GetPositionX1 < _canvas.Width && newForm.GetPositionX2 < _canvas.Width && newForm.GetPositionY1 < _canvas.Height && newForm.GetPositionY2 < _canvas.Height)
                    CreateShape(newForm.GetPositionX1, newForm.GetPositionX2, newForm.GetPositionY1, newForm.GetPositionY2);
                else
                    MessageBox.Show("out of the range");
            }
            else
                newForm.Close();
        }

        // CreateShape
        private void CreateShape(int positionx1, int positionx2, int positiony1, int positiony2)
        {
            Shape temp;
            if (_shapeComboBox.Text.ToString() == LINE)
                temp = ShapeFactory.CreateLine(positionx1, positionx2, positiony1, positiony2);
            else if (_shapeComboBox.Text.ToString() == RECTANGLE)
                temp = ShapeFactory.CreateRectangle(positionx1, positionx2, positiony1, positiony2);
            else if (_shapeComboBox.Text.ToString() == CIRCLE)
                temp = ShapeFactory.CreateCircle(positionx1, positionx2, positiony1, positiony2);
            else
            {
                MessageBox.Show(ERROR);
                return;
            }
            _presentationModel.AddShape(temp);
            _shapeGridView.Rows.Add(CreateCells(temp));
            HandleModelChanged();
        }

        // Delete the item => Destory the instance
        private void DeleteInstance(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && _shapeGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                DataGridViewRow row = _shapeGridView.Rows[e.RowIndex];
                _shapeGridView.Rows.Remove(row);
                Console.WriteLine(CLICK + e.RowIndex);
                _presentationModel.RemoveShape(e.RowIndex);
                HandleModelChanged();
                UpdateCanvas();
            }
        }

        // Clear
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
        }

        // CanvasPressed
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.ShapeReset();
            Shape temp = _model.SelectedShape(e.Location);
            if (temp != null)
            {
                _presentationModel.SetSelectShape(temp);
            }
            else
            {
                if (_presentationModel.GetCursorState)
                {
                    UpdateCanvas();
                    HandleModelChanged();
                    return;
                }
            }
            _model.PressedPointer(e.X, e.Y);
        }

        // CanvasReleased
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Console.WriteLine(_presentationModel.GetCompound().Count);
            _model.ReleasedPointer(e.X, e.Y);
            if (_presentationModel.IsSelectedState())
                Refresh(_presentationModel.GetSelectShape(), _presentationModel.GetPosition());
            else
            {
                if (_presentationModel.GetCursorState)
                    return;
                _shapeGridView.Rows.Add(CreateCells(_presentationModel.GetCompound().Last()));
            }
            Cursor = Cursors.Default;
            _presentationModel.SetChecked(SIZE_THREE);
            UpdateCanvas();
        }

        // CanvasMoved
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MovedPointer(e.X, e.Y);
            if (_presentationModel.GetSelectShape() != null)
            {
                // todo bug detect
                double[] temp = _presentationModel.GetSelectShape().GetCoordinates();
                if (Math.Abs(temp[SIZE_TWO] - e.X) <= SIZE_FIVE && Math.Abs(temp[SIZE_THREE] - e.Y) <= SIZE_FIVE)
                {
                    Cursor = Cursors.SizeNWSE;
                    _presentationModel.ShapeMoveChange(_presentationModel.GetSelectShape(), true);
                }
                else
                {
                    Cursor = Cursors.Default;
                    _presentationModel.ShapeMoveChange(_presentationModel.GetSelectShape(), false);
                }
            }
        }

        // CanvasPaint
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        // ModelChanged
        public void HandleModelChanged()
        {
            _shapeGridView.Select();
            _doAgain.Enabled = _model.IsRedoEnabled;
            _doReverse.Enabled = _model.IsUndoEnabled;
            Invalidate(true);
        }

        // line_Button_Click
        private void ClickLineButton(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
            _presentationModel.SetChecked(0);
            Console.WriteLine(SIZE_ZERO);
            _presentationModel.SetShapeState(0);
            _model.ShapeReset();
        }

        // rectangle_Button_Click
        private void ClickRectangleButton(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
            _presentationModel.SetChecked(1);
            Console.WriteLine(SIZE_ONE);
            _presentationModel.SetShapeState(1);
            _model.ShapeReset();
        }

        // circle_Button_Click
        private void ClickCircleButton(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
            _presentationModel.SetChecked(SIZE_TWO);
            Console.WriteLine(SIZE_TWO);
            _presentationModel.SetShapeState(SIZE_TWO);
            _model.ShapeReset();
        }

        // cursor_Click
        private void ClickCursor(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            _presentationModel.SetChecked(SIZE_THREE);
            _model.ShapeReset();
        }

        // KeyDown
        private void DetectKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (_presentationModel.GetSelectShape() != null)
                    DeleteSelectedShape();
                else if (_allButtons.Count > SIZE_ONE)
                    RefrashButtonPosition();
                else
                {
                    MessageBox.Show("only one page");
                    return;
                }
                HandleModelChanged();
                UpdateCanvas();
            }
        }

        // RefrashButtonPosition
        private void RefrashButtonPosition()
        {
            int position = _allButtons.IndexOf(_selectButton);
            _splitContainer1.Panel1.Controls.Remove(_selectButton);
            _presentationModel.DeleteCanvas(position);
            _allButtons.RemoveAt(position);
            if (position - SIZE_ONE < 0)
                _selectButton = _allButtons[position];
            else
                _selectButton = _allButtons[position - SIZE_ONE];
            _selectButton.PerformClick();
            RefrashCanvasPosition();
        }

        // DeleteSelectedShape
        private void DeleteSelectedShape()
        {
            Console.WriteLine(WORKING);
            int temp = _presentationModel.GetPosition();
            _presentationModel.RemoveShape(temp);
            DataGridViewRow row = _shapeGridView.Rows[temp];
            _shapeGridView.Rows.Remove(row);
            _model.ShapeReset();
        }

        // RefrashCanvasPosition
        private void RefrashCanvasPosition()
        {
            foreach (Button button in _allButtons)
            {
                if (_allButtons.IndexOf(button) == 0)
                {
                    button.Location = new Point(0, 0);
                    continue;
                }
                button.Location = new Point(_allButtons[_allButtons.IndexOf(button) - 1].Location.X, _allButtons[_allButtons.IndexOf(button) - 1].Bottom + 10);
            }
        }

        // UndoHandler
        private void UndoHandler(object sender, EventArgs e)
        {
            _model.Undo();
            RefreshDataGridView();
            HandleModelChanged();
            UpdateCanvas();
        }

        // RedoHandler
        private void RedoHandler(object sender, EventArgs e)
        {
            _model.Redo();
            RefreshDataGridView();
            HandleModelChanged();
            UpdateCanvas();
        }

        // AddCanvasClick
        private void AddCanvasClick(object sender, EventArgs e)
        {
            Button button = new Button();
            button.Location = new Point(_allButtons[_allButtons.Count() - 1].Location.X, _allButtons[_allButtons.Count() - 1].Bottom + SIZE_TEN);
            button.Size = new Size(_selectButton.Width, _selectButton.Height);
            button.BackColor = Color.White;
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.Padding = new Padding(10);
            button.Click += UpdateSelectButton;
            button.Visible = true;
            _splitContainer1.Panel1.Controls.Add(button);
            _allButtons.Add(button);
            _presentationModel.CreateCanvas();
            button.PerformClick();
        }

        // UpdateSelectButton
        private void UpdateSelectButton(object sender, EventArgs e)
        {
            TurnOffButtons();
            _selectButton = (Button)sender;
            _selectButton.FlatStyle = FlatStyle.Flat;
            _selectButton.FlatAppearance.BorderSize = SIZE_TWO;
            _selectButton.FlatAppearance.BorderColor = Color.Red;
            _presentationModel.SetCurrentCanvas(_allButtons.IndexOf(_selectButton));
            RefreshDataGridView();
            HandleModelChanged();
            UpdateCanvas();
        }

        // TurnOffButton
        private void TurnOffButtons()
        {
            foreach (Button button in _allButtons)
                button.FlatAppearance.BorderColor = Color.White;
        }

        // ClickSave
        private async void ClickSave(object sender, EventArgs e)
        {
            Save save = new Save();
            //
            _presentationModel.ProcessData();
            //
            if (save.ShowDialog() == DialogResult.OK)
            {
                _presentationModel.SetSaveState(false);
                try
                {
                    _uploadFileName = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "..\\..\\sample\\shapes.json");
                    const string CONTENT_TYPE = "application/json";
                    int temp = ClickListFileOnRootButton();
                    if (temp != -1)
                        _ = await _service.UpdateFile(_uploadFileName, rootFoldersFiles[temp].Id, CONTENT_TYPE);
                    else
                        _ = await _service.UploadFile(_uploadFileName, CONTENT_TYPE);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _presentationModel.SetLoadState(true);
            }
        }

        // ClickLoad
        private void ClickLoad(object sender, EventArgs e)
        {
            Load load = new Load();
            if (load.ShowDialog() == DialogResult.OK)
            {
                _downloadPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "..\\..\\sample\\");
                int temp = ClickListFileOnRootButton();
                if (temp == -1)
                {
                    MessageBox.Show("not exist");
                    _presentationModel.SetLoadState(false);
                    return;
                }
                Google.Apis.Drive.v2.Data.File selectedFile = rootFoldersFiles[temp];
                _service.DownloadFile(selectedFile, _downloadPath);
                _presentationModel.UpdateModel();
                _presentationModel.SetLoadState(false);

                _allButtons.Clear();
                _splitContainer1.Panel1.Controls.Clear();
                for (int i = 0; i < _presentationModel.GetPageSize(); i++)
                {
                    LoadCanvas(i);
                    if (i == 0)
                    {
                        _selectButton = _allButtons[0];
                        _selectButton.PerformClick();
                    }
                }
                RefrashCanvasPosition();
                RefreshDataGridView();
                UpdateCanvas();
            }
        }

        // ClickListFileOnRootButton
        private int ClickListFileOnRootButton()
        {
            const string FOLDER_MIME_TYPE = @"application/vnd.google-apps.folder";
            rootFoldersFiles = _service.ListRootFileAndFolder();
            rootFoldersFiles.RemoveAll(removeItem =>
            {
                return removeItem.MimeType == FOLDER_MIME_TYPE;
            });
            int indexOfSampleTxt = rootFoldersFiles.FindIndex(file => file.Title == "shapes.json");
            return indexOfSampleTxt;
        }

        private void LoadCanvas(int count)
        {
            Button button = new Button();
            if (count == 0)
                button.Location = new Point(0, 0);
            else
                button.Location = new Point(_allButtons[_allButtons.Count() - 1].Location.X, _allButtons[_allButtons.Count() - 1].Bottom + SIZE_TEN);
            button.Size = new Size(_show.Width, _show.Height);
            button.BackColor = Color.White;
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.Padding = new Padding(10);
            button.Click += UpdateSelectButton;
            button.Visible = true;
            _splitContainer1.Panel1.Controls.Add(button);
            _allButtons.Add(button);
        }
    }
}
