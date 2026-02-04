namespace WinFormsApp3
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            Countries = new ListView();
            Country = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();

            label1.AutoSize = true;
            label1.Location = new Point(45, 43);
            label1.Text = "Country";
            label1.Click += label1_Click;

            label2.AutoSize = true;
            label2.Location = new Point(45, 90);
            label2.Text = "State";

            textBox1.Location = new Point(129, 35);
            textBox2.Location = new Point(129, 82);

            Countries.Columns.AddRange(new ColumnHeader[] { Country, columnHeader1 });
            Countries.Location = new Point(430, 35);
            Countries.Size = new Size(196, 167);
            Countries.UseCompatibleStateImageBehavior = false;
            Countries.SelectedIndexChanged += listView1_SelectedIndexChanged;

            checkBox1.Location = new Point(44, 157);
            checkBox1.Text = "Postal Mail";
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

            checkBox2.Location = new Point(44, 207);
            checkBox2.Text = "E-Mail";

            radioButton1.Location = new Point(190, 156);
            radioButton1.Text = "Male";

            radioButton2.Location = new Point(190, 206);
            radioButton2.Text = "Female";

            button1.Location = new Point(49, 275);
            button1.Text = "Add";
            button1.Click += button1_Click;

            button2.Location = new Point(166, 275);
            button2.Text = "Remove Country";
            button2.Click += button2_Click;

            button3.Location = new Point(322, 275);
            button3.Text = "Remove State";
            button3.Click += button3_Click;

            button4.Location = new Point(470, 275);
            button4.Text = "Show Details";
            button4.Click += button4_Click;

            comboBox1.Location = new Point(433, 210);

            ClientSize = new Size(800, 450);
            Controls.AddRange(new Control[]
            {
                label1,label2,textBox1,textBox2,Countries,
                checkBox1,checkBox2,radioButton1,radioButton2,
                button1,button2,button3,button4,comboBox1
            });

            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private ListView Countries;
        private ColumnHeader Country;
        private ColumnHeader columnHeader1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ComboBox comboBox1;
    }
}
