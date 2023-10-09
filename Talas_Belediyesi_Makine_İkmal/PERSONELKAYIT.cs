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

namespace Talas_Belediyesi_Makine_İkmal
{
    public partial class FrmPersonelKayit : Form
    {
        public FrmPersonelKayit()
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        private void FrmPersonelKayit_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmGiris fr = new FrmGiris();
            fr.Show();
            this.Hide();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            //baglanti.Open();
            //SqlCommand komut = new SqlCommand("insert into Tbl_KullaniciGirisi (ADI,SOYADI,KULLANICIADI,SIFRE,GUVENLIKSORUSU,SORUNUNCEVABI) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);
            //komut.Parameters.AddWithValue("@p1", txtAdi.Text);
            //komut.Parameters.AddWithValue("@p2", txtSoyadi.Text);
            //komut.Parameters.AddWithValue("@p3", txtKullaniciAdi.Text);
            //komut.Parameters.AddWithValue("@p4", txtSifre.Text);
            //komut.Parameters.AddWithValue("@p5", cbxGuvenlikSorusu.Text);
            //komut.Parameters.AddWithValue("@p6", txtSorununCevabi.Text);
            //komut.ExecuteNonQuery();
            //baglanti.Close();
            //MessageBox.Show("Kullanıcı Bilgileri Kaydedildi", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Controls.Clear();
            //this.InitializeComponent();

            if (
                  txtAdi.Text == "" || txtSoyadi.Text == "" || txtKullaniciAdi.Text == "" || txtSifre.Text == "" || cbxGuvenlikSorusu.Text == "" || txtSorununCevabi.Text == "" ||
                  txtAdi.Text == String.Empty|| txtSoyadi.Text == String.Empty || txtKullaniciAdi.Text == String.Empty || txtSifre.Text == String.Empty || cbxGuvenlikSorusu.Text == String.Empty || txtSorununCevabi.Text == String.Empty
               )
            {
                txtAdi.BackColor = Color.Yellow;
                txtSoyadi.BackColor = Color.Yellow;
                txtKullaniciAdi.BackColor = Color.Yellow;
                txtSifre.BackColor = Color.Yellow;
                cbxGuvenlikSorusu.BackColor = Color.Yellow;
                txtSorununCevabi.BackColor = Color.Yellow;
                MessageBox.Show("Sarı Rekli Alanları Boş Geçemezsiniz", "Boş Alan Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(bgl.Adres);
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Tbl_KullaniciGirisi (ADI,SOYADI,KULLANICIADI,SIFRE,GUVENLIKSORUSU,SORUNUNCEVABI) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);
                komut.Parameters.AddWithValue("@p1", txtAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtSoyadi.Text);
                komut.Parameters.AddWithValue("@p3", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p4", txtSifre.Text);
                komut.Parameters.AddWithValue("@p5", cbxGuvenlikSorusu.Text);
                komut.Parameters.AddWithValue("@p6", txtSorununCevabi.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kullanıcı Bilgileri Kaydedildi", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Controls.Clear();
                this.InitializeComponent();
            }
        }
    }
}
