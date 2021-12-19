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
    public partial class login_option_form : Form
    {
        public login_option_form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
                {
                this.Hide();
               Form1 f  = new Form1();
                f.ShowDialog();

            }
            catch(Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Admin_login a = new Admin_login();
                a.ShowDialog();

            }
            catch(Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                doctor_login d = new doctor_login();
                d.ShowDialog();
            }
            catch(Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void login_option_form_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
