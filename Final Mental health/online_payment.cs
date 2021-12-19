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
    public partial class online_payment : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
        public static string Amount;
        public online_payment()
        {
            InitializeComponent();
        }

        

        private void paybutton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(cs);
                c.Open();
                SqlCommand cmd = new SqlCommand("Insert into Online1 Values(@Card,@OTP,@Password,@Type,@Amount)", c);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Card", textBox1.Text);
                cmd.Parameters.AddWithValue("@OTP", textBox2.Text);
                cmd.Parameters.AddWithValue("@Password", textBox3.Text);
                cmd.Parameters.AddWithValue("@Amount", textBox4.Text);
                cmd.Parameters.AddWithValue("@Type", comboCardType.Text);
                int a = cmd.ExecuteNonQuery();
                c.Close();
                if (a > 0)
                {
                    MessageBox.Show("Information Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Amount = textBox4.Text;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Insert Data", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Close();
                User_Membership use2 = new User_Membership();
                this.Hide();
                use2.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox3.UseSystemPasswordChar = false;
                    break;

                default:
                    textBox3.UseSystemPasswordChar = true;
                    break;

            }
        }
    }
}
