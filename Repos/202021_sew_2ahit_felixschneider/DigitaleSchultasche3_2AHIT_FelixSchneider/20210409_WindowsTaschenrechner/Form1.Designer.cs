namespace _20210409_WindowsTaschenrechner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_wert = new System.Windows.Forms.Label();
            this.lbl_operator = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(302, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(401, 39);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_wert
            // 
            this.lbl_wert.AutoSize = true;
            this.lbl_wert.Location = new System.Drawing.Point(78, 71);
            this.lbl_wert.Name = "lbl_wert";
            this.lbl_wert.Size = new System.Drawing.Size(0, 32);
            this.lbl_wert.TabIndex = 1;
            // 
            // lbl_operator
            // 
            this.lbl_operator.AutoSize = true;
            this.lbl_operator.Location = new System.Drawing.Point(186, 71);
            this.lbl_operator.Name = "lbl_operator";
            this.lbl_operator.Size = new System.Drawing.Size(0, 32);
            this.lbl_operator.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 1429);
            this.Controls.Add(this.lbl_operator);
            this.Controls.Add(this.lbl_wert);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTL Calc 0.9 (C) 2AHIT 2020/21";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_wert;
        private System.Windows.Forms.Label lbl_operator;
    }
}

