
namespace PowerPoint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._shapeGridView = new System.Windows.Forms.DataGridView();
            this._button2 = new System.Windows.Forms.Button();
            this._button3 = new System.Windows.Forms.Button();
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._panel1 = new System.Windows.Forms.Panel();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._shapeComboBox = new System.Windows.Forms.ComboBox();
            this._addButton = new System.Windows.Forms.Button();
            this._deleteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._shapeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._coordinatesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._shapeGridView)).BeginInit();
            this._menuStrip1.SuspendLayout();
            this._groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _shapeGridView
            // 
            this._shapeGridView.AllowUserToResizeColumns = false;
            this._shapeGridView.AllowUserToResizeRows = false;
            this._shapeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._shapeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteColumn,
            this._shapeColumn,
            this._coordinatesColumn});
            this._shapeGridView.Location = new System.Drawing.Point(6, 116);
            this._shapeGridView.Name = "_shapeGridView";
            this._shapeGridView.ReadOnly = true;
            this._shapeGridView.RowHeadersVisible = false;
            this._shapeGridView.RowTemplate.Height = 24;
            this._shapeGridView.Size = new System.Drawing.Size(293, 127);
            this._shapeGridView.TabIndex = 2;
            // 
            // _button2
            // 
            this._button2.Location = new System.Drawing.Point(0, 27);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(116, 71);
            this._button2.TabIndex = 3;
            this._button2.UseVisualStyleBackColor = true;
            // 
            // _button3
            // 
            this._button3.Location = new System.Drawing.Point(0, 104);
            this._button3.Name = "_button3";
            this._button3.Size = new System.Drawing.Size(116, 71);
            this._button3.TabIndex = 4;
            this._button3.UseVisualStyleBackColor = true;
            // 
            // _menuStrip1
            // 
            this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItem});
            this._menuStrip1.Location = new System.Drawing.Point(0, 0);
            this._menuStrip1.Name = "_menuStrip1";
            this._menuStrip1.Size = new System.Drawing.Size(1174, 24);
            this._menuStrip1.TabIndex = 5;
            this._menuStrip1.Text = "_menuStrip1";
            // 
            // _toolStripMenuItem
            // 
            this._toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._toolStripMenuItem.Name = "_toolStripMenuItem";
            this._toolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this._toolStripMenuItem.Text = "Explain";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this._aboutToolStripMenuItem.Text = "about";
            // 
            // _panel1
            // 
            this._panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._panel1.Location = new System.Drawing.Point(121, 27);
            this._panel1.Name = "_panel1";
            this._panel1.Size = new System.Drawing.Size(730, 582);
            this._panel1.TabIndex = 6;
            // 
            // _groupBox1
            // 
            this._groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._groupBox1.Controls.Add(this._shapeComboBox);
            this._groupBox1.Controls.Add(this._addButton);
            this._groupBox1.Controls.Add(this._shapeGridView);
            this._groupBox1.Location = new System.Drawing.Point(857, 27);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(305, 249);
            this._groupBox1.TabIndex = 8;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "Display";
            // 
            // _shapeComboBox
            // 
            this._shapeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._shapeComboBox.FormattingEnabled = true;
            this._shapeComboBox.Items.AddRange(new object[] {
            "Line",
            "Rectangle"});
            this._shapeComboBox.Location = new System.Drawing.Point(156, 56);
            this._shapeComboBox.Name = "_shapeComboBox";
            this._shapeComboBox.Size = new System.Drawing.Size(78, 20);
            this._shapeComboBox.TabIndex = 0;
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(64, 38);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(65, 55);
            this._addButton.TabIndex = 1;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // _deleteColumn
            // 
            this._deleteColumn.HeaderText = "Delete";
            this._deleteColumn.Name = "_deleteColumn";
            this._deleteColumn.ReadOnly = true;
            // 
            // _shapeColumn
            // 
            this._shapeColumn.HeaderText = "Shape";
            this._shapeColumn.Name = "_shapeColumn";
            this._shapeColumn.ReadOnly = true;
            // 
            // _coordinatesColumn
            // 
            this._coordinatesColumn.HeaderText = "Coordinates";
            this._coordinatesColumn.Name = "_coordinatesColumn";
            this._coordinatesColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1174, 612);
            this.Controls.Add(this._groupBox1);
            this.Controls.Add(this._panel1);
            this.Controls.Add(this._button3);
            this.Controls.Add(this._button2);
            this.Controls.Add(this._menuStrip1);
            this.MainMenuStrip = this._menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._shapeGridView)).EndInit();
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            this._groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView _shapeGridView;
        private System.Windows.Forms.Button _button2;
        private System.Windows.Forms.Button _button3;
        private System.Windows.Forms.MenuStrip _menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.Panel _panel1;
        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.ComboBox _shapeComboBox;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _deleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _coordinatesColumn;
    }
}

