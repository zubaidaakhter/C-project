using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Login_form
{
    
    public partial class registartion : Form
    {
        string cs= ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
       
        
        public registartion()
        {
            InitializeComponent();
        }
       
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(cs);
                c.Open();
                SqlCommand cmd = new SqlCommand("Insert into User1 Values(@UserName,@Password,@DOB,@Gender,@Email,@Medical,@Picture)", c);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserName", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                cmd.Parameters.AddWithValue("@DOB", textBox3.Text);
                cmd.Parameters.AddWithValue("@Gender", textBox4.Text);
                cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                cmd.Parameters.AddWithValue("@Medical", textBox6.Text);
                cmd.Parameters.AddWithValue("@Picture", SavePhoto());
                int a =cmd.ExecuteNonQuery();
                c.Close();
                if (a > 0)
                {
                    MessageBox.Show("Information Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    try
                    {
                        this.Hide();
                       Form1 a2 = new Form1();
                        a2.ShowDialog();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error!!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to Insert Data", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Form1 f = new Form1();
                this.Hide();
                f.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }

        private void registartion_Load(object sender, EventArgs e)
        {

        }
    }
   
}

