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
using System.IO;

namespace Login_form
{
    public partial class Manage_User : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
        public Manage_User()
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
                Admin_homepage add = new Admin_homepage();
                this.Hide();
                add.ShowDialog();
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
            string query = "select* from User1";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[6];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 100;


        }
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(cs);
                c.Open();
                SqlCommand cmd = new SqlCommand("delete from User1 where  UserName=@UserName", c);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
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

        private void button4_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            pictureBox2.Image = Properties.Resources.download__5_;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            pictureBox2.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[6].Value);
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);

        }
    }
}
