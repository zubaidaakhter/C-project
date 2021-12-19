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
    public partial class Eating_Disorder : Form
    {
        public Eating_Disorder()
        {
            InitializeComponent();
        }

        private void Eating_Disorder_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Information_page op4 = new Information_page();
                this.Hide();
                op4.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }
    }
}
