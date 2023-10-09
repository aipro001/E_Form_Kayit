using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Windows.Controls;
using System.Runtime.InteropServices;

namespace Talas_Belediyesi_Makine_İkmal
{
    public partial class FrmKayitliAramalar : Form
    {
        public FrmKayitliAramalar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        BaglantiSinifi bgl = new BaglantiSinifi();
        //SqlConnection baglanti = new SqlConnection(BaglantiClass.sqlconnection);
        //SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VDBH89Q\SQLEXPRESS;Initial Catalog=TalasMakineİkmal;Integrated Security=True");

        void Listele()
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_EngelliAraciTamirBakimFormu", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAnaMenu fr = new FrmAnaMenu();
            fr.Show();
            this.Hide();
        }

        private void FrmKayitliAramalar_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * From Tbl_EngelliAraciTamirBakimFormu ", baglanti);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
      
        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from Tbl_EngelliAraciTamirBakimFormu where KIMLIKID=@P1", baglanti);
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
            SqlCommand komut = new SqlCommand("update Tbl_EngelliAraciTamirBakimFormu set BASVURUTARIHI=@P1, TESLIMTARIHI=@P2, ADI=@P3, SOYADI=@P4, TCNO=@P5, TELNO=@P6, ENGELORANIVEDURUMU=@P7, MESLEKVECALISMADURUMU=@P8,ILCE=@P9, ADRES=@P10, ARACMARKAVEMODEL=@P11, AKUSARJCIHAZIMARKAVEMODEL=@P12, ENGELLIARACDURUM=@P13, ARACITESLIMEDENINADISOYADI=@P14, ARACITESLIMALANINADISOYADI=@P15, BAKIMONARIMISLEMLERI=@P16, KULLANILANMALZEMENINADI=@P17, MALZEMENINALINDIGITARIH = @P18, ADET=@P19 WHERE KIMLIKID=@P20", baglanti);           
            komut.Parameters.AddWithValue("@p1", dTPBasvuruTarihi.Text);
            komut.Parameters.AddWithValue("@p2", dTPTeslimTarihi.Text);
            komut.Parameters.AddWithValue("@p3", txtAdi.Text);
            komut.Parameters.AddWithValue("@p4", txtSoyadi.Text);
            komut.Parameters.AddWithValue("@p5", msktxtTCNO.Text);
            komut.Parameters.AddWithValue("@p6", msktxtTELNO.Text);
            komut.Parameters.AddWithValue("@p7", txtEngelOrani.Text);
            komut.Parameters.AddWithValue("@p8", txtMeslekCalismaDurumu.Text);
            komut.Parameters.AddWithValue("@p9", cbxIlce.Text);
            komut.Parameters.AddWithValue("@p10", rchtxtAdres.Text);
            komut.Parameters.AddWithValue("@p11", txtAracMarkaModel.Text);
            komut.Parameters.AddWithValue("@p12", txtAkuSarjCihaziMarkaModel.Text);
            komut.Parameters.AddWithValue("@p13", rchtxtEngelliAracDurum.Text);
            komut.Parameters.AddWithValue("@p14", txtAraciTeslimEden.Text);
            komut.Parameters.AddWithValue("@p15", txtAraciTeslimAlan.Text);
            komut.Parameters.AddWithValue("@p16", rchtxtBakimOnarimIslemleri.Text);
            komut.Parameters.AddWithValue("@p17", rchtxtKullanilanMalzemeler.Text);
            komut.Parameters.AddWithValue("@p18", dTPMalzemeTarihi.Text);
            komut.Parameters.AddWithValue("@p19", txtADET.Text);
            komut.Parameters.AddWithValue("@p20", txtID.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Sistem Güncellendi", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fitrele();
        }

        System.Data.DataTable dt = new System.Data.DataTable();

        DataView fitrele()
        {
            DataView dv = new DataView();
            dv = dt.DefaultView;
            dv.RowFilter = "ADI LIKE '" + txtAra.Text + "%'";
            return dv;
        }
      
        private void ExportToExcel(DataGridView dataGridView)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Visible = true;

            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);

            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                sheet1.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    sheet1.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }

            

            //workbook.SaveAs("D:\\ornek.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true, Type.Missing, Type.Missing);

            //workbook.Close();

            //excel.Quit();
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
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPencereKucult_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void FrmKayitliAramalar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            dTPBasvuruTarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dTPTeslimTarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSoyadi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            msktxtTCNO.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            msktxtTELNO.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtEngelOrani.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtMeslekCalismaDurumu.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            cbxIlce.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            rchtxtAdres.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtAracMarkaModel.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtAkuSarjCihaziMarkaModel.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            rchtxtEngelliAracDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            txtAraciTeslimEden.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
            txtAraciTeslimAlan.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            rchtxtBakimOnarimIslemleri.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
            rchtxtKullanilanMalzemeler.Text = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
            dTPMalzemeTarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
            txtADET.Text = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
        }
    }
}
//Data Source=DESKTOP-VDBH89Q\SQLEXPRESS;Initial Catalog=TalasMakineİkmal;Integrated Security=True