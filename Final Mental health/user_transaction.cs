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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Login_form
{
    public partial class user_transaction : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
        

        public user_transaction()
        {
            InitializeComponent();
            BindGridView1();
            BindGridView2();
        }
        public void exportgridtopdf(DataGridView dgw,string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            foreach(DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            foreach(DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)

                {
                   pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";
            if(savefiledialoge.ShowDialog()==DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }
           void BindGridView1()
           {
            SqlConnection con = new SqlConnection(cs);
            string query = "select* from card1";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;

        }
        void BindGridView2()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select* from online1";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView2.DataSource = data;
            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns[2].Visible = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            exportgridtopdf(dataGridView1, "User transaction card ");
            exportgridtopdf(dataGridView2,"User transaction online");
        }

        private void user_transaction_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Admin_homepage use4= new Admin_homepage();
                this.Hide();
                use4.ShowDialog();
                Application.Exit();


            }
            catch (Exception)
            {
                MessageBox.Show("error");

            }
        }
    }
    
}
    

