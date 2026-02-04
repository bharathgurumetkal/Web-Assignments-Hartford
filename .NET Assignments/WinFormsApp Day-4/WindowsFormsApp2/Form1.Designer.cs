using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Location = new Point(50, 50);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.Text = "Date of Birth";

            // dateTimePicker1
            dateTimePicker1.Location = new Point(160, 45);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);

            // button1
            button1.Location = new Point(160, 90);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.Text = "Calculate Age";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            // label2
            label2.AutoSize = true;
            label2.Location = new Point(160, 130);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 250);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "Form1";
            Text = "Age Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime birthDate = dateTimePicker1.Value;
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            // Adjust age if birthday hasn't occurred yet this year
            if (birthDate > today.AddYears(-age))
            {
                age--;
            }

            label2.Text = $"Age: {age}";
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private Button button1;
    }
}

