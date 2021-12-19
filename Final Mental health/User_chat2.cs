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
    public partial class User_chat2 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
        public static string answer;
        public User_chat2()
        {
            InitializeComponent();
            BindGridView();
            ResetControl();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Doctor_homepage u1 = new Doctor_homepage();
                this.Hide();
                u1.ShowDialog();
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
            string query = "select* from  Uask1";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(cs);
                c.Open();
                SqlCommand cmd = new SqlCommand("Insert into Doc_ans1 Values(@answer)", c);
                cmd.CommandType = CommandType.Text;
                 cmd.Parameters.AddWithValue("@answer", textBox2.Text);
                int a = cmd.ExecuteNonQuery();
                c.Close();
                if (a > 0)
                {
                    MessageBox.Show("Information Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Insert Data", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
        void ResetControl()
        {
            
            textBox2.Clear();
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(cs);
                c.Open();
                SqlCommand cmd = new SqlCommand("Insert into Doc_ans1 Values(@answer)", c);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@answer", textBox2.Text);
                int a = cmd.ExecuteNonQuery();
                c.Close();
                if (a > 0)
                {
                    MessageBox.Show("Information Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Insert Data", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
