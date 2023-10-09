using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Office.Interop.Excel;
using QRCoder;

namespace Talas_Belediyesi_Makine_İkmal
{
    public partial class FrmEngelliAracTamirBakimKaydiPaneli : Form
    {
        public FrmEngelliAracTamirBakimKaydiPaneli()
        {
            InitializeComponent();
        }

        BaglantiSinifi bgl = new BaglantiSinifi();
        //SqlConnection baglanti = new SqlConnection(BaglantiClass.sqlconnection);
        //SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VDBH89Q\SQLEXPRESS;Initial Catalog=TalasMakineİkmal;Integrated Security=True");

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

        

        private void FrmEngelliAracTamirBakimKaydiPaneli_Load(object sender, EventArgs e)
        {
           
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //baglanti.Open();
            //SqlCommand komut = new SqlCommand("insert into Tbl_EngelliAraciTamirBakimFormu (BASVURUTARIHI,TESLIMTARIHI," +
            //                                  "ADI,SOYADI,TCNO,TELNO,ENGELORANIVEDURUMU,MESLEKVECALISMADURUMU,ILCE,ADRES,ARACMARKAVEMODEL," +
            //                                  "AKUSARJCIHAZIMARKAVEMODEL,ENGELLIARACDURUM,ARACITESLIMEDENINADISOYADI,ARACITESLIMALANINADISOYADI," +
            //                                  "BAKIMONARIMISLEMLERI,KULLANILANMALZEMENINADI,MALZEMENINALINDIGITARIH,ADET) " +
            //                                  "VALUES (@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17,@P18,@P19,@P20)", baglanti);
            //komut.Parameters.AddWithValue("@p2", dTPBasvuruTarihi.Text);
            //komut.Parameters.AddWithValue("@p3", dTPTeslimTarihi.Text);
            //komut.Parameters.AddWithValue("@p4", txtAdi.Text);
            //komut.Parameters.AddWithValue("@p5", txtSoyadi.Text);
            //komut.Parameters.AddWithValue("@p6", msktxtTCNO.Text);
            //komut.Parameters.AddWithValue("@p7", msktxtTELNO.Text);
            //komut.Parameters.AddWithValue("@p8", txtEngelOrani.Text);
            //komut.Parameters.AddWithValue("@p9", txtMeslekCalismaDurumu.Text);
            //komut.Parameters.AddWithValue("@p10", cbxIlce.Text);
            //komut.Parameters.AddWithValue("@p11", rchtxtAdres.Text);
            //komut.Parameters.AddWithValue("@p12", txtAracMarkaModel.Text);
            //komut.Parameters.AddWithValue("@p13", txtAkuSarjCihaziMarkaModel.Text);
            //komut.Parameters.AddWithValue("@p14", rchtxtEngelliAracDurum.Text);
            //komut.Parameters.AddWithValue("@p15", txtAraciTeslimEden.Text);
            //komut.Parameters.AddWithValue("@p16", txtAraciTeslimAlan.Text);
            //komut.Parameters.AddWithValue("@p17", rchtxtBakimOnarimIslemleri.Text);
            //komut.Parameters.AddWithValue("@p18", rchtxtKullanilanMalzemeler.Text);
            //komut.Parameters.AddWithValue("@p19", dTPMalzemeTarihi.Text);
            //komut.Parameters.AddWithValue("@p20", txtAdet.Text);
            //komut.ExecuteNonQuery();
            //baglanti.Close();
            //MessageBox.Show("Sisteme Kaydedildi ve QR Kod Oluşturuldu","Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //baglanti.Open();
            //SqlCommand komut1 = new SqlCommand("insert into Tbl_Malzemeler (MALZEMEADI,TARIH,ADET) VALUES (@P1,@P2,@P3)", baglanti);
            //komut1.Parameters.AddWithValue("@p1", rchtxtKullanilanMalzemeler.Text);
            //komut1.Parameters.AddWithValue("@p2", dTPMalzemeTarihi.Text);
            //komut1.Parameters.AddWithValue("@p3", txtAdet.Text);
            //komut1.ExecuteNonQuery();
            //baglanti.Close();

            //string str = "  - ID No: " + txtID.Text + " \n " + " - Adı: " + txtAdi.Text + " \n " + " - Soyadı: " + txtSoyadi.Text + " \n " + " - TC No: " + msktxtTCNO.Text + " \n " + " - Tel No: " + msktxtTELNO.Text + " \n " + " - Engel Oranı: " + txtEngelOrani.Text + " \n " + " - Meslek ve Çalışma Durumu: " + txtMeslekCalismaDurumu.Text + " \n " + " - İlçe:" + cbxIlce.Text + " \n " + " - Adres: " + rchtxtAdres.Text + " \n " + " - Aracın Marka ve Modeli: " + txtAracMarkaModel.Text + " \n " + " - Akü Şarj Cihazı Marka ve Modeli: " + txtAkuSarjCihaziMarkaModel.Text + " \n " + " - Engelli Araç Durumu: " + rchtxtEngelliAracDurum.Text + " \n " + " - Aracı Teslim Eden: " + txtAraciTeslimEden.Text + " \n " + " - Aracı Teslim Alan: " + txtAraciTeslimAlan.Text + " \n " + " - Bakım Onarım İşlemleri: " + rchtxtBakimOnarimIslemleri.Text + " \n " + " - Kullanılan Malzemenin Adı: " + rchtxtKullanilanMalzemeler.Text + " \n " + " - Malzemenin Alındığı Tarih: " + dTPMalzemeTarihi.Text + " \n " + " - Adet: " + txtAdet.Text;
            //QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //QRCodeData qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q);
            //QRCode qrCode = new QRCode(qrCodeData);
            //Bitmap qrCodeImage = qrCode.GetGraphic(20);
            //pictureBox6.Image = qrCodeImage;

            //SaveFileDialog sfd = new SaveFileDialog();//yeni bir kaydetme diyaloğu oluşturuyoruz.
            //sfd.Filter = "jpeg dosyası(*.jpg)|*.jpg|Bitmap(*.bmp)|*.bmp";//.bmp veya .jpg olarak kayıt imkanı sağlıyoruz.
            //sfd.Title = "qrCodeImage";//diğaloğumuzun başlığını belirliyoruz.
            //sfd.FileName = "QR COD";//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.
            //DialogResult sonuç = sfd.ShowDialog();
            //if (sonuç == DialogResult.OK)
            //{
            //    pictureBox6.Image.Save(sfd.FileName);//Böylelikle resmi istediğimiz yere kaydediyoruz.
            //}

            if (
                  dTPBasvuruTarihi.Text == "" || txtAdi.Text == "" || txtSoyadi.Text == "" || msktxtTCNO.Text == "" || msktxtTELNO.Text == "" || txtEngelOrani.Text == "" || txtMeslekCalismaDurumu.Text == "" || cbxIlce.Text == "" || rchtxtAdres.Text == "" || txtAracMarkaModel.Text == "" || txtAkuSarjCihaziMarkaModel.Text == "" || rchtxtEngelliAracDurum.Text == "" || txtAraciTeslimEden.Text == "" || txtAraciTeslimAlan.Text == "" || rchtxtBakimOnarimIslemleri.Text == "" || rchtxtKullanilanMalzemeler.Text == "" || dTPMalzemeTarihi.Text == "" || txtAdet.Text == "" ||
                  dTPBasvuruTarihi.Text == string.Empty || txtAdi.Text == string.Empty || txtSoyadi.Text == string.Empty || msktxtTCNO.Text == string.Empty || msktxtTELNO.Text == string.Empty || txtEngelOrani.Text == string.Empty || txtMeslekCalismaDurumu.Text == string.Empty || cbxIlce.Text == string.Empty || rchtxtAdres.Text == string.Empty || txtAracMarkaModel.Text == string.Empty || txtAkuSarjCihaziMarkaModel.Text == string.Empty || rchtxtEngelliAracDurum.Text == string.Empty || txtAraciTeslimEden.Text == string.Empty || txtAraciTeslimAlan.Text == string.Empty || rchtxtBakimOnarimIslemleri.Text == string.Empty || rchtxtKullanilanMalzemeler.Text == string.Empty || dTPMalzemeTarihi.Text == string.Empty || txtAdet.Text == string.Empty 
               )
            {
                dTPBasvuruTarihi.BackColor = Color.Yellow;
                txtAdi.BackColor = Color.Yellow;
                txtSoyadi.BackColor = Color.Yellow;
                msktxtTCNO.BackColor = Color.Yellow;
                msktxtTELNO.BackColor = Color.Yellow;
                txtEngelOrani.BackColor = Color.Yellow;
                txtMeslekCalismaDurumu.BackColor = Color.Yellow;
                cbxIlce.BackColor = Color.Yellow;
                rchtxtAdres.BackColor = Color.Yellow;
                txtAracMarkaModel.BackColor = Color.Yellow;
                txtAkuSarjCihaziMarkaModel.BackColor = Color.Yellow;
                rchtxtEngelliAracDurum.BackColor = Color.Yellow;
                txtAraciTeslimEden.BackColor = Color.Yellow;
                txtAraciTeslimAlan.BackColor = Color.Yellow;
                rchtxtBakimOnarimIslemleri.BackColor = Color.Yellow;
                rchtxtKullanilanMalzemeler.BackColor = Color.Yellow;
                dTPMalzemeTarihi.BackColor = Color.Yellow;
                txtAdet.BackColor = Color.Yellow;
                MessageBox.Show("Sarı Rekli Alanları Boş Geçemezsiniz", "Boş Alan Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(bgl.Adres);
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Tbl_EngelliAraciTamirBakimFormu (BASVURUTARIHI,TESLIMTARIHI," +
                                                  "ADI,SOYADI,TCNO,TELNO,ENGELORANIVEDURUMU,MESLEKVECALISMADURUMU,ILCE,ADRES,ARACMARKAVEMODEL," +
                                                  "AKUSARJCIHAZIMARKAVEMODEL,ENGELLIARACDURUM,ARACITESLIMEDENINADISOYADI,ARACITESLIMALANINADISOYADI," +
                                                  "BAKIMONARIMISLEMLERI,KULLANILANMALZEMENINADI,MALZEMENINALINDIGITARIH,ADET) " +
                                                  "VALUES (@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17,@P18,@P19,@P20)", baglanti);
                komut.Parameters.AddWithValue("@p2", dTPBasvuruTarihi.Text);
                komut.Parameters.AddWithValue("@p3", dTPTeslimTarihi.Text);
                komut.Parameters.AddWithValue("@p4", txtAdi.Text);
                komut.Parameters.AddWithValue("@p5", txtSoyadi.Text);
                komut.Parameters.AddWithValue("@p6", msktxtTCNO.Text);
                komut.Parameters.AddWithValue("@p7", msktxtTELNO.Text);
                komut.Parameters.AddWithValue("@p8", txtEngelOrani.Text);
                komut.Parameters.AddWithValue("@p9", txtMeslekCalismaDurumu.Text);
                komut.Parameters.AddWithValue("@p10", cbxIlce.Text);
                komut.Parameters.AddWithValue("@p11", rchtxtAdres.Text);
                komut.Parameters.AddWithValue("@p12", txtAracMarkaModel.Text);
                komut.Parameters.AddWithValue("@p13", txtAkuSarjCihaziMarkaModel.Text);
                komut.Parameters.AddWithValue("@p14", rchtxtEngelliAracDurum.Text);
                komut.Parameters.AddWithValue("@p15", txtAraciTeslimEden.Text);
                komut.Parameters.AddWithValue("@p16", txtAraciTeslimAlan.Text);
                komut.Parameters.AddWithValue("@p17", rchtxtBakimOnarimIslemleri.Text);
                komut.Parameters.AddWithValue("@p18", rchtxtKullanilanMalzemeler.Text);
                komut.Parameters.AddWithValue("@p19", dTPMalzemeTarihi.Text);
                komut.Parameters.AddWithValue("@p20", txtAdet.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Sisteme Kaydedildi ve QR Kod Oluşturuldu", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);

                baglanti.Open();
                SqlCommand komut1 = new SqlCommand("insert into Tbl_Malzemeler (MALZEMEADI,TARIH,ADET) VALUES (@P1,@P2,@P3)", baglanti);
                komut1.Parameters.AddWithValue("@p1", rchtxtKullanilanMalzemeler.Text);
                komut1.Parameters.AddWithValue("@p2", dTPMalzemeTarihi.Text);
                komut1.Parameters.AddWithValue("@p3", txtAdet.Text);
                komut1.ExecuteNonQuery();
                baglanti.Close();

                string str = "  - ID No: " + txtID.Text + " \n " + " - Adı: " + txtAdi.Text + " \n " + " - Soyadı: " + txtSoyadi.Text + " \n " + " - TC No: " + msktxtTCNO.Text + " \n " + " - Tel No: " + msktxtTELNO.Text + " \n " + " - Engel Oranı: " + txtEngelOrani.Text + " \n " + " - Meslek ve Çalışma Durumu: " + txtMeslekCalismaDurumu.Text + " \n " + " - İlçe:" + cbxIlce.Text + " \n " + " - Adres: " + rchtxtAdres.Text + " \n " + " - Aracın Marka ve Modeli: " + txtAracMarkaModel.Text + " \n " + " - Akü Şarj Cihazı Marka ve Modeli: " + txtAkuSarjCihaziMarkaModel.Text + " \n " + " - Engelli Araç Durumu: " + rchtxtEngelliAracDurum.Text + " \n " + " - Aracı Teslim Eden: " + txtAraciTeslimEden.Text + " \n " + " - Aracı Teslim Alan: " + txtAraciTeslimAlan.Text + " \n " + " - Bakım Onarım İşlemleri: " + rchtxtBakimOnarimIslemleri.Text + " \n " + " - Kullanılan Malzemenin Adı: " + rchtxtKullanilanMalzemeler.Text + " \n " + " - Malzemenin Alındığı Tarih: " + dTPMalzemeTarihi.Text + " \n " + " - Adet: " + txtAdet.Text;
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                pictureBox6.Image = qrCodeImage;

                SaveFileDialog sfd = new SaveFileDialog();//yeni bir kaydetme diyaloğu oluşturuyoruz.
                sfd.Filter = "jpeg dosyası(*.jpg)|*.jpg|Bitmap(*.bmp)|*.bmp";//.bmp veya .jpg olarak kayıt imkanı sağlıyoruz.
                sfd.Title = "qrCodeImage";//diğaloğumuzun başlığını belirliyoruz.
                sfd.FileName = "QR COD";//kaydedilen resmimizin adını 'resim' olarak belirliyoruz.
                DialogResult sonuç = sfd.ShowDialog();
                if (sonuç == DialogResult.OK)
                {
                    pictureBox6.Image.Save(sfd.FileName);//Böylelikle resmi istediğimiz yere kaydediyoruz.
                }
            }
        }
                
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void btnPencereBuyult_Click(object sender, EventArgs e)
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

        private void FrmEngelliAracTamirBakimKaydiPaneli_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //string dosyaadi, dosyayolu;
        //StreamWriter sr;
        //private void btnYolSec_Click(object sender, EventArgs e)
        //{
        //    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        dosyayolu = folderBrowserDialog1.SelectedPath.ToString();
        //        txtExcelAdi.Text = dosyayolu;
        //        txtPdfAdi.Text = dosyayolu;
        //    }

        //    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        dosyayolu = folderBrowserDialog1.SelectedPath.ToString();
        //        txtPdfAdi.Text = dosyayolu;
        //    }
        //}
    }    
}


