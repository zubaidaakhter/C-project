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
    public partial class doctor_login : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
        public static string username;
        public doctor_login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                login_option_form log = new login_option_form();
                this.Hide();
                log.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please fill the username !!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Please fill the password !!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;

                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                String query = "Select * from Mdoc1 where UserName=@UserName and Password=@Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                   // MessageBox.Show("Login successful", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    username = textBox1.Text;
                    try
                    {
                        this.Hide();
                        Doctor_homepage H = new Doctor_homepage();
                        H.ShowDialog();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error!!");
                    }
                }
                else
                {
                    MessageBox.Show("Login fail", "falied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();

            }
            else
            {
                MessageBox.Show("Login fail", "falied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                doctor_registration r = new doctor_registration();
                r.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }
    }
}
