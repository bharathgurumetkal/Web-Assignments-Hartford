namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dob = dateTimePicker1.Value;
            DateTime today = DateTime.Now;

            int age = today.Year - dob.Year;

            // Adjust if birthday has not occurred yet
            if (today < dob.AddYears(age))
            {
                age--;
            }

            label2.Text = "Your Age is: " + age + " years";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
