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
    public partial class Panic_Attacks : Form
    {
        public Panic_Attacks()
        {
            InitializeComponent();
        }

        private void Panic_Attacks_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Information_page op5 = new Information_page();
                this.Hide();
                op5.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }
    }
}
