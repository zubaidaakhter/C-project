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
    public partial class User_Notice : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
        public User_Notice()
        {
            InitializeComponent();
            BindGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void User_Notice_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                user_homepage ho2 = new user_homepage();
                this.Hide();
                ho2.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }

        }
            void BindGridView()
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select* from ANotice1";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);

                DataTable data = new DataTable();
                sda.Fill(data);
                dataGridView1.DataSource = data;
            }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
