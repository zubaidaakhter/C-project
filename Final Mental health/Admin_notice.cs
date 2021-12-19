using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Login_form
{
    public partial class Admin_notice : Form
    {
       string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
        public Admin_notice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked==true)
                {

                    SqlConnection c = new SqlConnection(cs);
                    c.Open();
                    SqlCommand cmd = new SqlCommand("Insert into ANotice1 Values(@Notice)", c);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Notice", textBox1.Text);
                    int a = cmd.ExecuteNonQuery();
                    c.Close();
                    if (a > 0)
                    {
                        MessageBox.Show("The Noticification has been sent!!");

                    }
                   else
                    MessageBox.Show("Invalid Input!!");
                }
                 if (radioButton2.Checked==true)
                 {
                    SqlConnection c = new SqlConnection(cs);
                    c.Open();
                    SqlCommand md = new SqlCommand("Insert into DNotice2 Values(@Notice)", c);
                    md.CommandType = CommandType.Text;
                    md.Parameters.AddWithValue("@Notice", textBox1.Text);
                    int a = md.ExecuteNonQuery();
                    c.Close();
                    if (a > 0)
                    {
                        MessageBox.Show("The Noticification has been sent!!");

                    }
                    else
                       MessageBox.Show("Invalid Input!!");
                }
                else 
                {
                    MessageBox.Show("Invalid Input!!");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to send", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Admin_homepage a5 = new Admin_homepage();
                this.Hide();
                a5.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot Clear");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
