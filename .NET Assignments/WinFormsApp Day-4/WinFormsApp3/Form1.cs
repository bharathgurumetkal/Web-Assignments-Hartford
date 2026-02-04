using System;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configure ListView
            Countries.View = View.Details;
            Countries.CheckBoxes = true;
            Countries.FullRowSelect = true;

            Country.Text = "Country";
            columnHeader1.Text = "State";
        }

        // ADD COUNTRY + STATE
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please enter Country and State");
                return;
            }

            ListViewItem item = new ListViewItem(textBox1.Text);
            item.SubItems.Add(textBox2.Text);

            Countries.Items.Add(item);

            textBox1.Clear();
            textBox2.Clear();
        }

        // REMOVE COUNTRY
        private void button2_Click(object sender, EventArgs e)
        {
            if (Countries.SelectedItems.Count > 0)
            {
                Countries.Items.Remove(Countries.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Please select a country to remove");
            }
        }

        // REMOVE STATE
        private void button3_Click(object sender, EventArgs e)
        {
            if (Countries.SelectedItems.Count > 0)
            {
                Countries.SelectedItems[0].SubItems[1].Text = "";
            }
            else
            {
                MessageBox.Show("Please select a country");
            }
        }

        // SHOW DETAILS
        private void button4_Click(object sender, EventArgs e)
        {
            if (Countries.SelectedItems.Count > 0)
            {
                ListViewItem item = Countries.SelectedItems[0];

                string gender = radioButton1.Checked ? "Male" :
                                radioButton2.Checked ? "Female" : "Not Selected";

                string contact = "";
                if (checkBox1.Checked) contact += "Postal Mail ";
                if (checkBox2.Checked) contact += "E-Mail ";

                MessageBox.Show(
                    "Country: " + item.Text +
                    "\nState: " + item.SubItems[1].Text +
                    "\nGender: " + gender +
                    "\nContact: " + contact
                );
            }
            else
            {
                MessageBox.Show("Please select a country");
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
    }
}
