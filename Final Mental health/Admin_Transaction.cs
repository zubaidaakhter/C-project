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
    public partial class Admin_Transaction : Form
    {
        public Admin_Transaction()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Admin_homepage use5 = new Admin_homepage();
                this.Hide();
                use5.ShowDialog();
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
                user_transaction t1 = new user_transaction();
                t1.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                this.Hide();
                Doctor_transaction  t2 = new Doctor_transaction();
                t2.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
