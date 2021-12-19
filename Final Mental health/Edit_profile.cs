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
    public partial class Edit_profile : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
        public Edit_profile()
        {
            InitializeComponent();
            ResetControl();
            BindGridView();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select picture";
            ofd.Filter = "PNG file (*.png)|*.png";
            ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);

            }
        }

        

        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(cs);
                c.Open();
                string queary = "update User1 set Password=@Password,DOB=@DOB,Gender=@Gender,Email=@Email,Medical=@Medical,Picture=@Picture where UserName=@UserName";
                SqlCommand cmd = new SqlCommand(queary, c);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserName", textBox12.Text);
                cmd.Parameters.AddWithValue("@Password", textBox11.Text);
                cmd.Parameters.AddWithValue("@DOB", textBox10.Text);
                cmd.Parameters.AddWithValue("@Gender", textBox9.Text);
                cmd.Parameters.AddWithValue("@Email", textBox8.Text);
                cmd.Parameters.AddWithValue("@Medical", textBox7.Text);
                cmd.Parameters.AddWithValue("@Picture", SavePhoto());
                int a = cmd.ExecuteNonQuery();
                c.Close();


                if (a > 0)
                {
                    MessageBox.Show("Information updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridView();
                    ResetControl();
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Unable to update Data", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private object SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox3.Image.Save(ms, pictureBox3.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetControl();
        }
        void ResetControl()
        {
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox7.Clear();
            pictureBox3.Image = Properties.Resources.download__5_;
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from User1 where UserName=@UserName";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@UserName", Form1.username);


            DataTable dataTable = new DataTable();

            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            dataTable.Load(sqlDataReader);

            dataGridView1.DataSource = dataTable;
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[6];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 100;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                user_homepage use = new user_homepage();
                this.Hide();
                use.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox12.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox11.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            pictureBox3.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[6].Value);
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                User_Membership n3 = new User_Membership();
                n3.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }
    }
}


