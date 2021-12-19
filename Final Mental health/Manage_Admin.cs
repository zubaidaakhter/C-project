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
    public partial class Manage_Admin : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
        public Manage_Admin()
        {
            InitializeComponent();
            ResetControl();
            BindGridView();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

            private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Admin_homepage ADD = new Admin_homepage();
                this.Hide();
                ADD.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(cs);
                c.Open();
                SqlCommand cmd = new SqlCommand("delete from MAdmin1 where  Userid=@Userid", c);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Userid", textBox2.Text);
                int a = cmd.ExecuteNonQuery();
                c.Close();
                if (a > 0)
                {
                    MessageBox.Show("Information deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridView();
                    ResetControl();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to delete Data", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select* from MAdmin1";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(cs);
                c.Open();
                SqlCommand cmd = new SqlCommand("Insert into MAdmin1 Values(@UserName,@Userid,@Password)", c);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Userid", textBox2.Text);
                cmd.Parameters.AddWithValue("@Password", textBox3.Text);
                
                int a = cmd.ExecuteNonQuery();
                c.Close();
                if (a > 0)
                {
                    MessageBox.Show("Information Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridView();
                    ResetControl();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Insert Data", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
