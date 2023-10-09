using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;

namespace Talas_Belediyesi_Makine_İkmal
{
    public partial class FrmAlınanMalzemelerListesi : Form
    {
        public FrmAlınanMalzemelerListesi()
        {
            InitializeComponent();
        }

        BaglantiSinifi bgl = new BaglantiSinifi();
        //SqlConnection baglanti = new SqlConnection(BaglantiClass.sqlconnection);
        //SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VDBH89Q\SQLEXPRESS;Initial Catalog=TalasMakineİkmal;Integrated Security=True");

        void Listele()
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select * From Tbl_Malzemeler", baglanti);
            SqlDataAdapter da1 = new SqlDataAdapter(komut1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        void Listele1()
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * From Tbl_Malzemeler", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAnaMenu fr = new FrmAnaMenu();
            fr.Show();
            this.Hide();
        }

        private void FrmAlınanMalzemelerListesi_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Tbl_Malzemeler ", baglanti);
            adtr.Fill(dt2);
            dataGridView2.DataSource = dt2;
            Listele();
            baglanti.Close();
            //dataGridView1.ColumnCount = 4;
            //dataGridView1.Columns[0].Name = "MALZEME ID";
            //dataGridView1.Columns[1].Name = "TARİH";
            //dataGridView1.Columns[2].Name = "MALZEME ADI";
            //dataGridView1.Columns[3].Name = "ADET";

            //dataGridView1.Rows.Add();
            //dataGridView1.Rows[0].Cells[0].Value = " "+txtID.Text;
            //dataGridView1.Rows[0].Cells[1].Value = " "+dTPTarih.Text;
            //dataGridView1.Rows[0].Cells[2].Value = " "+txtMalzemeAdi.Text;
            //dataGridView1.Rows[0].Cells[3].Value = " "+txtAdet.Text;

            //dataGridView1.Rows[1].Cells[0].Value = "Tasarım";
            //dataGridView1.Rows[1].Cells[1].Value = "Kodlama";
            //dataGridView1.Rows[1].Cells[2].Value = "75251212";
            //dataGridView1.Rows[1].Cells[3].Value = " ";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from Tbl_Malzemeler where MALZEMEID=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1", txtID.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Sistemden Silindi", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            baglanti.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Tbl_Malzemeler set TARIH=@P1, MALZEMEADI=@P2, ADET=@P3 WHERE MALZEMEID=@P4 ", baglanti);
            komut.Parameters.AddWithValue("@p1", dTPTarih.Text);
            komut.Parameters.AddWithValue("@p2", txtMalzemeAdi.Text);
            komut.Parameters.AddWithValue("@p3", txtAdet.Text);
            komut.Parameters.AddWithValue("@p4", txtID.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Sistem Güncellendi", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            baglanti.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //baglanti.Open();
            //SqlCommand komut = new SqlCommand("insert into Tbl_Malzemeler (TARIH,MALZEMEADI,ADET) VALUES (@P1,@P2,@P3)", baglanti);
            //komut.Parameters.AddWithValue("@p1", dTPTarih.Text);
            //komut.Parameters.AddWithValue("@p2", txtMalzemeAdi.Text);
            //komut.Parameters.AddWithValue("@p3", txtAdet.Text);
            //komut.ExecuteNonQuery();
            //baglanti.Close();
            //MessageBox.Show("Sisteme Kaydedildi","Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Listele();
            if (
                  dTPTarih.Text == "" || txtMalzemeAdi.Text == "" || txtAdet.Text == "" || 
                  dTPTarih.Text == String.Empty || txtMalzemeAdi.Text == String.Empty || txtAdet.Text == String.Empty 
               )
            {
                dTPTarih.BackColor = Color.Yellow;
                txtMalzemeAdi.BackColor = Color.Yellow;
                txtAdet.BackColor = Color.Yellow;                
                MessageBox.Show("Sarı Rekli Alanları Boş Geçemezsiniz", "Boş Alan Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(bgl.Adres);
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Tbl_Malzemeler (TARIH,MALZEMEADI,ADET) VALUES (@P1,@P2,@P3)", baglanti);
                komut.Parameters.AddWithValue("@p1", dTPTarih.Text);
                komut.Parameters.AddWithValue("@p2", txtMalzemeAdi.Text);
                komut.Parameters.AddWithValue("@p3", txtAdet.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Sisteme Kaydedildi", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            fitrele();
        }

        DataTable dt2 = new DataTable();

        DataView fitrele()
        {
            DataView dv = new DataView();
            dv = dt2.DefaultView;
            dv.RowFilter = "MALZEMEADI LIKE '" + txtAra.Text + "%'";
            return dv;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            dTPTarih.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMalzemeAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAdet.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            Listele();
            Listele1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEXCEL_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

                int StartCol = 1;
                int StartRow = 1;

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                }

                StartRow++;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                        myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.StackTrace);
            }

            //Excel.Application exceldosya = new Excel.Application();
            //exceldosya.Visible = true;
            //object Missing = Type.Missing;
            //Workbook malzemelistesi = exceldosya.Workbooks.Add(Missing);
            //Worksheet sheet1 = (Worksheet)malzemelistesi.Sheets[1];
            //int sutun = 1;
            //int satır = 1;

            //for (int j = 0; j < dataGridView3.Columns.Count; j++)
            //{
            //    Range myrange = (Range)sheet1.Cells[satır , sutun + j];
            //    myrange.Value2 = dataGridView3.Columns[j].HeaderText;
            //}
            //satır++;
            //for (int i = 0; i < dataGridView3.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dataGridView3.Rows.Count; j++)
            //    {
            //        Range myrange = (Range)sheet1.Cells[satır + i, sutun + j];
            //        myrange.Value2 = dataGridView3[j, i].Value == null ? "" : dataGridView3[j, i].Value;
            //        myrange.Select();
            //    }
            //}
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void FrmAlınanMalzemelerListesi_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
