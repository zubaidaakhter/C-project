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
    public partial class Ask_a_question : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;

        public Ask_a_question()
        {
            InitializeComponent();
            ResetControl();
            BindGridView();
        }

        private void Ask_a_question_Load(object sender, EventArgs e)
        {
            textBox2.Text = " " + User_chat2.answer;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
               user_homepage us3 = new user_homepage();
                this.Hide();
                us3.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = " " + User_chat2.answer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(cs);
                c.Open();
                SqlCommand cmd = new SqlCommand("Insert into Uask1 Values(@Question)", c);
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("@Question", textBox1.Text);
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

        private void button4_Click(object sender, EventArgs e)
        {
            ResetControl();
      
        }
        void ResetControl()
        {
            textBox1.Clear();
            
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select* from  Doc_ans1";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
