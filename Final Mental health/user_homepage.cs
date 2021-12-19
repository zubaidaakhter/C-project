using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Login_form
{
    public partial class user_homepage : Form
    {
       
        public user_homepage()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                login_option_form op = new login_option_form();
                this.Hide();
                op.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Information_page u2 = new Information_page();
                u2.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                GiveFeedback u1 = new GiveFeedback();
                u1.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void user_homepage_Load(object sender, EventArgs e)
        {
            label2.Text = "Welcome,"+Form1.username;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                User_Notice n1 = new User_Notice();
                n1.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Edit_profile p1 = new Edit_profile();
                p1.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Ask_a_question c1 = new Ask_a_question();
                c1.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }
    }
}
