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
    public partial class User_Membership : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;

        public User_Membership()
        {
            InitializeComponent();
            ResetControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (radioButton1.Checked == true)
                {
                    try
                    {
                        //this.Hide();
                        card_payment pay1 = new card_payment();
                        pay1.ShowDialog();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error!!");
                    }


                }
                if (radioButton2.Checked == true)
                {
                    try
                    {
                        //this.Hide();
                        online_payment pay2 = new online_payment();
                        pay2.ShowDialog();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error!!");
                    }
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

        private void button4_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
        void ResetControl()
            {

                textBox2.Clear();
                textBox3.Clear();
            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(cs);
                c.Open();
                SqlCommand cmd = new SqlCommand("Insert into UPay1 Values(@UserName,@Password,@Charge)", c);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Password", textBox3.Text);
               cmd.Parameters.AddWithValue("@Charge", textBox1.Text);
                int a = cmd.ExecuteNonQuery();
                c.Close();
                if (a > 0)
                {
                    MessageBox.Show(" now you can chat with a doctor, with the chat option!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Insert Data", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void User_Membership_Load(object sender, EventArgs e)
        {
            textBox1.Text = card_payment.amount;
            textBox1.Text = online_payment.Amount;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                user_homepage use1 = new user_homepage();
                this.Hide();
                use1.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
               textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please fill the charge of 300tk,to chat with a doctor!!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
