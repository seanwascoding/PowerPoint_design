using System;
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
        const int LOCATION_X = 121;
        const int LOCATION_Y = 52;
        const int SIZE_Y = 730;
        const int SIZE_X = 557;
        FormPresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();
        Model _model;

        public Form1(FormPresentationModel presentationModel)
        {
            InitializeComponent();
            //
            _model = presentationModel.GetModel();
            _presentationModel = presentationModel;

            //
            _shapeGridView.CellClick += DeleteInstance;
            _shapeGridView.KeyDown += DetectKey;

            //
            _canvas.Location = new Point(LOCATION_X, LOCATION_Y);
            _canvas.Size = new Size(SIZE_Y, SIZE_X);
            _canvas.BackColor = Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);

            //
            _show.Enabled = true;

            //
            _model._modelChanged += HandleModelChanged;

            // databinding
            _presentationModel.PropertyChanged += (sender, args) =>
            {
                _lineButton.Checked = _presentationModel.GetLineState;
                _rectangleButton.Checked = _presentationModel.GetRectangleState;
                _circleButton.Checked = _presentationModel.GetCircleState;
                _cursorButton.Checked = _presentationModel.GetCursorState;
            };
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
        private void Refresh(Shape shape)
        {
            double[] temp = shape.GetCoordinates();
            DataGridViewRow row = _shapeGridView.Rows[_presentationModel.GetPosition()];
            DataGridViewCell cell = row.Cells[SIZE_TWO];
            if (temp.Length == SIZE_TWO)
                cell.Value = string.Concat(LEFT, temp[SIZE_ZERO], COMMA, temp[SIZE_ONE], RIGHT);
            else
                cell.Value = string.Concat(LEFT, temp[SIZE_ZERO], COMMA, temp[SIZE_ONE], RIGHT, TAB, LEFT, temp[SIZE_TWO], COMMA, temp[SIZE_THREE], RIGHT);
        }

        // UpdateCanvas
        private void UpdateCanvas()
        {
            Bitmap bitmap = new Bitmap(_canvas.Width, _canvas.Height);
            _canvas.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, _canvas.Width, _canvas.Height));
            Bitmap resizedBitmap = new Bitmap(_show.Size.Width, _show.Size.Height);
            using (Graphics g = Graphics.FromImage(resizedBitmap))
            {
                g.DrawImage(bitmap, new System.Drawing.Rectangle(0, 0, resizedBitmap.Width, resizedBitmap.Height));
            }
            _show.Image = resizedBitmap;
        }

        // Add item to GridView
        private void AddButtonClick(object sender, EventArgs e)
        {
            Shape temp;
            if (_shapeComboBox.Text.ToString() == LINE)
                temp = ShapeFactory.CreateLine();
            else if (_shapeComboBox.Text.ToString() == RECTANGLE)
                temp = ShapeFactory.CreateRectangle();
            else if (_shapeComboBox.Text.ToString() == CIRCLE)
                temp = ShapeFactory.CreateCircle();
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
            }
        }

        // Clear
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            /* delete button */
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
                    HandleModelChanged();
                    return;
                }
            }
            _model.PressedPointer(e.X, e.Y);
        }

        // CanvasReleased
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.ReleasedPointer(e.X, e.Y);
            if (_presentationModel.IsSelectedState())
            {
                Refresh(_presentationModel.GetSelectShape());
            }
            else
            {
                if (_presentationModel.GetCursorState)
                    return;
                _shapeGridView.Rows.Add(CreateCells(_presentationModel.GetCompound().Last()));
            }
            Cursor = Cursors.Default;
            _presentationModel.SetChecked(SIZE_THREE);
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
            UpdateCanvas();
        }

        // ModelChanged
        public void HandleModelChanged()
        {
            _shapeGridView.Select();
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
                {
                    Console.WriteLine(WORKING);
                    int temp = _presentationModel.GetPosition();
                    _presentationModel.RemoveShape(temp);
                    DataGridViewRow row = _shapeGridView.Rows[temp];
                    _shapeGridView.Rows.Remove(row);
                    _model.ShapeReset();
                    HandleModelChanged();
                }
            }
        }

    }
}
