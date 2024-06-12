
namespace _20210528_DictionaryForms
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
            this.lblist = new System.Windows.Forms.ListBox();
            this.bcheck = new System.Windows.Forms.Button();
            this.tbword = new System.Windows.Forms.TextBox();
            this.badd = new System.Windows.Forms.Button();
            this.tbaddkey = new System.Windows.Forms.TextBox();
            this.tbaddvalue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bremove = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lwordright = new System.Windows.Forms.Label();
            this.lwordwrong = new System.Windows.Forms.Label();
            this.bload = new System.Windows.Forms.Button();
            this.bsave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblist
            // 
            this.lblist.FormattingEnabled = true;
            this.lblist.ItemHeight = 25;
            this.lblist.Location = new System.Drawing.Point(13, 13);
            this.lblist.Margin = new System.Windows.Forms.Padding(4);
            this.lblist.Name = "lblist";
            this.lblist.Size = new System.Drawing.Size(190, 504);
            this.lblist.TabIndex = 0;
            this.lblist.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // bcheck
            // 
            this.bcheck.Location = new System.Drawing.Point(563, 63);
            this.bcheck.Margin = new System.Windows.Forms.Padding(4);
            this.bcheck.Name = "bcheck";
            this.bcheck.Size = new System.Drawing.Size(89, 31);
            this.bcheck.TabIndex = 1;
            this.bcheck.Text = "Check";
            this.bcheck.UseVisualStyleBackColor = true;
            this.bcheck.Click += new System.EventHandler(this.bcheck_Click);
            // 
            // tbword
            // 
            this.tbword.Location = new System.Drawing.Point(64, 63);
            this.tbword.Margin = new System.Windows.Forms.Padding(4);
            this.tbword.Name = "tbword";
            this.tbword.Size = new System.Drawing.Size(478, 31);
            this.tbword.TabIndex = 2;
            // 
            // badd
            // 
            this.badd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.badd.Location = new System.Drawing.Point(14, 61);
            this.badd.Margin = new System.Windows.Forms.Padding(4);
            this.badd.Name = "badd";
            this.badd.Size = new System.Drawing.Size(751, 36);
            this.badd.TabIndex = 4;
            this.badd.Text = "Add word to list";
            this.badd.UseVisualStyleBackColor = false;
            this.badd.Click += new System.EventHandler(this.badd_Click);
            // 
            // tbaddkey
            // 
            this.tbaddkey.Location = new System.Drawing.Point(81, 16);
            this.tbaddkey.Margin = new System.Windows.Forms.Padding(4);
            this.tbaddkey.Name = "tbaddkey";
            this.tbaddkey.Size = new System.Drawing.Size(302, 31);
            this.tbaddkey.TabIndex = 5;
            // 
            // tbaddvalue
            // 
            this.tbaddvalue.Location = new System.Drawing.Point(483, 16);
            this.tbaddvalue.Margin = new System.Windows.Forms.Padding(4);
            this.tbaddvalue.Name = "tbaddvalue";
            this.tbaddvalue.Size = new System.Drawing.Size(282, 31);
            this.tbaddvalue.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "in list:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "to check:";
            // 
            // bremove
            // 
            this.bremove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bremove.Location = new System.Drawing.Point(14, 113);
            this.bremove.Name = "bremove";
            this.bremove.Size = new System.Drawing.Size(751, 34);
            this.bremove.TabIndex = 9;
            this.bremove.Text = "Remove selsected word from list";
            this.bremove.UseVisualStyleBackColor = false;
            this.bremove.Click += new System.EventHandler(this.bremove_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Anzahl RICHTIG:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Anzahl FALSCH:";
            // 
            // lwordright
            // 
            this.lwordright.AutoSize = true;
            this.lwordright.Location = new System.Drawing.Point(210, 302);
            this.lwordright.Name = "lwordright";
            this.lwordright.Size = new System.Drawing.Size(22, 25);
            this.lwordright.TabIndex = 12;
            this.lwordright.Text = "0";
            // 
            // lwordwrong
            // 
            this.lwordwrong.AutoSize = true;
            this.lwordwrong.Location = new System.Drawing.Point(520, 302);
            this.lwordwrong.Name = "lwordwrong";
            this.lwordwrong.Size = new System.Drawing.Size(22, 25);
            this.lwordwrong.TabIndex = 13;
            this.lwordwrong.Text = "0";
            // 
            // bload
            // 
            this.bload.Location = new System.Drawing.Point(14, 208);
            this.bload.Name = "bload";
            this.bload.Size = new System.Drawing.Size(112, 34);
            this.bload.TabIndex = 14;
            this.bload.Text = "Load";
            this.bload.UseVisualStyleBackColor = true;
            this.bload.Click += new System.EventHandler(this.bload_Click);
            // 
            // bsave
            // 
            this.bsave.Location = new System.Drawing.Point(14, 168);
            this.bsave.Name = "bsave";
            this.bsave.Size = new System.Drawing.Size(112, 34);
            this.bsave.TabIndex = 15;
            this.bsave.Text = "Save";
            this.bsave.UseVisualStyleBackColor = true;
            this.bsave.Click += new System.EventHandler(this.bsave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(210, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(832, 511);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.badd);
            this.tabPage1.Controls.Add(this.tbaddkey);
            this.tabPage1.Controls.Add(this.tbaddvalue);
            this.tabPage1.Controls.Add(this.bsave);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.bload);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.bremove);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(824, 473);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Editieren";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(824, 473);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Üben";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbword);
            this.tabPage3.Controls.Add(this.bcheck);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.lwordwrong);
            this.tabPage3.Controls.Add(this.lwordright);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(824, 473);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Prüfen";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 209);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(478, 31);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(579, 209);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Check";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 544);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblist);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lblist;
        private System.Windows.Forms.Button bcheck;
        private System.Windows.Forms.TextBox tbword;
        private System.Windows.Forms.Button badd;
        private System.Windows.Forms.TextBox tbaddkey;
        private System.Windows.Forms.TextBox tbaddvalue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bremove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lwordright;
        private System.Windows.Forms.Label lwordwrong;
        private System.Windows.Forms.Button bload;
        private System.Windows.Forms.Button bsave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

