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
    public partial class starting_page_1 : Form
    {
        public starting_page_1()
        {
            InitializeComponent();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            startpoint += 1;
            loading.Value = startpoint;
            if (loading.Value == 90)
            {
                loading.Value = 0;
                timer1.Stop();
                login_option_form f = new login_option_form();
                this.Hide();
                f.Show();
            }
        }

        private void starting_page_1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loading_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
