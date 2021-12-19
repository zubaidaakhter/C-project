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
    public partial class doctor_registration : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
        public doctor_registration()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void doctor_registration_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(cs);
                c.Open();
                SqlCommand cmd = new SqlCommand("Insert into Mdoc1 Values(@UserName,@Docid,@Password,@Special,@Avalibe,@Charge,@Picture)", c);
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
                    MessageBox.Show("Information Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        this.Hide();
                        doctor_login a3 = new doctor_login();
                        a3.ShowDialog();

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

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                doctor_login a3 = new doctor_login();
                this.Hide();
                a3.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }
    }
}

