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
    public partial class Information_page : Form
    {
        public Information_page()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                user_homepage op2 = new user_homepage();
                this.Hide();
                op2.ShowDialog();
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
                anxiety a1 = new anxiety();
                a1.ShowDialog();

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
                Stress a2 = new Stress();
                a2.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                OCD a8 = new OCD();
                a8.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void Information_page_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                depration_info a3 = new depration_info();
                a3.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Eating_Disorder a4 = new Eating_Disorder();
                a4.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                panicAttack a5 = new panicAttack();
                a5.ShowDialog();

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
                this.Hide();
                Anger a6 = new Anger();
                a6.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                PTSD a7 = new PTSD();
                a7.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                ADHD a9 = new ADHD();
                a9.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }
    }
}

