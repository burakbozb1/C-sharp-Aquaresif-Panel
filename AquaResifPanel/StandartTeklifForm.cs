using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;

namespace AquaResifPanel
{
    public partial class StandartTeklifForm : Form
    {
        Excel.Application excelDosya;

        User user = new User();
        string tumKategoriler, selectedCat;
        int selectedId;
        ListViewItem eklenecekUrun;
        string[] eklenecekUrunVeriler;

        string tekliftenCikanId;

        string tumUrunler;

        DataTable dtListelenenUrunler = new DataTable();
        DataTable dtSecilenUrunler = new DataTable();

        string akvaryumAciklama;
        string teklifKonu, musteri, ilgiliKisi, email, gsm, teslimYeri, teslimSuresi, teklifNo, teklifHazirlayan, odemeSekli;
        int konsolX, konsolY, konsolZ;
        double boy, en, yukseklik;
        double camKalinligi, hacim, camAgirligi;

        double kayitGenisligi = 8.00;

        double mobBoy, mobYukseklik, mobEn, mobToplamAlan, tacYuksekligi, mobBoyIcAlan, mobEnIcAlan, mobArkalik, tacToplamAlan;
        string mobilyaTuru;

        int mobilyaBirimFiyat, kapakSayisi;
        double buyukYanAlan, ufakYanAlan, tabanCamiAlan, kayitlar, fireAlan, toplamAlan, mobilyaToplamFiyat, arkalikFiyat;

        double mobilyaGenelFiyat = 0.00;
        int formGenislik, formYukseklik;

        string yeniTeklifNo = "";
        private void btnMobilyaEkle_Click(object sender, EventArgs e)
        {
            try
            {
                mobilyaHesapla();
                if (mobilyaGenelFiyat != 0)
                {
                    string[] mobilyaVeriler = new string[8];
                    mobilyaVeriler[0] = "Eklendi";
                    mobilyaVeriler[1] = "Sehpa";
                    mobilyaVeriler[2] = "Eklendi";
                    mobilyaVeriler[3] = "Sehpa";
                    mobilyaVeriler[4] = boy.ToString() + "x" + mobEn.ToString() + "x" + mobYukseklik.ToString() + " " + cmbMobilyaTur.SelectedItem.ToString() + " Sehpa";
                    //mobilyaVeriler[5] = mobilyaGenelFiyat.ToString();
                    mobilyaVeriler[5] = mobilyaToplamFiyat.ToString();
                    mobilyaVeriler[6] = "AquaResif";
                    mobilyaVeriler[7] = "1";

                    dtSecilenUrunler.Rows.Add(mobilyaVeriler[0],
                        mobilyaVeriler[1],
                        mobilyaVeriler[2],
                        mobilyaVeriler[3],
                        mobilyaVeriler[4],
                        mobilyaVeriler[5],
                        mobilyaVeriler[6],
                        mobilyaVeriler[7]);

                    if (cmbDemirTuru.SelectedItem.ToString()!="Konsol Yok")
                    {
                        string[] konsolVeriler = new string[8];
                        konsolVeriler[0] = "Eklendi";
                        konsolVeriler[1] = "Konsol";
                        konsolVeriler[2] = "Eklendi";
                        konsolVeriler[3] = "Konsol";
                        konsolVeriler[4] = cmbDemirTuru.SelectedItem.ToString() + " Konsol - Mobilya içerisinde kullanılacak";
                        //mobilyaVeriler[5] = mobilyaGenelFiyat.ToString();
                        konsolVeriler[5] = demirToplamFiyat.ToString();
                        konsolVeriler[6] = "AquaResif";
                        konsolVeriler[7] = "1";

                        dtSecilenUrunler.Rows.Add(konsolVeriler[0],
                            konsolVeriler[1],
                            konsolVeriler[2],
                            konsolVeriler[3],
                            konsolVeriler[4],
                            konsolVeriler[5],
                            konsolVeriler[6],
                            konsolVeriler[7]);
                    }
                    

                    dtTeklifUrunler.DataSource = dtSecilenUrunler;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Lütfen mobilya bilgilerini eksiksiz giriniz, hesaplayınız ve ardından ekleyiniz");
            }

        }

        private void btnAkvaryumHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                akvaryumHesapla();
                MessageBox.Show("Ön cam + Arka cam toplam alanı: " + buyukYanAlan.ToString() + "\n" +
                "Sağ cam + Sol cam toplam alanı: " + ufakYanAlan.ToString() + "\n" +
                "Taban camı alanı: " + tabanCamiAlan.ToString() + "\n" +
                "Kayıtlar: " + kayitlar.ToString() + "\n" +
                "Fire: " + fireAlan.ToString() + "\n" +
                "Toplam Alan: " + toplamAlan.ToString() + "\n" +
                "Toplam Fiyat: " + akvaryumFiyat.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show("Lütfen akvaryum bilgilerini eksiksiz giriniz ve ardından hesaplayınız");
            }

        }

        private void dtTeklifUrunler_DataMemberChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Member");
        }

        private void dtTeklifUrunler_DataSourceChanged(object sender, EventArgs e)
        {
            dtTeklifUrunler.Columns[0].Visible = false;
            dtTeklifUrunler.Columns[2].Visible = false;

            dtTeklifUrunler.Columns[1].Width = 200;
            dtTeklifUrunler.Columns[3].Width = 200;
            dtTeklifUrunler.Columns[4].Width = 500;
            dtTeklifUrunler.Columns[5].Width = 100;
            dtTeklifUrunler.Columns[6].Width = 150;
            dtTeklifUrunler.Columns[7].Width = 100;

            dtTeklifUrunler.Columns[1].HeaderText = "Ürün Adı";
            dtTeklifUrunler.Columns[3].HeaderText = "Kategori Adı";
            dtTeklifUrunler.Columns[4].HeaderText = "Açıklama";
            dtTeklifUrunler.Columns[5].HeaderText = "Fiyat";
            dtTeklifUrunler.Columns[6].HeaderText = "Marka";
            dtTeklifUrunler.Columns[7].HeaderText = "Adet";

        }

