
namespace PowerPoint
{
    partial class Form2
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
            this._positionX1 = new System.Windows.Forms.TextBox();
            this._positionY1 = new System.Windows.Forms.TextBox();
            this._positionX2 = new System.Windows.Forms.TextBox();
            this._positionY2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._ok = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _positionX1
            // 
            this._positionX1.Location = new System.Drawing.Point(22, 58);
            this._positionX1.Name = "_positionX1";
            this._positionX1.Size = new System.Drawing.Size(100, 22);
            this._positionX1.TabIndex = 0;
            // 
            // _positionY1
            // 
            this._positionY1.Location = new System.Drawing.Point(183, 58);
            this._positionY1.Name = "_positionY1";
            this._positionY1.Size = new System.Drawing.Size(100, 22);
            this._positionY1.TabIndex = 1;
            // 
            // _positionX2
            // 
            this._positionX2.Location = new System.Drawing.Point(22, 182);
            this._positionX2.Name = "_positionX2";
            this._positionX2.Size = new System.Drawing.Size(100, 22);
            this._positionX2.TabIndex = 2;
            // 
            // _positionY2
            // 
            this._positionY2.Location = new System.Drawing.Point(183, 182);
            this._positionY2.Name = "_positionY2";
            this._positionY2.Size = new System.Drawing.Size(100, 22);
            this._positionY2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "左上角座標X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "左上角座標Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "右下角座標X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "右下角座標Y";
            // 
            // _ok
            // 
            this._ok.Location = new System.Drawing.Point(37, 223);
            this._ok.Name = "_ok";
            this._ok.Size = new System.Drawing.Size(75, 23);
            this._ok.TabIndex = 8;
            this._ok.Text = "OK";
            this._ok.UseVisualStyleBackColor = true;
            this._ok.Click += new System.EventHandler(this.ClickOk);
            // 
            // _cancel
            // 
            this._cancel.Location = new System.Drawing.Point(194, 223);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(75, 23);
            this._cancel.TabIndex = 9;
            this._cancel.Text = "Cancel";
            this._cancel.UseVisualStyleBackColor = true;
            this._cancel.Click += new System.EventHandler(this.ClickCancel);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 263);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._ok);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._positionY2);
            this.Controls.Add(this._positionX2);
            this.Controls.Add(this._positionY1);
            this.Controls.Add(this._positionX1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _positionX1;
        private System.Windows.Forms.TextBox _positionY1;
        private System.Windows.Forms.TextBox _positionX2;
        private System.Windows.Forms.TextBox _positionY2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _ok;
        private System.Windows.Forms.Button _cancel;
    }
}