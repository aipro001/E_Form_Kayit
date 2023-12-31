﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Talas_Belediyesi_Makine_İkmal
{
    public partial class FrmAnaMenu : Form
    {
        public FrmAnaMenu()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEngelliArac_Click(object sender, EventArgs e)
        {
            FrmEngelliAracTamirBakimKaydiPaneli fr = new FrmEngelliAracTamirBakimKaydiPaneli();
            fr.Show();
            this.Close();
        }

        private void btnKayitliAramalar_Click(object sender, EventArgs e)
        {
            FrmKayitliAramalar fr = new FrmKayitliAramalar();
            fr.Show();
            this.Close();
        }

        private void btİstatistikler_Click(object sender, EventArgs e)
        {
            FrmAlınanMalzemelerListesi fr = new FrmAlınanMalzemelerListesi();
            fr.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void FrmAnaMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnPencereKucult_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FrmAnaMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
