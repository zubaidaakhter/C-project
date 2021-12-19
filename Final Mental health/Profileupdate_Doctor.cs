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

    public partial class Profileupdate_Doctor : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
        public Profileupdate_Doctor()
        {
            InitializeComponent();
            BindGridView();
            ResetControl();
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
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
            pictureBox1.Image = Properties.Resources.download__5_;
         }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Doctor_homepage h = new Doctor_homepage();
                this.Hide();
                h.ShowDialog();
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
            string query = "select * from Mdoc1 where UserName=@UserName" ;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@UserName",doctor_login.username);


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
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[6].Value);
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {
                SqlConnection c = new SqlConnection(cs);
                c.Open();
                string queary = "update Mdoc1 set Docid=@Docid,Password=@Password,Special=@Special,Avalibe=@Avalibe,Charge=@Charge,Picture=@Picture where UserName=@UserName";
                SqlCommand cmd = new SqlCommand(queary, c);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Docid", textBox2.Text);
                cmd.Parameters.AddWithValue("@Password", textBox3.Text);
                cmd.Parameters.AddWithValue("@Special", textBox4.Text);
                cmd.Parameters.AddWithValue("@Avalibe", textBox5.Text);
                cmd.Parameters.AddWithValue("@Charge", textBox6.Text);
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
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                return ms.GetBuffer();
            }



    }
}
