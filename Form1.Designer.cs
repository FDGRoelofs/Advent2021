
namespace AdventOfCode2021
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.answer1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.answer2 = new System.Windows.Forms.Label();
            this.debuglabel = new System.Windows.Forms.Label();
            this.debuglabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Dag 1",
            "Dag 2",
            "Dag 3",
            "Dag 4",
            "Dag 5",
            "Dag 6",
            "Dag 8"});
            this.comboBox1.Location = new System.Drawing.Point(79, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(468, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Puzzel 1";
            // 
            // answer1
            // 
            this.answer1.AutoSize = true;
            this.answer1.Location = new System.Drawing.Point(512, 125);
            this.answer1.Name = "answer1";
            this.answer1.Size = new System.Drawing.Size(38, 15);
            this.answer1.TabIndex = 2;
            this.answer1.Text = "label2";
            this.answer1.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(468, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Puzzel 2";
            // 
            // answer2
            // 
            this.answer2.AutoSize = true;
            this.answer2.Location = new System.Drawing.Point(512, 175);
            this.answer2.Name = "answer2";
            this.answer2.Size = new System.Drawing.Size(38, 15);
            this.answer2.TabIndex = 4;
            this.answer2.Text = "label4";
            // 
            // debuglabel
            // 
            this.debuglabel.AutoSize = true;
            this.debuglabel.Location = new System.Drawing.Point(275, 341);
            this.debuglabel.Name = "debuglabel";
            this.debuglabel.Size = new System.Drawing.Size(64, 15);
            this.debuglabel.TabIndex = 5;
            this.debuglabel.Text = "debug hier";
            // 
            // debuglabel2
            // 
            this.debuglabel2.AutoSize = true;
            this.debuglabel2.Location = new System.Drawing.Point(275, 375);
            this.debuglabel2.Name = "debuglabel2";
            this.debuglabel2.Size = new System.Drawing.Size(38, 15);
            this.debuglabel2.TabIndex = 6;
            this.debuglabel2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.debuglabel2);
            this.Controls.Add(this.debuglabel);
            this.Controls.Add(this.answer2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.answer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label answer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label answer2;
        private System.Windows.Forms.Label debuglabel;
        private System.Windows.Forms.Label debuglabel2;
    }
}

