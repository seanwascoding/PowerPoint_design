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
        const string LEFT = "(";
        const string RIGHT = ")";
        const string COMMA = ",";
        const string TAB = " ";
        const string ERROR = "Select Item First";
        const string RECTANGLE = "Rectangle";
        const string CLICK = "user click position:";
        const int SIZE_ZERO = 0;
        const int SIZE_ONE = 1;
        const int SIZE_TWO = 2;
        const int SIZE_THREE = 3;
        const int LINE_SIZE = 3;
        const int RECTANGLE_WIDTH = 40;
        const int RECTANGLE_LENGTH = 70;
        Shapes _compound;
        public Form1(Shapes shapes)
        {
            InitializeComponent();
            this._compound = shapes;
            _shapeGridView.CellClick += DeleteInstance;
        }

        // Create Cells => Line
        private DataGridViewRow CreateCellsLine(double[] temp)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewButtonCell test = new DataGridViewButtonCell();
            test.Value = DELETE;
            test.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
            cell1.Value = LINE;
            cell1.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
            cell2.Value = string.Concat(LEFT, temp[SIZE_ZERO], COMMA, temp[SIZE_ONE], RIGHT, TAB, LEFT, temp[SIZE_TWO], COMMA, temp[SIZE_THREE], RIGHT);
            cell2.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            row.Cells.Add(test);
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            return row;
        }

        // Create Cells => Rectangle
        private DataGridViewRow CreateCellsRectangle(double[] temp)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewButtonCell test = new DataGridViewButtonCell();
            test.Value = DELETE;
            test.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
            cell1.Value = RECTANGLE;
            cell1.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
            cell2.Value = string.Concat(LEFT, temp[SIZE_ZERO], COMMA, temp[SIZE_ONE], RIGHT, TAB, LEFT, temp[SIZE_TWO], COMMA, temp[SIZE_THREE], RIGHT);
            cell2.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            row.Cells.Add(test);
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            return row;
        }

        // Add item to GridView
        private void AddButtonClick(object sender, EventArgs e)
        {
            if (_shapeComboBox.Text.ToString() == LINE)
            {
                Shape line = ShapeFactory.CreateLine(LINE_SIZE);
                _compound.AddShape(line);
                _shapeGridView.Rows.Add(CreateCellsLine(line.GetCoordinates()));
            }
            else if (_shapeComboBox.Text.ToString() == RECTANGLE)
            {
                Shape rectangle = ShapeFactory.CreateRectangle(RECTANGLE_WIDTH, RECTANGLE_LENGTH);
                _compound.AddShape(rectangle);
                _shapeGridView.Rows.Add(CreateCellsRectangle(rectangle.GetCoordinates()));
            }
            else
            {
                MessageBox.Show(ERROR);
            }
        }

        // Delete the item => Destory the instance
        private void DeleteInstance(object sender, DataGridViewCellEventArgs e)
        {
            if (_shapeGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                DataGridViewRow row = _shapeGridView.Rows[e.RowIndex];
                _shapeGridView.Rows.Remove(row);
                Console.WriteLine(CLICK + e.RowIndex);
                _compound.RemoveShape(e.RowIndex);
            }
        }
    }
}
