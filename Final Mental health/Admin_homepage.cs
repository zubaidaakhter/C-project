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
    public partial class Admin_homepage : Form
    {
        public Admin_homepage()
        {
            InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                login_option_form a = new login_option_form ();
                this.Hide();
                a.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                MDoctor q = new MDoctor();
                q.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                login_option_form a = new login_option_form();
                this.Hide();
                a.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void Admin_homepage_Load(object sender, EventArgs e)
        {
            label2.Text = "Welcome," + Admin_login.username;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Manage_User m = new Manage_User();
                m.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
               MDoctor m = new MDoctor();
                m.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                this.Close();
                login_option_form a = new login_option_form();
                this.Hide();
                a.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {

                this.Hide();
                Manage_User u = new Manage_User();
                u.ShowDialog();

            }
            catch(Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                MDoctor o = new MDoctor();
                o.ShowDialog();
            }
            catch(Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                this.Hide();
                Admin_notice n = new Admin_notice();
                n.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            try
            {

                this.Hide();
                Admin_Transaction t = new Admin_Transaction();
                t.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Manage_Admin o1 = new Manage_Admin();
                o1.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                check_feedback f = new check_feedback();
                f.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