        private void cmbMobilyaTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mobilyaBoslukKontrol())
            {
                try
                {
                    mobilyaHesapla();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void txtMobilyaYukseklik_TextChanged(object sender, EventArgs e)
        {
            sayiKontrol(sender);
            if (mobilyaBoslukKontrol())
            {
                try
                {
                    mobilyaHesapla();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void txtTacYukseklik_TextChanged(object sender, EventArgs e)
        {
            sayiKontrol(sender);
            if (mobilyaBoslukKontrol())
            {
                try
                {
                    mobilyaHesapla();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void txtKapakSayisi_TextChanged(object sender, EventArgs e)
        {
            sayiKontrol(sender);
            if (mobilyaBoslukKontrol())
            {
                try
                {
                    mobilyaHesapla();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void cmbDemirTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mobilyaBoslukKontrol())
            {
                try
                {
                    mobilyaHesapla();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        public bool mobilyaBoslukKontrol()
        {
            if (txtMobilyaYukseklik.Text.Length != 0 && txtTacYukseklik.Text.Length != 0 && txtKapakSayisi.Text.Length != 0 && cmbMobilyaTur.SelectedIndex > -1 && cmbDemirTuru.SelectedIndex > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void StandartTeklifForm_SizeChanged(object sender, EventArgs e)
        {
            formGenislik = this.Width;
            formYukseklik = this.Height;
            panel1.Left = (formGenislik - panel1.Width) / 2;
        }

        private void dtTeklifUrunler_SelectionChanged(object sender, EventArgs e)
        {
            //tekliftenCikanId = lstTeklifUrunler.Items[0].Text;
            if (dtTeklifUrunler.SelectedRows.Count > 0)
            {
                btnUrunCikar.Enabled = true;
            }
            else
            {
                btnUrunCikar.Enabled = false;
            }
        }

        private void dtListelenenler_SelectionChanged(object sender, EventArgs e)
        {


            if (dtListelenenler.SelectedRows.Count > 0)
            {
                btnUrunEkle.Enabled = true;
                //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
                try
                {
                    eklenecekUrunVeriler = new string[8];
                    eklenecekUrunVeriler[0] = dtListelenenler.Rows[0].Cells[0].Value.ToString();
                    eklenecekUrunVeriler[1] = dtListelenenler.Rows[0].Cells[1].Value.ToString();
                    eklenecekUrunVeriler[2] = dtListelenenler.Rows[0].Cells[2].Value.ToString();
                    eklenecekUrunVeriler[3] = dtListelenenler.Rows[0].Cells[3].Value.ToString();
                    eklenecekUrunVeriler[4] = dtListelenenler.Rows[0].Cells[4].Value.ToString();
                    eklenecekUrunVeriler[5] = dtListelenenler.Rows[0].Cells[5].Value.ToString();
                    eklenecekUrunVeriler[6] = dtListelenenler.Rows[0].Cells[6].Value.ToString();
                }
                catch (Exception err)
                {
                    //MessageBox.Show(err.ToString());
                }

            }
            else
            {
                btnUrunEkle.Enabled = false;
            }
        }

        double demirBoy, demirEn, demirYukseklik, demirToplamUzunluk, demirToplamFiyat;
        int demirBoyAdet, demirEnAdet, demirYukseklikAdet, demirBirimFiyat, demirProfilAdet;
        string demirKonsolTuru;

        int kulpAdedi, menteseAdedi, kulpMenteseToplam;

        string tumBirimFiyatlar;
        int[] birimFiyatlar = new int[31];


        private void btnDemirHesap_Click(object sender, EventArgs e)
        {




        }


        private void btnMobilyaHesap_Click(object sender, EventArgs e)
        {
            try
            {
                string a = "";
                if (boy < 100)
                {
                    a = "NOT: AKVARYUM BOYU 1 METREDEN KÜÇÜK OLAN AKVARYUMLAR İÇİN MOBİLYA BOYU 1 METRE OLARAK HESAPLANMAKTADIR" + "\n\n";
                }
                mobilyaHesapla();
                if (demirToplamFiyat.ToString() != "0")
                {
                    MessageBox.Show(a +
                    "Alt Mobilya Toplam Alan = " + mobToplamAlan.ToString() + "\n" +
                    "Alt Mobilya Toplam Fiyat: " + (mobToplamAlan * Convert.ToDouble(mobilyaBirimFiyat)).ToString() + "\n\n" +
                    //(mobToplamAlan * Convert.ToDouble(mobilyaBirimFiyat))
                    "Taç toplam Alan = " + tacToplamAlan.ToString() + "\n" +
                    "Taç toplam Fiyat = " + (tacToplamAlan * Convert.ToDouble(mobilyaBirimFiyat)).ToString() + "\n\n" +
                    //(tacToplamAlan * Convert.ToDouble(mobilyaBirimFiyat))

                    "Arkalık toplam Fiyat = " + arkalikFiyat.ToString() + "\n\n" +

                    "Kulp ve menteşe toplam fiyat:" + kulpMenteseToplam.ToString() + "\n\n" +
                    //arkalikFiyat + kulpMenteseToplam

                    "Demir Toplam uzunluk: " + demirToplamUzunluk.ToString() + "\n" +
                    "Demir Profil Adet: " + demirProfilAdet.ToString() + "\n" +
                    "Demir Toplam Fiyat: " + demirToplamFiyat.ToString() + "\n\n" +

                    "Mobilya Genel Fiyat: " + mobilyaGenelFiyat.ToString()
                    );
                }
                else
                {
                    MessageBox.Show(a +
                    "Alt Mobilya Toplam Alan = " + mobToplamAlan.ToString() + "\n" +
                    "Alt Mobilya Toplam Fiyat: " + (mobToplamAlan * Convert.ToDouble(mobilyaBirimFiyat)).ToString() + "\n\n" +
                    //(mobToplamAlan * Convert.ToDouble(mobilyaBirimFiyat))
                    "Taç toplam Alan = " + tacToplamAlan.ToString() + "\n" +
                    "Taç toplam Fiyat = " + (tacToplamAlan * Convert.ToDouble(mobilyaBirimFiyat)).ToString() + "\n\n" +
                    //(tacToplamAlan * Convert.ToDouble(mobilyaBirimFiyat))

                    "Arkalık toplam Fiyat = " + arkalikFiyat.ToString() + "\n\n" +

                    "Kulp ve menteşe toplam fiyat:" + kulpMenteseToplam.ToString() + "\n\n" +
                    //arkalikFiyat + kulpMenteseToplam

                    "Demir Konsol Kullanılmamıştır" + "\n\n" +

                    "Mobilya Genel Fiyat: " + mobilyaGenelFiyat.ToString());
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Lütfen akvaryum bilgilerini ve mobilya bilgilerini eksiksiz giriniz ve ardından hesaplayınız");
            }

        }

        double akvaryumFiyat, duzCamBirimFiyat, exClBirimFiyat;

        private void cmbExtraClear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtBoy.Text.Length != 0 && txtEn.Text.Length != 0 && txtYukseklik.Text.Length != 0 && cmbExtraClear.SelectedIndex > -1)
            {
                akvaryumHesapla();
            }
        }

        private void txtYukseklik_TextChanged(object sender, EventArgs e)
        {
            sayiKontrol(sender);
            if (txtYukseklik.Text.Length != 0)
            {
                lblYukseklik.Text = "Yükseklik: " + txtYukseklik.Text;
            }
            else
            {
                lblYukseklik.Text = "Yükseklik";
            }
            if (txtBoy.Text.Length != 0 && txtEn.Text.Length != 0 && txtYukseklik.Text.Length != 0 && cmbExtraClear.SelectedIndex > -1)
            {
                akvaryumHesapla();
            }
        }

        private void txtEn_TextChanged(object sender, EventArgs e)
        {
            sayiKontrol(sender);
            if (txtEn.Text.Length != 0)
            {
                lblEn.Text = "En: " + txtEn.Text;
            }
            else
            {
                lblEn.Text = "En";
            }
            if (txtBoy.Text.Length != 0 && txtEn.Text.Length != 0 && txtYukseklik.Text.Length != 0 && cmbExtraClear.SelectedIndex > -1)
            {
                akvaryumHesapla();
            }
        }

        private void txtBoy_TextChanged(object sender, EventArgs e)
        {
            sayiKontrol(sender);
            if (txtBoy.Text.Length != 0)
            {
                lblBoy.Text = "Boy: " + txtBoy.Text;
            }
            else
            {
                lblBoy.Text = "En";
            }
            if (txtBoy.Text.Length != 0 && txtEn.Text.Length != 0 && txtYukseklik.Text.Length != 0 && cmbExtraClear.SelectedIndex > -1)
            {
                akvaryumHesapla();
            }
        }

        string urunlerTumu = "";


        public StandartTeklifForm()
        {
            InitializeComponent();
        }

        private void StandartTeklifForm_Load(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/teklifNo");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                yeniTeklifNo = result.ToString();

                JObject tNo = JObject.Parse(yeniTeklifNo);
                yeniTeklifNo = tNo["yeniTeklifNo"].ToString();

            }

            if (yeniTeklifNo.Length == 1)
            {
                yeniTeklifNo = "000" + yeniTeklifNo;
            }
            else if (yeniTeklifNo.Length == 2)
            {
                yeniTeklifNo = "00" + yeniTeklifNo;
            }
            else if (yeniTeklifNo.Length == 3)
            {
                yeniTeklifNo = "0" + yeniTeklifNo;
            }

            btnUrunCikar.Enabled = false;
            btnUrunEkle.Enabled = false;

            formGenislik = this.Width;
            formYukseklik = this.Height;


            dtListelenenler.RowsDefaultCellStyle.ForeColor = Color.Black;
            dtTeklifUrunler.RowsDefaultCellStyle.ForeColor = Color.Black;



            user.setUserId(Convert.ToInt32(Form1.userInfo[0]));
            user.setUserName(Form1.userInfo[1]);
            user.setUserNS(Form1.userInfo[2]);
            user.setUserPass(Form1.userInfo[3]);
            user.setUserType(Form1.userInfo[4]);

            lblTeklifVeren.Text = user.getUserNS();
            //tUrunId-tUrunAdi-tUrunKatId-tUrunKatAdi-tUrunAciklama-tUrunFiyat-tUrunMarka
            DataColumn tUrunId = new DataColumn();
            tUrunId.ColumnName = "tUrunId";
            dtSecilenUrunler.Columns.Add(tUrunId);

            DataColumn tUrunAdi = new DataColumn();
            tUrunAdi.ColumnName = "tUrunAdi";
            dtSecilenUrunler.Columns.Add(tUrunAdi);

            DataColumn tUrunKatId = new DataColumn();
            tUrunKatId.ColumnName = "tUrunKatId";
            dtSecilenUrunler.Columns.Add(tUrunKatId);

            DataColumn tUrunKatAdi = new DataColumn();
            tUrunKatAdi.ColumnName = "tUrunKatAdi";
            dtSecilenUrunler.Columns.Add(tUrunKatAdi);

            DataColumn tUrunAciklama = new DataColumn();
            tUrunAciklama.ColumnName = "tUrunAciklama";
            dtSecilenUrunler.Columns.Add(tUrunAciklama);

            DataColumn tUrunFiyat = new DataColumn();
            tUrunFiyat.ColumnName = "tUrunFiyat";
            dtSecilenUrunler.Columns.Add(tUrunFiyat);

            DataColumn tUrunMarka = new DataColumn();
            tUrunMarka.ColumnName = "tUrunMarka";
            dtSecilenUrunler.Columns.Add(tUrunMarka);

            DataColumn tUrunAdet = new DataColumn();
            tUrunAdet.ColumnName = "tUrunAdet";
            dtSecilenUrunler.Columns.Add(tUrunAdet);

            //------------------

            DataColumn cUrunId = new DataColumn();
            cUrunId.ColumnName = "cUrunId";
            dtListelenenUrunler.Columns.Add(cUrunId);
            //dtSecilenUrunler.Columns.Add(cUrunId);

            DataColumn cUrunAdi = new DataColumn();
            cUrunAdi.ColumnName = "cUrunAdi";
            dtListelenenUrunler.Columns.Add(cUrunAdi);
            //dtSecilenUrunler.Columns.Add(cUrunAdi);

            DataColumn cKatId = new DataColumn();
            cKatId.ColumnName = "cKatId";
            dtListelenenUrunler.Columns.Add(cKatId);
            //dtSecilenUrunler.Columns.Add(cKatId);

            DataColumn cKatAdi = new DataColumn();
            cKatAdi.ColumnName = "cKatAdi";
            dtListelenenUrunler.Columns.Add(cKatAdi);
            //dtSecilenUrunler.Columns.Add(cKatAdi);

            DataColumn cUrunAciklama = new DataColumn();
            cUrunAciklama.ColumnName = "cUrunAciklama";
            dtListelenenUrunler.Columns.Add(cUrunAciklama);
            //dtSecilenUrunler.Columns.Add(cUrunAciklama);

            DataColumn cUrunFiyat = new DataColumn();
            cUrunFiyat.ColumnName = "cUrunFiyat";
            dtListelenenUrunler.Columns.Add(cUrunFiyat);
            //dtSecilenUrunler.Columns.Add(cUrunFiyat);

            DataColumn cUrunMarka = new DataColumn();
            cUrunMarka.ColumnName = "cUrunMarka";
            dtListelenenUrunler.Columns.Add(cUrunMarka);
            //dtSecilenUrunler.Columns.Add(cUrunMarka);

            this.dtTeklifUrunler.DataSource = dtSecilenUrunler;
            /*duzCamBirimFiyat = 1200.00;
            exClBirimFiyat = 1400.00;*/


            kategoriCek();
            birimFiyatCek();
        }

        public void birimFiyatCek()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/birimFiyatListele");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                tumBirimFiyatlar = result.ToString();

            }


            JArray jBirimler = JArray.Parse(tumBirimFiyatlar);
            for (int i = 0; i < jBirimler.Count; i++)
            {
                //katId katAdi
                JObject jBirim = JObject.Parse(jBirimler[i].ToString());
                birimFiyatlar[i] = Convert.ToInt32(jBirim["urunFiyati"]);
                //cmbKategoriler.Items.Add(jBirim["katId"].ToString() + " " + jkategori["katAdi"].ToString());

            }
        }

        public void kategoriCek()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/kategoriListele");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                tumKategoriler = result.ToString();

            }


            JArray jKategoriler = JArray.Parse(tumKategoriler);
            for (int i = 0; i < jKategoriler.Count; i++)
            {
                //katId katAdi
                JObject jkategori = JObject.Parse(jKategoriler[i].ToString());
                cmbKategoriler.Items.Add(jkategori["katId"].ToString() + " " + jkategori["katAdi"].ToString());

            }
        }

        public void urunCek()
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/urunListele");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    katId = selectedId
                });

                streamWriter.Write(json);


            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                tumUrunler = result.ToString();

                dtListelenenUrunler.Clear();
                JArray jUrunler = JArray.Parse(tumUrunler);
                for (int i = 0; i < jUrunler.Count; i++)
                {
                    JObject jurun = JObject.Parse(jUrunler[i].ToString());
                    //lstTeklifUrunler.Items.Add(jurun[i]["urunAdi"].ToString());
                    //MessageBox.Show(jurun["urunAdi"].ToString());
                    dtListelenenUrunler.Rows.Add(jurun["urunId"].ToString(), jurun["urunAdi"].ToString(), jurun["katId"].ToString(), selectedCat, jurun["urunAciklama"], jurun["urunFiyat"].ToString(), jurun["urunMarka"]);


                }

                //MessageBox.Show(dtListelenenUrunler.Rows.Count.ToString());
                lstListelenenler.Items.Clear();


            }
        }

        private void lstListelenenler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstListelenenler.SelectedItems.Count > 0)
            {
                eklenecekUrunVeriler = new string[8];
                eklenecekUrunVeriler[0] = lstListelenenler.Items[0].Text;
                eklenecekUrunVeriler[1] = lstListelenenler.Items[0].SubItems[1].Text;
                eklenecekUrunVeriler[2] = lstListelenenler.Items[0].SubItems[2].Text;
                eklenecekUrunVeriler[3] = lstListelenenler.Items[0].SubItems[3].Text;
                eklenecekUrunVeriler[4] = lstListelenenler.Items[0].SubItems[4].Text;
                eklenecekUrunVeriler[5] = lstListelenenler.Items[0].SubItems[5].Text;
                eklenecekUrunVeriler[6] = lstListelenenler.Items[0].SubItems[6].Text;


                eklenecekUrun = new ListViewItem(eklenecekUrunVeriler);
            }

        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (eklenecekUrunVeriler[0].Length != 0)
                {
                    int urunAdet = Convert.ToInt32(Interaction.InputBox("Adet", "Ürün adedini giriniz", "1", 0, 0));
                    eklenecekUrunVeriler[7] = urunAdet.ToString();
                    dtSecilenUrunler.Rows.Add(eklenecekUrunVeriler[0],
                        eklenecekUrunVeriler[1],
                        eklenecekUrunVeriler[2],
                        eklenecekUrunVeriler[3],
                        eklenecekUrunVeriler[4],
                        eklenecekUrunVeriler[5],
                        eklenecekUrunVeriler[6],
                        eklenecekUrunVeriler[7]);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Eklemek istediğiniz ürünü listenin en soldaki bölümünden (satır olarak) seçiniz ve ardından ekle butonuna tıklayınız");
            }



            this.dtTeklifUrunler.DataSource = dtSecilenUrunler;

            /*ListViewItem yeniSecilenUrun = new ListViewItem(eklenecekUrunVeriler);
            lstTeklifUrunler.Items.Add(yeniSecilenUrun);*/

            //MessageBox.Show(dtSecilenUrunler.Rows.Count.ToString());


        }

        private void lstTeklifUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void btnUrunCikar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow item = dtTeklifUrunler.SelectedRows[0];
                dtTeklifUrunler.Rows.RemoveAt(item.Index);
            }
            catch (Exception err)
            {
                MessageBox.Show("Lütfen geçerli bir ürünü listenin en solundan (satır olarak) seçiniz ve ardından çıkarınız");
            }
        }

        private void btnElleEkle_Click(object sender, EventArgs e)
        {
            ElleUrunFormu elleUrunFormu = new ElleUrunFormu();
            elleUrunFormu.ShowDialog();

            if (elleUrunFormu.formDurumu == "1")
            {
                string[] elleGelenVeriler = new string[8];
                elleGelenVeriler[0] = elleUrunFormu.urunVerileri[0];
                elleGelenVeriler[1] = elleUrunFormu.urunVerileri[1];
                elleGelenVeriler[2] = elleUrunFormu.urunVerileri[2];
                elleGelenVeriler[3] = elleUrunFormu.urunVerileri[3];
                elleGelenVeriler[4] = elleUrunFormu.urunVerileri[4];
                elleGelenVeriler[5] = elleUrunFormu.urunVerileri[5];
                elleGelenVeriler[6] = elleUrunFormu.urunVerileri[6];
                elleGelenVeriler[7] = elleUrunFormu.urunVerileri[7];
                //urunid-ürünadı-katid-katadi-urunaciklama-urunfiyat-urunmarka

                dtSecilenUrunler.Rows.Add(elleGelenVeriler[0],
                    elleGelenVeriler[1],
                    elleGelenVeriler[2],
                    elleGelenVeriler[3],
                    elleGelenVeriler[4],
                    elleGelenVeriler[5],
                    elleGelenVeriler[6],
                    elleGelenVeriler[7]);



            }
        }

        private void StandartTeklifForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelDosya);
        }

        private void btnTeklifHazirla_Click(object sender, EventArgs e)
        {
            string gun = (DateTime.Now.Day.ToString("d2"));
            string ay = (DateTime.Now.Month.ToString("d2"));
            string yil = (DateTime.Now.Year.ToString("d2"));
            string sayac = yeniTeklifNo;
            string tarih = gun + "." + ay + "." + yil;
            string araYazi = "Akvaryum projesi ile ilgili teklif ve teknik detayları aşağıda bilgilerinize sunulmaktadır.\n" +
                "Firmamızdan teklif istemekle göstermiş olduğunuz ilgiye teşekkür eder, değerli siparişlerinizi bekleriz";

            teklifHazirlayan = lblTeklifVeren.Text;
            teklifKonu = txtKonu.Text;
            musteri = txtMusteriAdi.Text;
            ilgiliKisi = txtIlgiliKisi.Text;
            email = txtEmail.Text;
            gsm = txtGsm.Text;
            teslimYeri = txtTeslimYeri.Text;
            teslimSuresi = txtTeslimSuresi.Text;
            teklifNo = (ay + yil + sayac);
            odemeSekli = txtOdemeSekli.Text;

            //string aktarilacakYazi = "";
            string[,] musteriBilgileri = new string[5, 3];
            string[,] teklifBilgileri = new string[5, 3];
            string[,] akvaryumBilgileri = new string[5, 3];
            string[,] urunBilgileri = new string[dtSecilenUrunler.Rows.Count, 6];
            string[,] genelToplam = new string[3, 3];


            //Müşteri Bilgileri
            musteriBilgileri[0, 0] = "Müşteri";
            musteriBilgileri[0, 1] = ":";
            musteriBilgileri[0, 2] = musteri;

            musteriBilgileri[1, 0] = "İlgili Kişi";
            musteriBilgileri[1, 1] = ":";
            musteriBilgileri[1, 2] = ilgiliKisi;

            musteriBilgileri[2, 0] = "E-Mail";
            musteriBilgileri[2, 1] = ":";
            musteriBilgileri[2, 2] = email;

            musteriBilgileri[3, 0] = "GSM";
            musteriBilgileri[3, 1] = ":";
            musteriBilgileri[3, 2] = gsm;

            musteriBilgileri[4, 0] = "Konu";
            musteriBilgileri[4, 1] = ":";
            musteriBilgileri[4, 2] = teklifKonu;


            //Teklif Bilgileri
            teklifBilgileri[0, 0] = "Teklif No";
            teklifBilgileri[0, 1] = ":";
            teklifBilgileri[0, 2] = teklifNo;

            teklifBilgileri[1, 0] = "Teslim Yeri";
            teklifBilgileri[1, 1] = ":";
            teklifBilgileri[1, 2] = teslimYeri;

            teklifBilgileri[2, 0] = "Ödeme Şekli";
            teklifBilgileri[2, 1] = ":";
            teklifBilgileri[2, 2] = odemeSekli;

            teklifBilgileri[3, 0] = "Teslim Süresi";
            teklifBilgileri[3, 1] = ":";
            teklifBilgileri[3, 2] = teslimSuresi;

            teklifBilgileri[4, 0] = "Teklif Veren";
            teklifBilgileri[4, 1] = ":";
            teklifBilgileri[4, 2] = teklifHazirlayan;


            //Akvaryum Bilgileri
            akvaryumBilgileri[0, 0] = "Boy";
            akvaryumBilgileri[0, 1] = ":";
            akvaryumBilgileri[0, 2] = boy.ToString();

            akvaryumBilgileri[1, 0] = "En (Derinlik)";
            akvaryumBilgileri[1, 1] = ":";
            akvaryumBilgileri[1, 2] = en.ToString();

            akvaryumBilgileri[2, 0] = "Yükseklik";
            akvaryumBilgileri[2, 1] = ":";
            akvaryumBilgileri[2, 2] = yukseklik.ToString();

            akvaryumBilgileri[3, 0] = "Hacim";
            akvaryumBilgileri[3, 1] = ":";
            akvaryumBilgileri[3, 2] = hacim.ToString("N0");

            akvaryumBilgileri[4, 0] = "Cam Kalınlığı";
            akvaryumBilgileri[4, 1] = ":";
            akvaryumBilgileri[4, 2] = camKalinligi.ToString();

            //Ürün Bilgileri


            //dtTeklifUrunler
            for (int i = 0; i < dtSecilenUrunler.Rows.Count; i++)
            {
                urunBilgileri[i, 0] = dtSecilenUrunler.Rows[i][3].ToString();
                urunBilgileri[i, 1] = dtSecilenUrunler.Rows[i][1].ToString() + " : " + dtTeklifUrunler.Rows[i].Cells[4].Value.ToString();
                urunBilgileri[i, 2] = dtSecilenUrunler.Rows[i][6].ToString();
                urunBilgileri[i, 3] = dtSecilenUrunler.Rows[i][7].ToString();
                urunBilgileri[i, 4] = dtSecilenUrunler.Rows[i][5].ToString();
                double fiyat, adet;
                fiyat = Convert.ToDouble(dtSecilenUrunler.Rows[i][5]);
                adet = Convert.ToDouble(dtSecilenUrunler.Rows[i][7]);
                urunBilgileri[i, 5] = (fiyat * adet).ToString();

            }


            //Genel Toplam Bilgileri

            double toplamFiyat = 0;

            for (int i = 0; i < dtSecilenUrunler.Rows.Count; i++)
            {
                toplamFiyat = toplamFiyat + Convert.ToDouble(urunBilgileri[i, 5]);
            }

            genelToplam[0, 0] = "Toplam";
            genelToplam[0, 1] = ":";
            genelToplam[0, 2] = toplamFiyat.ToString();

            genelToplam[1, 0] = "KDV";
            genelToplam[1, 1] = ":";
            genelToplam[1, 2] = (toplamFiyat * 18 / 100).ToString();

            genelToplam[2, 0] = "Genel Toplam";
            genelToplam[2, 1] = ":";
            genelToplam[2, 2] = (toplamFiyat * 1.18).ToString();



            excelDosya = new Excel.Application();

            object missing = Type.Missing;
            Excel.Workbook calismaKitabi = excelDosya.Workbooks.Add(missing);
            Excel.Worksheet sheet1 = calismaKitabi.Sheets[1];


            sheet1.Columns[1].NumberFormat = "@";
            sheet1.Columns[2].NumberFormat = "@";
            sheet1.Columns[3].NumberFormat = "@";
            sheet1.Columns[4].NumberFormat = "@";
            sheet1.Columns[5].NumberFormat = "@";
            sheet1.Columns[6].NumberFormat = "@";
            sheet1.Columns[7].NumberFormat = "@";
            sheet1.Columns[8].NumberFormat = "@";
            sheet1.Columns[9].NumberFormat = "@";
            sheet1.Columns[10].NumberFormat = "@";

            int sutun = 1;
            int satir = 1;


            excelDosya.StandardFont = "Calibri";
            excelDosya.StandardFontSize = 10;

            //Genişlikler
            sheet1.Columns[1].ColumnWidth = 2.75 * 4.5;
            sheet1.Columns[2].ColumnWidth = 0.32 * 4.5;
            sheet1.Columns[3].ColumnWidth = 2.65 * 4.5;
            sheet1.Columns[4].ColumnWidth = 1.77 * 4.5;

            sheet1.Columns[5].ColumnWidth = 0.56 * 4.5 * 4;
            sheet1.Columns[6].ColumnWidth = 2.38 * 4.5;
            sheet1.Columns[7].ColumnWidth = 0.32 * 4.5;
            sheet1.Columns[8].ColumnWidth = 2.41 * 4.5;
            sheet1.Columns[9].ColumnWidth = 1.77 * 4.5;
            sheet1.Columns[10].ColumnWidth = 1.77 * 4.5;


            //Merge
            sheet1.Range[sheet1.Cells[1, 1], sheet1.Cells[1, 10]].Merge();//Logo
            Excel.Range rangeLogo = sheet1.Cells[1, 1];
            rangeLogo.RowHeight = 100;
            string logo = (@"c:\Aquaresif\l2.png"), akvaryum = (@"c:\Aquaresif\akvaryum.png");
            sheet1.Shapes.AddPicture(logo, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0, 180, 97);
            sheet1.Shapes.AddPicture(akvaryum, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 250, 230, 180, 60);


            Microsoft.Office.Interop.Excel.Shape shape;
            shape = sheet1.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 225, 255, 60, 20);
            shape.TextFrame2.TextRange.Text = akvaryumBilgileri[2, 2] + " cm";

            shape = sheet1.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 300, 275, 60, 20);
            shape.TextFrame2.TextRange.Text = akvaryumBilgileri[0, 2] + " cm";

            shape = sheet1.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 410, 270, 60, 20);
            shape.TextFrame2.TextRange.Text = akvaryumBilgileri[1, 2] + " cm";




            sheet1.Range[sheet1.Cells[2, 1], sheet1.Cells[2, 10]].Merge();//Tarih
            Excel.Range rangelTarih = sheet1.Cells[2, 1];
            rangelTarih.Value2 = tarih;
            sheet1.Cells[19, 3].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
            for (int i = 0; i < 10; i++)
            {
                Excel.Range rTarihBorder = sheet1.Cells[2, i + 1];
                rTarihBorder.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                rTarihBorder.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThick;
            }

            for (int i = 0; i < 10; i++)
            {
                Excel.Range rTarihBorder = sheet1.Cells[7, i + 1];
                rTarihBorder.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                rTarihBorder.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThick;
            }




            //Müşteri bilgileri girildi
            for (int i = 0; i < 5; i++)
            {
                sheet1.Range[sheet1.Cells[i + 3, 3], sheet1.Cells[i + 3, 5]].Merge();
                for (int j = 0; j < 3; j++)
                {
                    Excel.Range range = sheet1.Cells[i + 3, j + 1];
                    range.Value2 = musteriBilgileri[i, j];
                    range.Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    range.Style.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
            }

            //Teklif Bilgileri Girildi
            for (int i = 0; i < 5; i++)
            {
                sheet1.Range[sheet1.Cells[i + 3, 8], sheet1.Cells[i + 3, 10]].Merge();
                for (int j = 0; j < 3; j++)
                {
                    Excel.Range range = sheet1.Cells[i + 3, j + 6];
                    range.Value2 = teklifBilgileri[i, j];
                }
            }


            //Ara Yazı

            sheet1.Range[sheet1.Cells[9, 1], sheet1.Cells[9, 10]].Merge();
            Excel.Range araDuzYazi = sheet1.Cells[9, 1];
            araDuzYazi.RowHeight = 26.25;
            araDuzYazi.Value2 = araYazi;


            //Akvaryum Bilgileri girildi
            for (int i = 0; i < 5; i++)
            {
                sheet1.Range[sheet1.Cells[i + 12, 3], sheet1.Cells[i + 12, 4]].Merge();
                for (int j = 0; j < 3; j++)
                {
                    Excel.Range range = sheet1.Cells[i + 12, j + 1];
                    string yaz = akvaryumBilgileri[i, j];
                    if (((i == 0) || (i == 1) || (i == 2)) && j == 2)
                    {
                        yaz = akvaryumBilgileri[i, j] + " cm";
                    }

                    else if (i == 3 && j == 2)
                    {
                        yaz = Convert.ToDouble(akvaryumBilgileri[i, j]).ToString("N2") + " litre";
                    }
                    else if (i == 4 && j == 2)
                    {
                        yaz = akvaryumBilgileri[i, j] + " mm";
                    }
                    range.Value2 = yaz;

                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Excel.Range rTarihBorder = sheet1.Cells[i + 12, j + 1];
                    rTarihBorder.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                    rTarihBorder.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    rTarihBorder.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;
                    rTarihBorder.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin;
                    if (j == 0)
                    {
                        rTarihBorder.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                        rTarihBorder.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                    if (j == 3)
                    {
                        rTarihBorder.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                        rTarihBorder.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                }
            }




            //Ürünler Başlıklar girildi
            sheet1.Range[sheet1.Cells[19, 2], sheet1.Cells[19, 5]].Merge();
            sheet1.Range[sheet1.Cells[19, 7], sheet1.Cells[19, 8]].Merge();

            Excel.Range rangeUrunler = sheet1.Cells[19, 1];
            rangeUrunler.Value2 = "Ürünler";
            rangeUrunler.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;


            Excel.Range rangeAciklama = sheet1.Cells[19, 2];
            rangeAciklama.Value2 = "Açıklama";
            rangeAciklama.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            rangeAciklama = sheet1.Cells[19, 3];
            rangeAciklama.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            rangeAciklama = sheet1.Cells[19, 4];
            rangeAciklama.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            rangeAciklama = sheet1.Cells[19, 5];
            rangeAciklama.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            rangeAciklama = sheet1.Cells[19, 6];
            rangeAciklama.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            Excel.Range rangeMarka = sheet1.Cells[19, 6];
            rangeMarka.Value2 = "Marka";
            rangeMarka.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;


            Excel.Range rangeMiktar = sheet1.Cells[19, 7];
            rangeMiktar.Value2 = "Miktar";
            rangeMiktar.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            rangeMiktar = sheet1.Cells[19, 8];
            rangeMiktar.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            Excel.Range rangeFiyat = sheet1.Cells[19, 9];
            rangeFiyat.Value2 = "Fiyat";
            rangeFiyat.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;



            Excel.Range rangeToplam = sheet1.Cells[19, 10];
            rangeToplam.Value2 = "Toplam";
            rangeToplam.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;




            //Ürünler İçerik Girildi

            for (int i = 0; i < dtSecilenUrunler.Rows.Count; i++)
            {
                sheet1.Range[sheet1.Cells[i + 20, 2], sheet1.Cells[i + 20, 5]].Merge();
                sheet1.Range[sheet1.Cells[i + 20, 7], sheet1.Cells[i + 20, 8]].Merge();

                Excel.Range rangeUrunlerIc = sheet1.Cells[i + 20, 1];
                rangeUrunlerIc.Value2 = urunBilgileri[i, 0];
                rangeUrunlerIc.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                Excel.Range rangeAciklamaIc = sheet1.Cells[i + 20, 2];
                rangeAciklamaIc.Value2 = urunBilgileri[i, 1];

                rangeAciklamaIc.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rangeAciklamaIc = sheet1.Cells[i + 20, 3];
                rangeAciklamaIc.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rangeAciklamaIc = sheet1.Cells[i + 20, 4];
                rangeAciklamaIc.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rangeAciklamaIc = sheet1.Cells[i + 20, 5];
                rangeAciklamaIc.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rangeAciklamaIc = sheet1.Cells[i + 20, 6];
                rangeAciklamaIc.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rangeAciklamaIc.Rows.AutoFit();
                rangeAciklamaIc.Columns.AutoFit();

                Excel.Range rangeMarkaIc = sheet1.Cells[i + 20, 6];
                rangeMarkaIc.Value2 = urunBilgileri[i, 2];
                rangeMarkaIc.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                Excel.Range rangeMiktarIc = sheet1.Cells[i + 20, 7];
                rangeMiktarIc.Value2 = urunBilgileri[i, 3];
                rangeMiktarIc.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rangeMiktarIc = sheet1.Cells[i + 20, 8];
                rangeMiktarIc.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                Excel.Range rangeFiyatIc = sheet1.Cells[i + 20, 9];
                rangeFiyatIc.Value2 = (Convert.ToDouble(urunBilgileri[i, 4])).ToString("N2");
                rangeFiyatIc.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                Excel.Range rangeToplamIc = sheet1.Cells[i + 20, 10];
                rangeToplamIc.Value2 = (Convert.ToDouble(urunBilgileri[i, 5])).ToString("N2");
                rangeToplamIc.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }


            int gToplamBaslangic = 19 + dtSecilenUrunler.Rows.Count + 2;

            //Toplam tutar Bilgileri girildi
            for (int i = 0; i < 3; i++)
            {
                sheet1.Range[sheet1.Cells[i + gToplamBaslangic, 7], sheet1.Cells[i + gToplamBaslangic, 8]].Merge();
                sheet1.Range[sheet1.Cells[i + gToplamBaslangic, 9], sheet1.Cells[i + gToplamBaslangic, 10]].Merge();
                for (int j = 0; j < 3; j++)
                {
                    Excel.Range range = sheet1.Cells[i + gToplamBaslangic, j + 7];
                    try
                    {
                        range.Value2 = (Convert.ToDouble(genelToplam[i, j])).ToString("N2");
                    }
                    catch
                    {
                        range.Value2 = genelToplam[i, j];
                    }
                    range.Font.Bold = true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Excel.Range gToplamRange = sheet1.Cells[i + gToplamBaslangic, j + 7];
                    gToplamRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }
            }



            //Alt Bilgi
            int altBilgiBaslangic = gToplamBaslangic + 3 + 2;
            sheet1.Range[sheet1.Cells[altBilgiBaslangic, 1], sheet1.Cells[altBilgiBaslangic, 10]].Merge();
            Excel.Range rangeAltBilgiBaslik = sheet1.Cells[altBilgiBaslangic, 1];
            rangeAltBilgiBaslik.Value2 = "Ödemeler ve Anlaşmalar";

            for (int j = 0; j < 10; j++)
            {
                Excel.Range altBilgilerBorder = sheet1.Cells[altBilgiBaslangic, j + 1];
                altBilgilerBorder.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                altBilgilerBorder.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;
            }


            string[] altBilgiler = new string[16];
            altBilgiler[0] = "Necip Fazıl Mahallesi Alemdağ Caddesi Bıçkın Sokak no:7/A Ümraniye / İSTANBUL\nTel: 0216 540 44 46\t0216 527 73 53\nwww.aquaresif.com – info @daquaresif.com";
            altBilgiler[1] = "Akvaryum cam ağırlığı 150 kilo ve üzeri imalatlar yerinde yapılacaktır.";
            altBilgiler[2] = "Sipariş onayında toplam bedelin  % 65 PEŞİN, geri kalan bakiye malzeme nakliyesi öncesi hesaba geçirilir. ";
            altBilgiler[3] = "Sipariş onayından 20- ile 25 iş günü içinde sipariş teslim edilir. ";
            altBilgiler[4] = "Kaparosu geç yatırılan işlerin, sipariş tarihi kaparonun yatırıldığı tarih olarak kabul edilir. \nSipariş iptallerinde alınan kaparo iade edilmez.";
            altBilgiler[5] = "Teklif formunda olmayan ürünlerin veya markaların talep edilmesi durumunda ayrıca fiyatlandırılır.";
            altBilgiler[6] = "Akvaryum gövdesi 2 yıl süre ile sızdırmazlık garantisine sahiptir,DAS dışında yapılan müdahale garanti \ndışında çıkmasına sebep olur . Elektrik motorları hariç diğer tüm donanım 1 yıl süre ile DAS garantisi altındadır.";
            altBilgiler[7] = "6 aydan sonraki tadilat gerektiren durumlar için Malzeme ve işçilik ücretsiz. Ulaşım bedeli; yeni istek \nve değişikler ücrete tabidir.";
            altBilgiler[8] = "Motorlar ve Diğer elektronik cihazlar, Üretici ve ithalatçı firmalarını garanti güvencesindedir.";
            altBilgiler[9] = "Akvaryuma koyulacak canlı balık, bitki türleri,  akvaryum için gerekli inşat ve çevresel dekorasyon işleri, \ngerekli enerji ve su beslemelerinin montaj alanına getirilmesi, tesisat montaj için gerekli teçhizat odası teklif kapsamına dâhil değildir.";
            altBilgiler[10] = "Akvaryum patlaması ve sızdırması gibi olumsuz koşullardan doğabilecek zarar ve ziyan DAS ait değildir \n(parkelerin şişmesi, duvar boyasının kalkması vb durumlarda dahil DAS sorumluluğu dışındadır; ve ödeme yapılmaz.)";
            altBilgiler[11] = "Teklif formundaki ürünler hiçbir koşulda iadesi kabul edilmez, Ürünlerin ayıpları giderilir.";
            altBilgiler[12] = "15 günden daha geç hatalı ürün bildirimleri doğacak tüm masraflar alıcıya aittir. ( yol masrafa, \nişçilik, nakliye, malzeme vb )";
            altBilgiler[13] = "Teklifimiz döviz kurunda ani dalgalanma olmadığı sürece 30 gün geçerlidir.";
            altBilgiler[14] = "Teklifimiz onaylıyorsanız kaşeleyip imzalayarak info@aquaresif.com mail adresine gönderiniz.";
            altBilgiler[15] = "Yukarıda yazılı maddeleri okudum ve kabul ediyorum";
            for (int i = 0; i < 15; i++)
            {
                sheet1.Range[sheet1.Cells[i + altBilgiBaslangic + 1, 1], sheet1.Cells[i + altBilgiBaslangic + 1, 10]].Merge();
                Excel.Range rngAltBilgilerTumu = sheet1.Cells[i + altBilgiBaslangic + 1, 1];
                rngAltBilgilerTumu.Value2 = (i + 1).ToString() + " -) " + altBilgiler[i + 1];
                rngAltBilgilerTumu.Font.Size = 7;
                if (i == 3)
                {
                    rngAltBilgilerTumu.RowHeight = 25;
                }
                if (i == 5)
                {
                    rngAltBilgilerTumu.RowHeight = 25;
                }
                if (i == 6)
                {
                    rngAltBilgilerTumu.RowHeight = 25;
                }
                if (i == 8)
                {
                    rngAltBilgilerTumu.RowHeight = 25;
                }
                if (i == 9)
                {
                    rngAltBilgilerTumu.RowHeight = 25;
                }
                if (i == 11)
                {
                    rngAltBilgilerTumu.RowHeight = 25;
                }
                if (i == 14)
                {
                    sheet1.Range[sheet1.Cells[i + altBilgiBaslangic + 2, 1], sheet1.Cells[i + altBilgiBaslangic + 2, 10]].Merge();
                    Excel.Range rngAdres = sheet1.Cells[i + altBilgiBaslangic + 2, 1];
                    rngAdres.Value2 = altBilgiler[0];
                    rngAdres.RowHeight = 30;
                    rngAdres.Font.Size = 7;
                }
            }


            sheet1.Cells[3, 1].Font.Bold = true;
            sheet1.Cells[4, 1].Font.Bold = true;
            sheet1.Cells[5, 1].Font.Bold = true;
            sheet1.Cells[6, 1].Font.Bold = true;
            sheet1.Cells[7, 1].Font.Bold = true;

            sheet1.Cells[3, 6].Font.Bold = true;
            sheet1.Cells[4, 6].Font.Bold = true;
            sheet1.Cells[5, 6].Font.Bold = true;
            sheet1.Cells[6, 6].Font.Bold = true;
            sheet1.Cells[7, 6].Font.Bold = true;

            sheet1.Cells[2, 1].Font.Bold = true;

            sheet1.Cells[12, 1].Font.Bold = true;
            sheet1.Cells[13, 1].Font.Bold = true;
            sheet1.Cells[14, 1].Font.Bold = true;
            sheet1.Cells[15, 1].Font.Bold = true;
            sheet1.Cells[16, 1].Font.Bold = true;

            sheet1.Cells[19, 1].Font.Bold = true;
            sheet1.Cells[19, 2].Font.Bold = true;
            sheet1.Cells[19, 3].Font.Bold = true;
            sheet1.Cells[19, 4].Font.Bold = true;
            sheet1.Cells[19, 5].Font.Bold = true;
            sheet1.Cells[19, 6].Font.Bold = true;
            sheet1.Cells[19, 7].Font.Bold = true;
            sheet1.Cells[19, 8].Font.Bold = true;
            sheet1.Cells[19, 9].Font.Bold = true;
            sheet1.Cells[19, 10].Font.Bold = true;
            sheet1.Cells[altBilgiBaslangic, 1].Font.Bold = true;

            sheet1.Columns.AutoFit();


            //---
            string dosyaAdi = teklifNo + " - Teklif -" + tarih + ".xlsx";
            calismaKitabi.SaveAs(dosyaAdi, Excel.XlFileFormat.xlWorkbookDefault);
            excelDosya.Workbooks.Close();
            excelDosya.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelDosya);
            //MessageBox.Show("Bitti");

            //---

            //excelDosya.Visible = true;


            //--------------------------Veritabanına teklifi basma

            JArray jsonUrunler = new JArray();
            JObject jurunObj = new JObject();
            //JObject jsonUrun;
            string jsonUrun;

            /*
             public string teklif_no { get; set; }
            public string musteri { get; set; }
            public string ilgiliKisi { get; set; }
            public string email { get; set; }
            public string gsm { get; set; }
            public string konu { get; set; }
            public string teslimYeri { get; set; }
            public string odemeSekli { get; set; }
            public string teslimSuresi { get; set; }
            public string tarih { get; set; }
            public string toplamFiyat { get; set; }*/


            teklifVerileri.RootObject tRoot = new teklifVerileri.RootObject();
            tRoot.teklif_no = teklifBilgileri[0, 2].ToString().Trim();
            tRoot.musteri = musteriBilgileri[0, 2].ToString().Trim();
            tRoot.ilgiliKisi = musteriBilgileri[1, 2].ToString().Trim();
            tRoot.email = musteriBilgileri[2, 2].ToString().Trim();
            tRoot.gsm = musteriBilgileri[3, 2].ToString().Trim();
            tRoot.konu = musteriBilgileri[4, 2].ToString().Trim();
            tRoot.teslimYeri = teklifBilgileri[1, 2].ToString().Trim();
            tRoot.odemeSekli = teklifBilgileri[2, 2].ToString().Trim();
            tRoot.teslimSuresi = teklifBilgileri[3, 2].ToString().Trim();
            tRoot.tarih = tarih.Trim();
            tRoot.toplamFiyat = genelToplam[2, 2].ToString().Trim();
            tRoot.teklifVeren = teklifBilgileri[4, 2].ToString().Trim();
            tRoot.tumUrunler = new List<teklifVerileri.TumUrunler>();
            //tRoot.tumUrunler.Add()
            teklifVerileri.TumUrunler tUrunler = new teklifVerileri.TumUrunler();






            for (int i = 0; i < dtSecilenUrunler.Rows.Count; i++)
            {
                teklifVerileri.TumUrunler tVeriler = new teklifVerileri.TumUrunler();
                /*
                 public string urunKatAdi { get; set; }
            public string urunAdi { get; set; }
            public string urunAciklama { get; set; }
            public string marka { get; set; }
            public string adet { get; set; }
            public string fiyat { get; set; }
            public string toplamFiyat { get; set; }*/
                double geciciFiyat = (Convert.ToDouble(dtSecilenUrunler.Rows[i][7]) * Convert.ToDouble(dtSecilenUrunler.Rows[i][5]));
                tVeriler.urunKatAdi = dtSecilenUrunler.Rows[i][3].ToString().Trim();
                tVeriler.urunAdi = dtSecilenUrunler.Rows[i][1].ToString().Trim();
                tVeriler.urunAciklama = dtSecilenUrunler.Rows[i][4].ToString().Trim();
                tVeriler.marka = dtSecilenUrunler.Rows[i][6].ToString().Trim();
                tVeriler.adet = dtSecilenUrunler.Rows[i][7].ToString().Trim();
                tVeriler.fiyat = dtSecilenUrunler.Rows[i][5].ToString().Trim();
                tVeriler.toplamFiyat = geciciFiyat.ToString("N2").Trim();
                jsonUrun = new JavaScriptSerializer().Serialize(new
                {

                    urunKatAdi = dtSecilenUrunler.Rows[i][3].ToString().Trim(),
                    urunAdi = dtSecilenUrunler.Rows[i][1].ToString().Trim(),
                    urunAciklama = dtSecilenUrunler.Rows[i][4].ToString().Trim(),
                    marka = dtSecilenUrunler.Rows[i][6].ToString().Trim(),
                    adet = dtSecilenUrunler.Rows[i][7].ToString().Trim(),
                    fiyat = dtSecilenUrunler.Rows[i][5].ToString().Trim(),
                    toplamFiyat = geciciFiyat.ToString("N2").Trim()
                });
                tRoot.tumUrunler.Add(tVeriler);
                jsonUrunler.Add(jsonUrun);

            }



            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/teklifEkle");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(tRoot);
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                //MessageBox.Show(result.ToString());

            }

            MessageBox.Show("Teklif dosyası belgelerim klasörüne teklif numarası ile kaydedilmiştir. \n" +
                "Form kapatılacak");
            this.Close();

        }

        private void btnAkvaryumEkle_Click(object sender, EventArgs e)
        {
            try
            {
                akvaryumHesapla();
                if (akvaryumFiyat != 0)
                {
                    string[] akvaryumVeriler = new string[8];
                    akvaryumVeriler[0] = "Eklendi";
                    akvaryumVeriler[1] = boy.ToString() + "x" + en.ToString() + "x" + yukseklik.ToString() + " Akvaryum";
                    akvaryumVeriler[2] = "Eklendi";
                    akvaryumVeriler[3] = "Akvaryum";
                    akvaryumVeriler[4] = akvaryumAciklama;
                    akvaryumVeriler[5] = akvaryumFiyat.ToString();
                    akvaryumVeriler[6] = "AquaResif";
                    akvaryumVeriler[7] = "1";

                    dtSecilenUrunler.Rows.Add(akvaryumVeriler[0],
                        akvaryumVeriler[1],
                        akvaryumVeriler[2],
                        akvaryumVeriler[3],
                        akvaryumVeriler[4],
                        akvaryumVeriler[5],
                        akvaryumVeriler[6],
                        akvaryumVeriler[7]);

                    dtTeklifUrunler.DataSource = dtSecilenUrunler;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Lütfen akvaryum bilgilerini eksiksiz giriniz, hesapla butonu ile hesaplayınız ve ardından eklemeyiniz");
            }


        }

        private void cmbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dtListelenenler.Rows.Clear();
            string secilen = cmbKategoriler.SelectedItem.ToString();
            //ürünId -ürünAdı-katId-katAdı-urunAciklama-urunFiyat-urunMarka
            int boslukBul = cmbKategoriler.SelectedItem.ToString().IndexOf(" ");
            selectedId = Convert.ToInt32(cmbKategoriler.SelectedItem.ToString().Substring(0, boslukBul));
            selectedCat = secilen.Substring((boslukBul + 1), ((secilen.Length) - (boslukBul + 1)));
            urunCek();
            //dtListelenenler.DataSource = dtListelenenUrunler;
            for (int i = 0; i < dtListelenenUrunler.Rows.Count; i++)
            {

                string[] listelenecekUrun = new string[7];
                listelenecekUrun[0] = dtListelenenUrunler.Rows[i]["cUrunId"].ToString();
                listelenecekUrun[1] = dtListelenenUrunler.Rows[i]["cUrunAdi"].ToString();
                listelenecekUrun[2] = dtListelenenUrunler.Rows[i]["cKatId"].ToString();
                listelenecekUrun[3] = dtListelenenUrunler.Rows[i]["cKatAdi"].ToString();
                listelenecekUrun[4] = dtListelenenUrunler.Rows[i]["cUrunAciklama"].ToString();
                listelenecekUrun[5] = dtListelenenUrunler.Rows[i]["cUrunFiyat"].ToString();
                listelenecekUrun[6] = dtListelenenUrunler.Rows[i]["cUrunMarka"].ToString();


                this.dtListelenenler.Rows.Add(listelenecekUrun[0],
                    listelenecekUrun[1],
                    listelenecekUrun[2],
                    listelenecekUrun[3],
                    listelenecekUrun[4],
                    listelenecekUrun[5],
                    listelenecekUrun[6]);
                ListViewItem yeniListelenecekUrun = new ListViewItem(listelenecekUrun);
                lstListelenenler.Items.Add(yeniListelenecekUrun);

            }






        }

        public void mobilyaHesapla()
        {
            //MessageBox.Show("Arkalık Birim Fiyat: " + birimFiyatlar[30].ToString());
            kulpAdedi = Convert.ToInt32(txtKapakSayisi.Text); //28
            menteseAdedi = (kulpAdedi * 2); //29
            kulpMenteseToplam = (kulpAdedi * birimFiyatlar[28]) + (menteseAdedi * birimFiyatlar[29]);
            mobilyaTuru = cmbMobilyaTur.SelectedItem.ToString();

            if (mobilyaTuru == "MDF")
            {
                mobilyaBirimFiyat = birimFiyatlar[20];
                //20
            }
            else if (mobilyaTuru == "Membran")
            {
                mobilyaBirimFiyat = birimFiyatlar[21];
                //21
            }
            else if (mobilyaTuru == "Lake")
            {
                mobilyaBirimFiyat = birimFiyatlar[22];
                //22
            }


            //MessageBox.Show(mobilyaBirimFiyat.ToString());

            if (Convert.ToInt32(txtBoy.Text) < 100)
            {
                mobBoy = 100.00;
            }
            else
            {
                mobBoy = Convert.ToDouble(txtBoy.Text);
            }

            mobEn = Convert.ToDouble(txtEn.Text);
            kapakSayisi = Convert.ToInt32(txtKapakSayisi.Text);
            mobYukseklik = Convert.ToDouble(txtMobilyaYukseklik.Text);
            tacYuksekligi = Convert.ToDouble(txtTacYukseklik.Text);

            mobArkalik = ((mobBoy * mobYukseklik) / 10000);

            arkalikFiyat = mobArkalik * birimFiyatlar[30];

            mobToplamAlan = 0.00;

            //Alt Mobilya alan hesabı
            //MessageBox.Show("Boy:" + mobBoy.ToString() + " En: " + mobEn.ToString() + " Yükseklik: " + mobYukseklik.ToString());
            mobToplamAlan = mobBoy * mobYukseklik;
            mobToplamAlan = mobToplamAlan + (mobEn * mobYukseklik * 2);
            mobToplamAlan = mobToplamAlan + (mobEn * mobBoy);
            mobToplamAlan = mobToplamAlan / 10000;

            //MessageBox.Show("Alan1:" + mobToplamAlan.ToString());


            //taç mobilya alan hesabı
            mobBoyIcAlan = mobBoy * ((tacYuksekligi - 6.00) * 2);
            mobEnIcAlan = mobEn * ((tacYuksekligi - 6.00) * 2);

            /*MessageBox.Show("Mobilya iç Alan Boy: " + mobBoyIcAlan.ToString());
            MessageBox.Show("Mobilya iç En Alan: " + mobEnIcAlan.ToString());*/

            tacToplamAlan = 0.00;
            tacToplamAlan = tacToplamAlan + (mobBoy * tacYuksekligi * 2);
            tacToplamAlan = tacToplamAlan + (mobEn * tacYuksekligi * 2);
            tacToplamAlan = tacToplamAlan + mobBoyIcAlan + mobEnIcAlan;


            //TaçKapak

            tacToplamAlan = tacToplamAlan + (mobEn * mobBoy);
            tacToplamAlan = tacToplamAlan / 10000;




            mobilyaToplamFiyat = (mobToplamAlan * Convert.ToDouble(mobilyaBirimFiyat)) + (tacToplamAlan * Convert.ToDouble(mobilyaBirimFiyat)) + arkalikFiyat + kulpMenteseToplam;




            /*MessageBox.Show("Alt mobilya Toplam Fiyat: " + (mobToplamAlan * Convert.ToDouble(mobilyaBirimFiyat)).ToString());
            MessageBox.Show("Taç Toplam Fiyat: " + (tacToplamAlan * Convert.ToDouble(mobilyaBirimFiyat)).ToString());
            MessageBox.Show("Arkalık Fiyat: " + arkalikFiyat.ToString());
            MessageBox.Show(kulpMenteseToplam.ToString());*/



            demirKonsolTuru = cmbDemirTuru.SelectedItem.ToString();
            /*
             Demir 30x30x1,5
Demir 40x40x2
Paslanmaz 30x30x1,5
Paslanmaz 40x40x2
Ağaç Konsol
             */
            if (demirKonsolTuru == "Demir 30x30x1,5")
            {
                demirBirimFiyat = birimFiyatlar[23];//23
            }
            else if (demirKonsolTuru == "Demir 40x40x2")
            {
                demirBirimFiyat = birimFiyatlar[24];
            }
            else if (demirKonsolTuru == "Paslanmaz 30x30x1,5")
            {
                demirBirimFiyat = birimFiyatlar[25];
            }
            else if (demirKonsolTuru == "Paslanmaz 40x40x2")
            {
                demirBirimFiyat = birimFiyatlar[26];
            }
            else if (demirKonsolTuru == "Ağaç Konsol")
            {
                demirBirimFiyat = birimFiyatlar[27];
            }

            else if (demirKonsolTuru == "Konsol Yok")
            {
                demirBirimFiyat = 0;
            }


            demirBoy = mobBoy;
            demirYukseklik = mobYukseklik;
            demirEn = mobEn;
            demirBoyAdet = 4;

            if (demirBoy <= 100)
            {
                demirYukseklikAdet = 4;
                demirEnAdet = 6;
            }
            else if (demirBoy > 100 && demirBoy < 150)
            {
                demirYukseklikAdet = 6;
                demirEnAdet = 8;
            }
            else if (demirBoy > 150)
            {
                demirYukseklikAdet = 8;
                demirEnAdet = 10;
            }

            demirToplamUzunluk = (demirBoy * demirBoyAdet) + (demirYukseklik * demirYukseklikAdet) + (demirEn * demirEnAdet);

            int elde = Convert.ToInt32(demirToplamUzunluk) % 600;
            if (elde > 0)
            {
                elde = 1;
            }
            demirProfilAdet = (Convert.ToInt32(demirToplamUzunluk) / 600) + elde;
            demirToplamFiyat = demirProfilAdet * demirBirimFiyat;

            mobilyaGenelFiyat = (mobilyaToplamFiyat + demirToplamFiyat);







        }
        public void akvaryumHesapla()
        {

            int extraClear = cmbExtraClear.SelectedIndex;
            boy = Convert.ToInt32(txtBoy.Text);
            en = Convert.ToInt32(txtEn.Text);
            yukseklik = Convert.ToInt32(txtYukseklik.Text);
            hacim = (boy * en * yukseklik) / 1000;
            double camK = (Math.Sqrt(boy) * yukseklik) / 78;



            lblHacim.Text = hacim.ToString("#.#0");
            lblCamKalinligi.Text = camKalinligi.ToString();
            buyukYanAlan = ((boy * yukseklik) / 10000.00) * 2;
            ufakYanAlan = ((en * yukseklik) / 10000.00) * 2;
            tabanCamiAlan = ((en * boy) / 10000);

            kayitlar = (((boy * 4 * kayitGenisligi) + (en * 6 * kayitGenisligi)) / 10000);
            fireAlan = ((buyukYanAlan + ufakYanAlan + tabanCamiAlan + kayitlar) / 100) * 15;
            toplamAlan = buyukYanAlan + ufakYanAlan + tabanCamiAlan + kayitlar + fireAlan;




            /*
             	
            0 3mm Düz Cam 70
            1 4mm Düz Cam 95
            2 5mm Düz Cam 105
            3 6mm Düz Cam 120
            4 8mm Düz Cam 170
            5 10mm Düz Cam 220
            6 12mm Düz Cam 330
            7 15mm Düz Cam 700
            8 19mm Düz Cam 1200
            9 20mm Düz Cam 1300
            10 24mm Düz Cam 1400
            11 3mm Extra Clear 70
            12 4mm Extra Clear 95
            13 5mm Extra Clear 105
            14 6mm Extra Clear 190
            15 8mm Extra Clear 280
            16 10mm Extra Clear 350
            17 12mm Extra Clear 450
            18 15mm Extra Clear 1000
            19 19mm Extra Clear 1400
            20 MDF 200
            21 Membran 300
            22 Lake 500
            23 Demir 30x30x1,5 180
            24 Demir 40x40x2 180
            25 Paslanmaz 30x30x1,5 350
            26 Paslanmaz 40x40x2 700
            27 Ağaç Konsol 220
            28 Kapı Kulpu 30
            29 Kapı Menteşesi 15
            30 Mobilya Arkalık 20
            */


            //akvaryumFiyat, duzCamBirimFiyat, exClBirimFiyat;
            //Cam kalınlık hesabı
            if (camK <= 3)
            {
                camKalinligi = 3.00;
                camAgirligi = toplamAlan * 7.18;
                duzCamBirimFiyat = birimFiyatlar[0];
                exClBirimFiyat = birimFiyatlar[11];
            }
            else if (camK > 3 && camK <= 4)
            {
                camKalinligi = 4.00;
                camAgirligi = toplamAlan * 9.63;
                duzCamBirimFiyat = birimFiyatlar[1];
                exClBirimFiyat = birimFiyatlar[12];
            }
            else if (camK > 4 && camK <= 5)
            {
                camKalinligi = 5.00;
                camAgirligi = toplamAlan * 21.15;
                duzCamBirimFiyat = birimFiyatlar[2];
                exClBirimFiyat = birimFiyatlar[13];
            }
            else if (camK > 5 && camK <= 6)
            {
                camKalinligi = 6.00;
                camAgirligi = toplamAlan * 14.70;
                duzCamBirimFiyat = birimFiyatlar[3];
                exClBirimFiyat = birimFiyatlar[14];
            }
            else if (camK > 6 && camK <= 8)
            {
                camKalinligi = 8.00;
                camAgirligi = toplamAlan * 19.70;
                duzCamBirimFiyat = birimFiyatlar[4];
                exClBirimFiyat = birimFiyatlar[15];
            }
            else if (camK > 8 && camK <= 10)
            {
                camKalinligi = 10.00;
                camAgirligi = toplamAlan * 24.60;
                duzCamBirimFiyat = birimFiyatlar[5];
                exClBirimFiyat = birimFiyatlar[16];
            }
            else if (camK > 10 && camK <= 12)
            {
                camKalinligi = 12.00;
                camAgirligi = toplamAlan * 30.25;
                duzCamBirimFiyat = birimFiyatlar[6];
                exClBirimFiyat = birimFiyatlar[17];
            }
            else if (camK > 12 && camK <= 15)
            {
                camKalinligi = 15.00;
                camAgirligi = toplamAlan * 36.00;
                duzCamBirimFiyat = birimFiyatlar[7];
                exClBirimFiyat = birimFiyatlar[18];
            }
            else if (camK > 15 && camK <= 19)
            {
                camKalinligi = 19.00;
                camAgirligi = toplamAlan * 45.00;
                duzCamBirimFiyat = birimFiyatlar[8];
                exClBirimFiyat = birimFiyatlar[19];
            }
            else if (camK > 19 && camK <= 20)
            {
                camKalinligi = 20.00;
                camAgirligi = toplamAlan * 50.00;
                duzCamBirimFiyat = birimFiyatlar[9];
                exClBirimFiyat = birimFiyatlar[19];
            }
            else if (camK > 20 && camK <= 24)
            {
                camKalinligi = 24.00;
                camAgirligi = toplamAlan * 60.00;
                duzCamBirimFiyat = birimFiyatlar[10];
                exClBirimFiyat = birimFiyatlar[19];
            }


            //Extra Clear Hesaplama
            if (extraClear == 0)
            {
                akvaryumFiyat = duzCamBirimFiyat * toplamAlan;
                akvaryumAciklama = "Cama Cam Rodajlı Akvaryum";
            }
            else if (extraClear == 1)
            {
                //akvaryumFiyat = ((tabanCamiAlan*1.15) * duzCamBirimFiyat) + ((ufakYanAlan*1.15) * duzCamBirimFiyat) + (((buyukYanAlan * 1.15) / 2) * duzCamBirimFiyat) + (((buyukYanAlan * 1.15) / 2) * exClBirimFiyat);
                double toplamDuzAlan = (tabanCamiAlan + ufakYanAlan + (buyukYanAlan / 2) + kayitlar) * 1.15;
                double toplamClearAlan = (buyukYanAlan / 2) * 1.15;

                akvaryumFiyat = (toplamDuzAlan * duzCamBirimFiyat) + (toplamClearAlan * exClBirimFiyat);
                akvaryumAciklama = "Ön camı Extra Clear cama cam rodajlı akvaryum";

            }
            else if (extraClear == 2)
            {
                double toplamDuzAlan = (tabanCamiAlan + (buyukYanAlan / 2) + kayitlar) * 1.15;
                double toplamClearAlan = ((buyukYanAlan / 2) + (ufakYanAlan)) * 1.15;

                akvaryumFiyat = (toplamDuzAlan * duzCamBirimFiyat) + (toplamClearAlan * exClBirimFiyat);
                akvaryumAciklama = "Ön camı ve iki yan camı Extra Clear cama cam rodajlı Akvaryum";

                //akvaryumFiyat = ((tabanCamiAlan * 1.15) * duzCamBirimFiyat) + ((ufakYanAlan * 1.15) * exClBirimFiyat) + (((buyukYanAlan * 1.15) / 2) * duzCamBirimFiyat) + (((buyukYanAlan * 1.15) / 2) * exClBirimFiyat);

            }
            else if (extraClear == 3)
            {
                double toplamDuzAlan = (tabanCamiAlan + (ufakYanAlan) + kayitlar) * 1.15;
                double toplamClearAlan = ((buyukYanAlan)) * 1.15;

                akvaryumFiyat = (toplamDuzAlan * duzCamBirimFiyat) + (toplamClearAlan * exClBirimFiyat);
                akvaryumAciklama = "Ön ve arka camı Extra Clear cama cam rodajlı akvaryum";

                //akvaryumFiyat = ((tabanCamiAlan * 1.15) * duzCamBirimFiyat) + ((ufakYanAlan * 1.15) * duzCamBirimFiyat) + ((buyukYanAlan * 1.15) * duzCamBirimFiyat);

            }
            else if (extraClear == 4)
            {
                double toplamDuzAlan = (tabanCamiAlan + kayitlar) * 1.15;
                double toplamClearAlan = (buyukYanAlan + ufakYanAlan) * 1.15;

                akvaryumFiyat = (toplamDuzAlan * duzCamBirimFiyat) + (toplamClearAlan * exClBirimFiyat);
                akvaryumAciklama = "Tamamı extra clear cama cam rodajlı akvaryum";
                //akvaryumFiyat = ((tabanCamiAlan * 1.15) * duzCamBirimFiyat) + ((ufakYanAlan * 1.15) * exClBirimFiyat) + ((buyukYanAlan * 1.15) * exClBirimFiyat);

            }

            else if (extraClear == 5)
            {
                //Ön ve bir yan

                /*double toplamDuzAlan = (tabanCamiAlan + kayitlar) * 1.15;
                double toplamClearAlan = (buyukYanAlan + ufakYanAlan) * 1.15;*/

                double toplamDuzAlan = ((buyukYanAlan / 2) + (ufakYanAlan / 2) + tabanCamiAlan + kayitlar) * 1.15;
                double toplamClearAlan = ((buyukYanAlan / 2) + (ufakYanAlan / 2)) * 1.15;

                akvaryumFiyat = (toplamDuzAlan * duzCamBirimFiyat) + (toplamClearAlan * exClBirimFiyat);
                akvaryumAciklama = "Ön ve bir yan camı Extra Clear cama cam rodajlı akvaryum";
                //akvaryumFiyat = ((tabanCamiAlan * 1.15) * duzCamBirimFiyat) + ((ufakYanAlan * 1.15) * exClBirimFiyat) + ((buyukYanAlan * 1.15) * exClBirimFiyat);

            }

            else if (extraClear == 6)
            {
                //Ön Bir yan ve Arka
                double toplamDuzAlan = (tabanCamiAlan + kayitlar + (ufakYanAlan / 2)) * 1.15;
                double toplamClearAlan = (buyukYanAlan + (ufakYanAlan / 2)) * 1.15;

                akvaryumFiyat = (toplamDuzAlan * duzCamBirimFiyat) + (toplamClearAlan * exClBirimFiyat);
                akvaryumAciklama = "Ön camı, bir yan ve arka camı Extra Clear cama cam rodajlı akvaryum";
                //akvaryumFiyat = ((tabanCamiAlan * 1.15) * duzCamBirimFiyat) + ((ufakYanAlan * 1.15) * exClBirimFiyat) + ((buyukYanAlan * 1.15) * exClBirimFiyat);

            }




            /*MessageBox.Show(toplamAlan.ToString());
            MessageBox.Show(camAgirligi.ToString());*/


            lblHacim.Text = hacim.ToString("N0");
            lblCamKalinligi.Text = camKalinligi.ToString();
            /*MessageBox.Show("BüyükYan: " + buyukYanAlan.ToString() + "\n" +
                "Ufak Yan: " + ufakYanAlan.ToString() + "\n" +
                "Taban Camı: " + tabanCamiAlan.ToString() + "\n" +
                "Kayıtlar: " + kayitlar.ToString() + "\n" +
                "Fire: " + fireAlan.ToString() + "\n" +
                "Toplam Alan: " + toplamAlan.ToString() + "\n" +
                "Toplam Fiyat: " + akvaryumFiyat.ToString());*/


        }

        public void sayiKontrol(object sender)
        {
            if (sender is TextBox)
            {
                string text = (sender as TextBox).Text;

                try
                {
                    int a = Convert.ToInt32(text);
                }
                catch
                {
                    (sender as TextBox).Text = "";
                }
            }
        }
    }

}
