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
using System.Security;
using System.Net.Mail;
using System.Net;
using System.Windows.Controls;

namespace Talas_Belediyesi_Makine_İkmal
{
    public partial class FrmSifremiUnuttum : Form
    {
        public FrmSifremiUnuttum()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
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

        private void FrmSifremiUnuttum_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmSifremiUnuttum_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGiris fr = new FrmGiris();
            fr.Show();
            this.Hide();
        }

        private void btnYeniSifre_Click(object sender, EventArgs e)
        {
            //baglanti.Open();
            //SqlCommand komut = new SqlCommand("update Tbl_KullaniciGirisi set KULLANICIADI=@P1, SIFRE=@P2, ADI=@P3, SOYADI=@P4, GUVENLIKSORUSU=@P5, SORUNUNCEVABI=@P6 WHERE ID=@P6", baglanti);
            //komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            //komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            //komut.Parameters.AddWithValue("@p3", txtAdi.Text);
            //komut.Parameters.AddWithValue("@p4", txtSoyadi.Text);
            //komut.Parameters.AddWithValue("@p5", cbxGuvenliSorusu.Text);
            //komut.Parameters.AddWithValue("@p6", txtSorununCevabi.Text);
            //komut.Parameters.AddWithValue("@p7", txtID.Text);
            //komut.ExecuteNonQuery();            
            //MessageBox.Show("Kullanıcı Bilgileri Güncellendi","Güncelleme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //baglanti.Close();
            //this.Controls.Clear();
            //this.InitializeComponent();

            if (
                  txtKullaniciAdi.Text == "" || txtSifre.Text == "" || txtAdi.Text == "" || txtSoyadi.Text == "" || cbxGuvenliSorusu.Text == "" || txtID.Text == "" ||
                  txtKullaniciAdi.Text == String.Empty || txtSifre.Text == String.Empty || txtAdi.Text == String.Empty || txtSoyadi.Text == String.Empty || cbxGuvenliSorusu.Text == String.Empty || txtID.Text == String.Empty
               )
            {
                txtKullaniciAdi.BackColor = Color.Yellow;
                txtSifre.BackColor = Color.Yellow;
                txtAdi.BackColor = Color.Yellow;
                txtSoyadi.BackColor = Color.Yellow;
                cbxGuvenliSorusu.BackColor = Color.Yellow;
                txtSorununCevabi.BackColor = Color.Yellow;
                txtID.BackColor = Color.Yellow;
                MessageBox.Show("Sarı Rekli Alanları Boş Geçemezsiniz", "Boş Alan Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(bgl.Adres);
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Tbl_KullaniciGirisi set KULLANICIADI=@P1, SIFRE=@P2, ADI=@P3, SOYADI=@P4, GUVENLIKSORUSU=@P5, SORUNUNCEVABI=@P6 WHERE ID=@P7", baglanti);
                komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                komut.Parameters.AddWithValue("@p3", txtAdi.Text);
                komut.Parameters.AddWithValue("@p4", txtSoyadi.Text);
                komut.Parameters.AddWithValue("@p5", cbxGuvenliSorusu.Text);
                komut.Parameters.AddWithValue("@p6", txtSorununCevabi.Text);
                komut.Parameters.AddWithValue("@p7", txtID.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Bilgileri Güncellendi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglanti.Close();
                this.Controls.Clear();
                this.InitializeComponent();
            }
        }
        
            
    }
}
