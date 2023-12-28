using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            // position text
            _positionX1.KeyPress += MaskTextBoxString;
            _positionX2.KeyPress += MaskTextBoxString;
            _positionY1.KeyPress += MaskTextBoxString;
            _positionY2.KeyPress += MaskTextBoxString;
        }

        // MaskTextBoxString
        private void MaskTextBoxString(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // ClickOk
        private void ClickOk(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_positionX1.Text) || string.IsNullOrEmpty(_positionX2.Text) || string.IsNullOrEmpty(_positionY1.Text) || string.IsNullOrEmpty(_positionY2.Text))
            {
                MessageBox.Show("empty input");
                return;
            }
            DialogResult = DialogResult.OK;
        }

        // ClickCancel
        private void ClickCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public int GetPositionX1
        {
            get
            {
                return int.Parse(_positionX1.Text);
            }
        }

        public int GetPositionX2
        {
            get
            {
                return int.Parse(_positionX2.Text);
            }
        }

        public int GetPositionY1
        {
            get
            {
                return int.Parse(_positionY1.Text);
            }
        }

        public int GetPositionY2
        {
            get
            {
                return int.Parse(_positionY2.Text);
            }
        }
    }
}
