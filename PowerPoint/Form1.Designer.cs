
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
            this.ShapeGridView = new System.Windows.Forms.DataGridView();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShapeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfomationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ShapeComboBox = new System.Windows.Forms.ComboBox();
            this.AddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ShapeGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShapeGridView
            // 
            this.ShapeGridView.AllowUserToResizeColumns = false;
            this.ShapeGridView.AllowUserToResizeRows = false;
            this.ShapeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShapeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteColumn,
            this.ShapeColumn,
            this.InfomationColumn});
            this.ShapeGridView.Location = new System.Drawing.Point(6, 116);
            this.ShapeGridView.Name = "ShapeGridView";
            this.ShapeGridView.ReadOnly = true;
            this.ShapeGridView.RowHeadersVisible = false;
            this.ShapeGridView.RowTemplate.Height = 24;
            this.ShapeGridView.Size = new System.Drawing.Size(293, 127);
            this.ShapeGridView.TabIndex = 2;
            // 
            // DeleteColumn
            // 
            this.DeleteColumn.HeaderText = "Delete";
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.ReadOnly = true;
            // 
            // ShapeColumn
            // 
            this.ShapeColumn.HeaderText = "Shape";
            this.ShapeColumn.Name = "ShapeColumn";
            this.ShapeColumn.ReadOnly = true;
            // 
            // InfomationColumn
            // 
            this.InfomationColumn.HeaderText = "Infomation";
            this.InfomationColumn.Name = "InfomationColumn";
            this.InfomationColumn.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 71);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 104);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 71);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明關於ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1174, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明關於ToolStripMenuItem
            // 
            this.說明關於ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.說明關於ToolStripMenuItem.Name = "說明關於ToolStripMenuItem";
            this.說明關於ToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.說明關於ToolStripMenuItem.Text = "Explain";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.aboutToolStripMenuItem.Text = "about";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(121, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 582);
            this.panel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.ShapeComboBox);
            this.groupBox1.Controls.Add(this.AddButton);
            this.groupBox1.Controls.Add(this.ShapeGridView);
            this.groupBox1.Location = new System.Drawing.Point(857, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 249);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display";
            // 
            // ShapeComboBox
            // 
            this.ShapeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShapeComboBox.FormattingEnabled = true;
            this.ShapeComboBox.Items.AddRange(new object[] {
            "Line",
            "Rectangle"});
            this.ShapeComboBox.Location = new System.Drawing.Point(156, 56);
            this.ShapeComboBox.Name = "ShapeComboBox";
            this.ShapeComboBox.Size = new System.Drawing.Size(78, 20);
            this.ShapeComboBox.TabIndex = 0;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(64, 38);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(65, 55);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1174, 612);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ShapeGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView ShapeGridView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明關於ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShapeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InfomationColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ShapeComboBox;
        private System.Windows.Forms.Button AddButton;
    }
}

