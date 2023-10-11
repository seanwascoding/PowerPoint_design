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
        Shapes _compound;
        public Form1(Shapes shapes)
        {
            InitializeComponent();
            this._compound = shapes;
            ShapeGridView.CellClick += DeleteInstance;
        }

        // test
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ShapeComboBox.Text.ToString() == Resource.Line)
            {
                // create line instance
                Shape line = ShapeFactory.CreateLine(3);
                _compound.AddShape(line);
                double[] temp = line.GetCoordinates();

                // create cells
                DataGridViewRow row = new DataGridViewRow();

                // 
                DataGridViewButtonCell test = new DataGridViewButtonCell();
                test.Value = Resource.Delete;
                test.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                cell1.Value = Resource.Line;
                cell1.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                cell2.Value = string.Concat("(", temp[0], ",", temp[1], ")", " ", "(", temp[2], ",", temp[3], ")");
                cell2.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Add to cells
                row.Cells.Add(test);
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                ShapeGridView.Rows.Add(row);
            }
            else if (ShapeComboBox.Text.ToString() == Resource.Rectangle)
            {
                // create line instance
                Shape rectangle = ShapeFactory.CreateRectangle(40, 70);
                _compound.AddShape(rectangle);
                double[] temp = rectangle.GetCoordinates();

                // create cells
                DataGridViewRow row = new DataGridViewRow();

                //
                DataGridViewButtonCell test = new DataGridViewButtonCell();
                test.Value = Resource.Delete;
                test.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                cell1.Value = Resource.Line;
                cell1.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                cell2.Value = string.Concat("(", temp[0], ",", temp[1], ")", " ", "(", temp[2], ",", temp[3], ")");
                cell2.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Add to cells
                row.Cells.Add(test);
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                ShapeGridView.Rows.Add(row);
            }
            else
            {
                MessageBox.Show(Resource.ErrorCode);
            }
        }

        //Delete the item => TODO destory the instance
        private void DeleteInstance(object sender, DataGridViewCellEventArgs e)
        {
            if (ShapeGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                DataGridViewRow row = ShapeGridView.Rows[e.RowIndex];
                ShapeGridView.Rows.Remove(row);
                Console.WriteLine(e.RowIndex);
                _compound.RemoveShape(e.RowIndex);
            }
        }
    }
}
