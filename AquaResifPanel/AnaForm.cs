using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquaResifPanel
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }
        User user = new User();
        private void AnaForm_Load(object sender, EventArgs e)
        {

            /*
                        kulId: 1,
                           kulAdi: 'Boz',
                           kulAdSoyad: 'Burak Boz',
                           kulSifre: '1234',
                           kulTip: 'Admin*/
            user.setUserId(Convert.ToInt32(Form1.userInfo[0]));
            user.setUserName(Form1.userInfo[1]);
            user.setUserNS(Form1.userInfo[2]);
            user.setUserPass(Form1.userInfo[3]);
            user.setUserType(Form1.userInfo[4]);

            lblKullanici.Text = user.getUserNS();

            if (user.getUserType() == "Admin")
            {
                pcbYeniSiparis.Visible = false;
            }
            else if (user.getUserType() == "Yönetici")
            {
                pcbYeniSiparis.Visible = false;
            }
            else if (user.getUserType() == "Personel")
            {
                pcbYeniSiparis.Visible = false;
            }
            else if (user.getUserType() == "İmalat")
            {
                btnKatMain.Visible = false;
                btnStandartTeklif.Visible = false;
                btnUrunMain.Visible = false;
                button1.Visible = false;
                btnOzelTeklif.Visible = false;
                btnTumSiparisler.Visible = false;
                
            }
            //MessageBox.Show(user.getUserId().ToString() + " " + user.getUserName() + " " + user.getUserNS() + " " + user.getUserPass() + " " + user.getUserType());
        }

        private void AnaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnKatMain_Click(object sender, EventArgs e)
        {
            KategoriForm katForm = new KategoriForm();
            katForm.Show();
        }

        private void btnUrunMain_Click(object sender, EventArgs e)
        {
            UrunlerForm urunlerForm = new UrunlerForm();
            urunlerForm.Show();
        }

        private void btnStandartTeklif_Click(object sender, EventArgs e)
        {
            StandartTeklifForm standartTeklifForm = new StandartTeklifForm();
            standartTeklifForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tekliflerFormu teklifFormu = new tekliflerFormu();
            teklifFormu.Show();
        }

        private void btnSiparisGoruntule_Click(object sender, EventArgs e)
        {
            siparisGoruntuleForm siparisGoruntule = new siparisGoruntuleForm();
            siparisGoruntule.Show();
            pcbYeniSiparis.Visible = false;

        }

        private void pcbYeniSiparis_Click(object sender, EventArgs e)
        {
            siparisGoruntuleForm siparisGoruntule = new siparisGoruntuleForm();
            siparisGoruntule.Show();
            pcbYeniSiparis.Visible = false;
        }

        private void btnTumSiparisler_Click(object sender, EventArgs e)
        {

        }

        private void btnSiparisOlustur_Click(object sender, EventArgs e)
        {
            siparisOlusturFormu sOlustur = new siparisOlusturFormu();
            sOlustur.Show();
        }
    }
}
