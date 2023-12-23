
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
            this._deleteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._shapeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._coordinatesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._show = new System.Windows.Forms.Button();
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._shapeComboBox = new System.Windows.Forms.ComboBox();
            this._addButton = new System.Windows.Forms.Button();
            this._shapeStrip = new System.Windows.Forms.ToolStrip();
            this._lineButton = new System.Windows.Forms.ToolStripButton();
            this._rectangleButton = new System.Windows.Forms.ToolStripButton();
            this._circleButton = new System.Windows.Forms.ToolStripButton();
            this._cursorButton = new System.Windows.Forms.ToolStripButton();
            this._unDo = new System.Windows.Forms.ToolStripButton();
            this._reDo = new System.Windows.Forms.ToolStripButton();
            this._splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._canvas = new PowerPoint.DoubleBufferedPanel();
            ((System.ComponentModel.ISupportInitialize)(this._shapeGridView)).BeginInit();
            this._menuStrip1.SuspendLayout();
            this._groupBox1.SuspendLayout();
            this._shapeStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
            this._splitContainer1.Panel1.SuspendLayout();
            this._splitContainer1.Panel2.SuspendLayout();
            this._splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).BeginInit();
            this._splitContainer2.Panel1.SuspendLayout();
            this._splitContainer2.Panel2.SuspendLayout();
            this._splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _shapeGridView
            // 
            this._shapeGridView.AllowUserToResizeColumns = false;
            this._shapeGridView.AllowUserToResizeRows = false;
            this._shapeGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._shapeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._shapeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteColumn,
            this._shapeColumn,
            this._coordinatesColumn});
            this._shapeGridView.Location = new System.Drawing.Point(3, 116);
            this._shapeGridView.Name = "_shapeGridView";
            this._shapeGridView.ReadOnly = true;
            this._shapeGridView.RowHeadersVisible = false;
            this._shapeGridView.RowTemplate.Height = 24;
            this._shapeGridView.Size = new System.Drawing.Size(312, 127);
            this._shapeGridView.TabIndex = 2;
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
            // _show
            // 
            this._show.Dock = System.Windows.Forms.DockStyle.Top;
            this._show.Location = new System.Drawing.Point(0, 0);
            this._show.Name = "_show";
            this._show.Size = new System.Drawing.Size(123, 76);
            this._show.TabIndex = 3;
            this._show.UseVisualStyleBackColor = true;
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
            // _groupBox1
            // 
            this._groupBox1.AutoSize = true;
            this._groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._groupBox1.Controls.Add(this._shapeComboBox);
            this._groupBox1.Controls.Add(this._addButton);
            this._groupBox1.Controls.Add(this._shapeGridView);
            this._groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBox1.Location = new System.Drawing.Point(0, 0);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(315, 563);
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
            "Rectangle",
            "Circle"});
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
            // _shapeStrip
            // 
            this._shapeStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineButton,
            this._rectangleButton,
            this._circleButton,
            this._cursorButton,
            this._unDo,
            this._reDo});
            this._shapeStrip.Location = new System.Drawing.Point(0, 24);
            this._shapeStrip.Name = "_shapeStrip";
            this._shapeStrip.Size = new System.Drawing.Size(1174, 25);
            this._shapeStrip.TabIndex = 9;
            this._shapeStrip.Text = "toolStrip1";
            // 
            // _lineButton
            // 
            this._lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._lineButton.Image = global::PowerPoint.Properties.Resources.下載;
            this._lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(23, 22);
            this._lineButton.Text = "toolStripButton1";
            this._lineButton.Click += new System.EventHandler(this.ClickLineButton);
            // 
            // _rectangleButton
            // 
            this._rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rectangleButton.Image = global::PowerPoint.Properties.Resources.b8fa8f291632f8fe68842e4fb100d8e0_square_rectangle_shape;
            this._rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(23, 22);
            this._rectangleButton.Text = "toolStripButton2";
            this._rectangleButton.Click += new System.EventHandler(this.ClickRectangleButton);
            // 
            // _circleButton
            // 
            this._circleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._circleButton.Image = global::PowerPoint.Properties.Resources._096b9f21d164aa34a980c85b8a5994b4;
            this._circleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._circleButton.Name = "_circleButton";
            this._circleButton.Size = new System.Drawing.Size(23, 22);
            this._circleButton.Text = "toolStripButton3";
            this._circleButton.Click += new System.EventHandler(this.ClickCircleButton);
            // 
            // _cursorButton
            // 
            this._cursorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._cursorButton.Image = global::PowerPoint.Properties.Resources.cursor;
            this._cursorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._cursorButton.Name = "_cursorButton";
            this._cursorButton.Size = new System.Drawing.Size(23, 22);
            this._cursorButton.Text = "toolStripButton1";
            this._cursorButton.Click += new System.EventHandler(this.ClickCursor);
            // 
            // _unDo
            // 
            this._unDo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._unDo.Enabled = false;
            this._unDo.Image = global::PowerPoint.Properties.Resources.Screenshot_2023_12_16_155813;
            this._unDo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._unDo.Name = "_unDo";
            this._unDo.Size = new System.Drawing.Size(23, 22);
            this._unDo.Text = "toolStripButton1";
            // 
            // _reDo
            // 
            this._reDo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._reDo.Enabled = false;
            this._reDo.Image = global::PowerPoint.Properties.Resources.Screenshot_2023_12_16_155856;
            this._reDo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._reDo.Name = "_reDo";
            this._reDo.Size = new System.Drawing.Size(23, 22);
            this._reDo.Text = "toolStripButton2";
            // 
            // _splitContainer1
            // 
            this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainer1.Location = new System.Drawing.Point(0, 49);
            this._splitContainer1.Name = "_splitContainer1";
            // 
            // _splitContainer1.Panel1
            // 
            this._splitContainer1.Panel1.Controls.Add(this._show);
            this._splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(2);
            // 
            // _splitContainer1.Panel2
            // 
            this._splitContainer1.Panel2.Controls.Add(this._splitContainer2);
            this._splitContainer1.Size = new System.Drawing.Size(1174, 563);
            this._splitContainer1.SplitterDistance = 123;
            this._splitContainer1.SplitterWidth = 8;
            this._splitContainer1.TabIndex = 11;
            // 
            // _splitContainer2
            // 
            this._splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._splitContainer2.Location = new System.Drawing.Point(0, 0);
            this._splitContainer2.Name = "_splitContainer2";
            // 
            // _splitContainer2.Panel1
            // 
            this._splitContainer2.Panel1.Controls.Add(this._canvas);
            this._splitContainer2.Panel1.Margin = new System.Windows.Forms.Padding(2);
            // 
            // _splitContainer2.Panel2
            // 
            this._splitContainer2.Panel2.Controls.Add(this._groupBox1);
            this._splitContainer2.Size = new System.Drawing.Size(1043, 563);
            this._splitContainer2.SplitterDistance = 720;
            this._splitContainer2.SplitterWidth = 8;
            this._splitContainer2.TabIndex = 11;
            // 
            // _canvas
            // 
            this._canvas.AutoSize = true;
            this._canvas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this._canvas.Location = new System.Drawing.Point(1, 38);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(716, 437);
            this._canvas.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1174, 612);
            this.Controls.Add(this._splitContainer1);
            this.Controls.Add(this._shapeStrip);
            this.Controls.Add(this._menuStrip1);
            this.MainMenuStrip = this._menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._shapeGridView)).EndInit();
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            this._groupBox1.ResumeLayout(false);
            this._shapeStrip.ResumeLayout(false);
            this._shapeStrip.PerformLayout();
            this._splitContainer1.Panel1.ResumeLayout(false);
            this._splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
            this._splitContainer1.ResumeLayout(false);
            this._splitContainer2.Panel1.ResumeLayout(false);
            this._splitContainer2.Panel1.PerformLayout();
            this._splitContainer2.Panel2.ResumeLayout(false);
            this._splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).EndInit();
            this._splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView _shapeGridView;
        private System.Windows.Forms.Button _show;
        private System.Windows.Forms.MenuStrip _menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.ComboBox _shapeComboBox;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn _deleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _coordinatesColumn;
        private System.Windows.Forms.ToolStrip _shapeStrip;
        private System.Windows.Forms.ToolStripButton _lineButton;
        private System.Windows.Forms.ToolStripButton _rectangleButton;
        private System.Windows.Forms.ToolStripButton _circleButton;
        private System.Windows.Forms.ToolStripButton _cursorButton;
        private System.Windows.Forms.ToolStripButton _unDo;
        private System.Windows.Forms.ToolStripButton _reDo;
        private DoubleBufferedPanel _canvas;
        private System.Windows.Forms.SplitContainer _splitContainer1;
        private System.Windows.Forms.SplitContainer _splitContainer2;
    }
}

