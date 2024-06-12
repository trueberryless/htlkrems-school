
namespace _20210507_Tierheimverwaltung
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbweight = new System.Windows.Forms.TextBox();
            this.update = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.remove = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.list = new System.Windows.Forms.ListBox();
            this.lspezial = new System.Windows.Forms.Label();
            this.tbspezial = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbtype = new System.Windows.Forms.ComboBox();
            this.ldate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 77);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date:";
            // 
            // tbname
            // 
            this.tbname.Location = new System.Drawing.Point(90, 75);
            this.tbname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbname.Name = "tbname";
            this.tbname.Size = new System.Drawing.Size(231, 27);
            this.tbname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Weight:";
            // 
            // tbweight
            // 
            this.tbweight.Location = new System.Drawing.Point(90, 103);
            this.tbweight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbweight.Name = "tbweight";
            this.tbweight.Size = new System.Drawing.Size(231, 27);
            this.tbweight.TabIndex = 6;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(206, 24);
            this.update.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(87, 29);
            this.update.TabIndex = 7;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(297, 24);
            this.save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(87, 29);
            this.save.TabIndex = 8;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(387, 24);
            this.load.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(87, 29);
            this.load.TabIndex = 9;
            this.load.Text = "Load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.remove);
            this.groupBox1.Controls.Add(this.add);
            this.groupBox1.Controls.Add(this.update);
            this.groupBox1.Controls.Add(this.load);
            this.groupBox1.Controls.Add(this.save);
            this.groupBox1.Location = new System.Drawing.Point(7, 216);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(478, 58);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buttons";
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(116, 24);
            this.remove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(87, 29);
            this.remove.TabIndex = 19;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(25, 24);
            this.add.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(87, 29);
            this.add.TabIndex = 10;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // list
            // 
            this.list.FormattingEnabled = true;
            this.list.ItemHeight = 20;
            this.list.Location = new System.Drawing.Point(7, 8);
            this.list.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(149, 204);
            this.list.TabIndex = 11;
            this.list.SelectedIndexChanged += new System.EventHandler(this.list_SelectedIndexChanged);
            // 
            // lspezial
            // 
            this.lspezial.AutoSize = true;
            this.lspezial.Location = new System.Drawing.Point(7, 133);
            this.lspezial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lspezial.Name = "lspezial";
            this.lspezial.Size = new System.Drawing.Size(60, 20);
            this.lspezial.TabIndex = 12;
            this.lspezial.Text = "Spezial:";
            // 
            // tbspezial
            // 
            this.tbspezial.Location = new System.Drawing.Point(90, 131);
            this.tbspezial.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbspezial.Name = "tbspezial";
            this.tbspezial.Size = new System.Drawing.Size(231, 27);
            this.tbspezial.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbtype);
            this.groupBox2.Controls.Add(this.ldate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lspezial);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbname);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbspezial);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbweight);
            this.groupBox2.Location = new System.Drawing.Point(161, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(324, 204);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Properties";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // cbtype
            // 
            this.cbtype.FormattingEnabled = true;
            this.cbtype.Items.AddRange(new object[] {
            "Dog",
            "Bird"});
            this.cbtype.Location = new System.Drawing.Point(90, 22);
            this.cbtype.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbtype.Name = "cbtype";
            this.cbtype.Size = new System.Drawing.Size(101, 28);
            this.cbtype.TabIndex = 18;
            this.cbtype.SelectedIndexChanged += new System.EventHandler(this.cbtype_SelectedIndexChanged);
            // 
            // ldate
            // 
            this.ldate.AutoSize = true;
            this.ldate.Location = new System.Drawing.Point(90, 49);
            this.ldate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ldate.Name = "ldate";
            this.ldate.Size = new System.Drawing.Size(42, 20);
            this.ldate.TabIndex = 17;
            this.ldate.Text = "Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Type:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 279);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.list);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbweight;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox list;
        private System.Windows.Forms.Label lspezial;
        private System.Windows.Forms.TextBox tbspezial;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label ldate;
        private System.Windows.Forms.ComboBox cbtype;
        private System.Windows.Forms.Button remove;
    }
}

