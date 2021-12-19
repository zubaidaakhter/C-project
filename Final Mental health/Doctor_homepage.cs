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
    public partial class Doctor_homepage : Form
    {
        public Doctor_homepage()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
               login_option_form log1 = new login_option_form();
                this.Hide();
                log1.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void Doctor_homepage_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome," + doctor_login.username;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                login_option_form log1 = new login_option_form();
                this.Hide();
                log1.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Profileupdate_Doctor v = new Profileupdate_Doctor ();
                v.ShowDialog();

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
               User_chat2 no2 = new User_chat2();
                no2.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Doc_notice no = new Doc_notice();
                no.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Doctor_transaction2 no1 = new Doctor_transaction2();
                no1.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }
    }
}
