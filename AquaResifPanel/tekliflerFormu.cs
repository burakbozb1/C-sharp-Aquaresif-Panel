using Newtonsoft.Json;
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

namespace AquaResifPanel
{
    public partial class tekliflerFormu : Form
    {
        Excel.Application excelDosya;

        teklifVerileri.RootObject tRoot = new teklifVerileri.RootObject();
        teklifVerileri.TumUrunler tUrunler;
        teklifVerileri.TumUrunler tVeriler;
        JArray gelenTeklifler;
        DataTable dtUrunler = new DataTable();
        string cikarilacakUrun;

        public tekliflerFormu()
        {
            InitializeComponent();
        }

        private void txtMusteriAdiAra_TextChanged(object sender, EventArgs e)
        {

        }

        private void tekliflerFormu_Load(object sender, EventArgs e)
        {
            btnTeklifAra.Enabled = false;
            grpMusteriAd.Visible = false;
            grpTarih.Visible = false;
            grpTeklifNo.Visible = false;
            grpMusteriAd.Left = rdbMusteriAdi.Left;
            grpTarih.Left = rdbMusteriAdi.Left;
            grpTeklifNo.Left = rdbMusteriAdi.Left;
            int topNokta = rdbTarih.Top;
            topNokta += 60;
            grpMusteriAd.Top = topNokta;
            grpTarih.Top = topNokta;
            grpTeklifNo.Top = topNokta;


            /*DataColumn tUrunKatAdi = new DataColumn();
            tUrunKatAdi.ColumnName = "tUrunKatAdi";
            dtSecilenUrunler.Columns.Add(tUrunKatAdi);
            
            tVeriler.urunKatAdi = gelenVeriler[i]["urunKatAdi"].ToString().Trim();
                            tVeriler.urunAdi = gelenVeriler[i]["urunAdi"].ToString().Trim();
                            tVeriler.urunAciklama = gelenVeriler[i]["urunAciklama"].ToString().Trim();
                            tVeriler.marka = gelenVeriler[i]["urunMarka"].ToString().Trim();
                            tVeriler.adet = gelenVeriler[i]["urunAdet"].ToString().Trim();
                            tVeriler.fiyat = gelenVeriler[i]["urunBirimFiyat"].ToString().Trim();
                            tVeriler.toplamFiyat = gelenVeriler[i]["urunToplamFiyat"].ToString().Trim();
             
             */
            DataColumn cKatAdi = new DataColumn();
            cKatAdi.ColumnName = "Kategori";
            dtUrunler.Columns.Add(cKatAdi);

            DataColumn cUrunAdi = new DataColumn();
            cUrunAdi.ColumnName = "Ürün";
            dtUrunler.Columns.Add(cUrunAdi);

            DataColumn cUrunAciklama = new DataColumn();
            cUrunAciklama.ColumnName = "Açıklama";
            dtUrunler.Columns.Add(cUrunAciklama);

            DataColumn cMarka = new DataColumn();
            cMarka.ColumnName = "Marka";
            dtUrunler.Columns.Add(cMarka);

            DataColumn cAdet = new DataColumn();
            cAdet.ColumnName = "Adet";
            dtUrunler.Columns.Add(cAdet);

            DataColumn cBirimFiyat = new DataColumn();
            cBirimFiyat.ColumnName = "Birim Fiyat";
            dtUrunler.Columns.Add(cBirimFiyat);

            DataColumn cToplamFiyat = new DataColumn();
            cToplamFiyat.ColumnName = "Toplam Fiyat";
            dtUrunler.Columns.Add(cToplamFiyat);


        }

        private void rdbMusteriAdi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMusteriAdi.Checked)
            {
                grpMusteriAd.Visible = true;
                grpTarih.Visible = false;
                grpTeklifNo.Visible = false;
                btnTeklifAra.Enabled = true;
            }

        }

        private void rdbTeklifNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTeklifNo.Checked)
            {
                grpMusteriAd.Visible = false;
                grpTarih.Visible = false;
                grpTeklifNo.Visible = true;
                btnTeklifAra.Enabled = true;
            }
        }

        private void rdbTarih_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTarih.Checked)
            {
                grpMusteriAd.Visible = false;
                grpTarih.Visible = true;
                grpTeklifNo.Visible = false;
                btnTeklifAra.Enabled = true;
            }
        }

        private void btnTeklifAra_Click(object sender, EventArgs e)
        {
            if (rdbMusteriAdi.Checked)
            {
                string arananIsim = txtMusteriAdiAra.Text;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/teklifAraAd");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        secilenAd = arananIsim
                    });

                    streamWriter.Write(json);


                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    lstTeklifler.Items.Clear();
                    var result = streamReader.ReadToEnd();
                    gelenTeklifler = JArray.Parse(result);
                    //MessageBox.Show(gelenVeriler.ToString());
                    if (gelenTeklifler.Count < 1)
                    {
                        MessageBox.Show("Teklif Bulunamadı");
                    }
                    else
                    {
                        for (int i = 0; i < gelenTeklifler.Count; i++)
                        {
                            lstTeklifler.Items.Add(gelenTeklifler[i]["teklif_no"] + "\t" + gelenTeklifler[i]["musteri"]);
                        }
                    }

                }
            }
            else if (rdbTeklifNo.Checked)
            {
                if (txtTeklifNoAra.Text.Length > 0)
                {
                    string arananTeklifNo = txtTeklifNoAra.Text;
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/teklifAraTeklifNo");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            secilenNo = arananTeklifNo
                        });

                        streamWriter.Write(json);


                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        lstTeklifler.Items.Clear();
                        var result = streamReader.ReadToEnd();
                        gelenTeklifler = JArray.Parse(result);
                        //MessageBox.Show(gelenVeriler.ToString());
                        if (gelenTeklifler.Count < 1)
                        {
                            MessageBox.Show("Teklif Bulunamadı");
                        }
                        else
                        {
                            lstTeklifler.Items.Add(gelenTeklifler[0]["teklif_no"] + "\t" + gelenTeklifler[0]["musteri"]);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Geçerli bir teklif numarası girin");
                }
            }
            else if (rdbTarih.Checked)
            {

            }
        }

        private void lstTeklifler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenTeklifNo;
            int secilenIndex = lstTeklifler.SelectedIndex;
            if (lstTeklifler.SelectedItems.Count > 0)
            {
                int indexNo = lstTeklifler.SelectedItems[0].ToString().IndexOf("\t");
                secilenTeklifNo = (lstTeklifler.SelectedItems[0]).ToString().Substring(0, indexNo);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/teklifAraBilgiler");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        secilenNo = secilenTeklifNo
                    });

                    streamWriter.Write(json);


                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JArray gelenVeriler = JArray.Parse(result);
                    //MessageBox.Show(gelenVeriler.ToString());
                    if (gelenVeriler.Count < 1)
                    {
                        MessageBox.Show("Teklif Bulunamadı");
                    }
                    else
                    {
                        /*
                        teklif_no Küçükten Büyüğe 1
musteri
ilgiliKisi
email
gsm
konu
teslimYeri
odemeSekli
teslimSuresi
tarih
toplamFiyat
teklifVeren*/
                        //MessageBox.Show(gelenTeklifler.Count.ToString());
                        dtUrunler.Rows.Clear();

                        tRoot.teklif_no = secilenTeklifNo;
                        tRoot.musteri = gelenTeklifler[secilenIndex]["musteri"].ToString().Trim();
                        tRoot.ilgiliKisi = gelenTeklifler[secilenIndex]["ilgiliKisi"].ToString().Trim();
                        tRoot.email = gelenTeklifler[secilenIndex]["email"].ToString().Trim();
                        tRoot.gsm = gelenTeklifler[secilenIndex]["gsm"].ToString().Trim();
                        tRoot.konu = gelenTeklifler[secilenIndex]["konu"].ToString().Trim();
                        tRoot.teslimYeri = gelenTeklifler[secilenIndex]["teslimYeri"].ToString().Trim();
                        tRoot.odemeSekli = gelenTeklifler[secilenIndex]["odemeSekli"].ToString().Trim();
                        tRoot.teslimSuresi = gelenTeklifler[secilenIndex]["teslimSuresi"].ToString().Trim();
                        tRoot.tarih = gelenTeklifler[secilenIndex]["tarih"].ToString().Trim();
                        tRoot.toplamFiyat = gelenTeklifler[secilenIndex]["toplamFiyat"].ToString().Trim();
                        tRoot.teklifVeren = gelenTeklifler[secilenIndex]["teklifVeren"].ToString().Trim();
                        tRoot.tumUrunler = new List<teklifVerileri.TumUrunler>();

                        /*MessageBox.Show("Teklif no " + tRoot.teklif_no);
                        MessageBox.Show("Müşteri " + tRoot.musteri);
                        MessageBox.Show("İglili kişi " + tRoot.ilgiliKisi);
                        MessageBox.Show("Mail " + tRoot.email);
                        MessageBox.Show("gsm " + tRoot.gsm);
                        MessageBox.Show("konu " + tRoot.konu);
                        MessageBox.Show("teslim yeri " + tRoot.teslimYeri);
                        MessageBox.Show("Ödeme şekli " + tRoot.odemeSekli);
                        MessageBox.Show("teslim süresi " + tRoot.teslimSuresi);
                        MessageBox.Show("tarih " + tRoot.tarih);
                        MessageBox.Show("toplam fiyat " + tRoot.toplamFiyat);
                        MessageBox.Show("teklif veren " + tRoot.teklifVeren);*/
                        tUrunler = new teklifVerileri.TumUrunler();


                        for (int i = 0; i < gelenVeriler.Count; i++)
                        {
                            tVeriler = new teklifVerileri.TumUrunler();

                            tVeriler.urunKatAdi = gelenVeriler[i]["urunKatAdi"].ToString().Trim();
                            tVeriler.urunAdi = gelenVeriler[i]["urunAdi"].ToString().Trim();
                            tVeriler.urunAciklama = gelenVeriler[i]["urunAciklama"].ToString().Trim();
                            tVeriler.marka = gelenVeriler[i]["urunMarka"].ToString().Trim();
                            tVeriler.adet = gelenVeriler[i]["urunAdet"].ToString().Trim();
                            tVeriler.fiyat = gelenVeriler[i]["urunBirimFiyat"].ToString().Trim();
                            tVeriler.toplamFiyat = gelenVeriler[i]["urunToplamFiyat"].ToString().Trim();

                            tRoot.tumUrunler.Add(tVeriler);

                            dtUrunler.Rows.Add(tVeriler.urunKatAdi,
                                tVeriler.urunAdi,
                                tVeriler.urunAciklama,
                                tVeriler.marka,
                                tVeriler.adet,
                                tVeriler.fiyat,
                                tVeriler.toplamFiyat);

                        }



                        dtListelenenler.DataSource = dtUrunler;

                    }

                }

            }
            bilgiGoruntule();
        }
        public void bilgiGoruntule()
        {
            lblTeklifNo.Text = tRoot.teklif_no;
            txtMusteri.Text = tRoot.musteri;
            txtIlgiliKisi.Text = tRoot.ilgiliKisi;
            txtEmail.Text = tRoot.email;
            txtGsm.Text = tRoot.gsm;
            txtKonu.Text = tRoot.konu;
            txtTeslimYeri.Text = tRoot.teslimYeri;
            txtOdemeSekli.Text = tRoot.odemeSekli;
            txtTeslimSuresi.Text = tRoot.teslimSuresi;
            lblTarih.Text = tRoot.tarih;
            lblTeklifVeren.Text = tRoot.teklifVeren;
            lblToplamFiyat.Text = tRoot.toplamFiyat;
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (lblTeklifNo.Text != "...")
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
                    /*urunVerileri[0] = "Eklendi";
                        urunVerileri[1] = txtUrunAdi.Text;
                        urunVerileri[2] = "Eklendi";
                        urunVerileri[3] = txtKatAdi.Text;
                        urunVerileri[4] = txtUrunAciklama.Text;
                        urunVerileri[5] = txtUrunFiyat.Text;
                        urunVerileri[6] = txtUrunMarka.Text;
                        urunVerileri[7] = txtUrunAdedi.Text;*/
                    double tFiyat = 0;
                    tFiyat = Convert.ToDouble(elleGelenVeriler[7]) * Convert.ToDouble(elleGelenVeriler[5]);

                    teklifVerileri.TumUrunler tYeniVeri = new teklifVerileri.TumUrunler();

                    tYeniVeri.urunKatAdi = elleGelenVeriler[3];
                    tYeniVeri.urunAdi = elleGelenVeriler[1];
                    tYeniVeri.urunAciklama = elleGelenVeriler[4];
                    tYeniVeri.marka = elleGelenVeriler[6];
                    tYeniVeri.adet = elleGelenVeriler[7];
                    tYeniVeri.fiyat = elleGelenVeriler[5];
                    tYeniVeri.toplamFiyat = tFiyat.ToString("N2");

                    tRoot.tumUrunler.Add(tYeniVeri);


                    dtUrunler.Rows.Add(elleGelenVeriler[3],
                        elleGelenVeriler[1],
                        elleGelenVeriler[4],
                        elleGelenVeriler[6],
                        elleGelenVeriler[7],
                        elleGelenVeriler[5],
                        tFiyat.ToString("N2"));






                }
                toplamHesapla();
            }
            else
            {
                MessageBox.Show("Geçerli bir teklif numarası alınamadı");
            }
        }

        private void btnUrunCikar_Click(object sender, EventArgs e)
        {
            if (lblTeklifNo.Text != "...")
            {
                for (int i = 0; i < tRoot.tumUrunler.Count; i++)
                {
                    if (tRoot.tumUrunler[i].urunAdi == cikarilacakUrun)
                    {
                        tRoot.tumUrunler.RemoveAt(i);
                        dtUrunler.Rows.RemoveAt(i);

                    }

                }
                dtListelenenler.DataSource = dtUrunler;
                toplamHesapla();
            }
            else
            {
                MessageBox.Show("Geçerli bir teklif numarası alıanamadı");
            }


        }

        private void dtListelenenler_SelectionChanged(object sender, EventArgs e)
        {
            if (dtListelenenler.SelectedRows.Count > 0)
            {
                cikarilacakUrun = dtListelenenler.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        public void toplamHesapla()
        {
            double araToplam = 0;
            if (dtListelenenler.Rows.Count > 0)
            {
                for (int i = 0; i < dtListelenenler.Rows.Count; i++)
                {
                    //MessageBox.Show(dtListelenenler.Rows[i].Cells[5].Value.ToString());
                    araToplam += Convert.ToDouble(dtListelenenler.Rows[i].Cells[6].Value);
                }
            }
            tRoot.toplamFiyat = araToplam.ToString("N2");
            lblToplamFiyat.Text = tRoot.toplamFiyat;
        }

        private void btnTeklifGuncelle_Click(object sender, EventArgs e)
        {
            if (lblTeklifNo.Text != "...")
            {
                tRoot.musteri = txtMusteri.Text;
                tRoot.ilgiliKisi = txtIlgiliKisi.Text;
                tRoot.email = txtEmail.Text;
                tRoot.gsm = txtGsm.Text;
                tRoot.konu = txtKonu.Text;
                tRoot.teslimYeri = txtTeslimYeri.Text;
                tRoot.odemeSekli = txtOdemeSekli.Text;
                tRoot.teslimSuresi = txtTeslimSuresi.Text;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/teklifGuncelle");
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
                    MessageBox.Show(result.ToString());

                }


                tekliflerFormu yeniForm = new tekliflerFormu();
                yeniForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Geçerli bir teklif numarası alınamadı");
            }

        }

        private void btnTeklifSil_Click(object sender, EventArgs e)
        {
            if (lblTeklifNo.Text != "...")
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/teklifSil");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        teklif_no = lblTeklifNo.Text
                    });

                    streamWriter.Write(json);


                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    MessageBox.Show(result.ToString());
                }
                tekliflerFormu yeniForm = new tekliflerFormu();
                yeniForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Geçerli bir teklif numarası alınamadı");
            }

        }

        private void btnSiparisYazdir_Click(object sender, EventArgs e)
        {
            /*MessageBox.Show("Teklif no " + tRoot.teklif_no);
            MessageBox.Show("Müşteri " + tRoot.musteri);
            MessageBox.Show("İglili kişi " + tRoot.ilgiliKisi);
            MessageBox.Show("Mail " + tRoot.email);
            MessageBox.Show("gsm " + tRoot.gsm);
            MessageBox.Show("konu " + tRoot.konu);
            MessageBox.Show("teslim yeri " + tRoot.teslimYeri);
            MessageBox.Show("Ödeme şekli " + tRoot.odemeSekli);
            MessageBox.Show("teslim süresi " + tRoot.teslimSuresi);
            MessageBox.Show("tarih " + tRoot.tarih);
            MessageBox.Show("toplam fiyat " + tRoot.toplamFiyat);
            MessageBox.Show("teklif veren " + tRoot.teklifVeren);*/


            /*//Müşteri Bilgileri
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
            akvaryumBilgileri[4, 2] = camKalinligi.ToString();*/


            string[,] akvaryumBilgileri = new string[5, 3];
            akvaryumBilgileri[0, 0] = "Boy";
            akvaryumBilgileri[0, 1] = ":";
            akvaryumBilgileri[0, 2] = "";
            akvaryumBilgileri[1, 0] = "En(Derinlik)";
            akvaryumBilgileri[1, 1] = ":";
            akvaryumBilgileri[1, 2] = "";
            akvaryumBilgileri[2, 0] = "Yükseklik";
            akvaryumBilgileri[2, 1] = ":";
            akvaryumBilgileri[2, 2] = "";
            akvaryumBilgileri[3, 0] = "Hacim";
            akvaryumBilgileri[3, 1] = ":";
            akvaryumBilgileri[3, 2] = "";
            akvaryumBilgileri[4, 0] = "Cam Kalınlığı";
            akvaryumBilgileri[4, 1] = ":";
            akvaryumBilgileri[4, 2] = "";

            string[,] musteriBilgileri = new string[5, 3];
            musteriBilgileri[0, 0] = "Müşteri";
            musteriBilgileri[0, 1] = ":";
            musteriBilgileri[0, 2] = tRoot.musteri;

            musteriBilgileri[1, 0] = "İlgili Kişi";
            musteriBilgileri[1, 1] = ":";
            musteriBilgileri[1, 2] = tRoot.ilgiliKisi;

            musteriBilgileri[2, 0] = "E-Mail";
            musteriBilgileri[2, 1] = ":";
            musteriBilgileri[2, 2] = tRoot.email;

            musteriBilgileri[3, 0] = "GSM";
            musteriBilgileri[3, 1] = ":";
            musteriBilgileri[3, 2] = tRoot.gsm;

            musteriBilgileri[4, 0] = "Konu";
            musteriBilgileri[4, 1] = ":";
            musteriBilgileri[4, 2] = tRoot.konu;


            string[,] teklifBilgileri = new string[5, 3];
            teklifBilgileri[0, 0] = "Teklif No";
            teklifBilgileri[0, 1] = ":";
            teklifBilgileri[0, 2] = tRoot.teklif_no;

            teklifBilgileri[1, 0] = "Teslim Yeri";
            teklifBilgileri[1, 1] = ":";
            teklifBilgileri[1, 2] = tRoot.teslimYeri;

            teklifBilgileri[2, 0] = "Ödeme Şekli";
            teklifBilgileri[2, 1] = ":";
            teklifBilgileri[2, 2] = tRoot.odemeSekli;

            teklifBilgileri[3, 0] = "Teslim Süresi";
            teklifBilgileri[3, 1] = ":";
            teklifBilgileri[3, 2] = tRoot.teslimSuresi;

            teklifBilgileri[4, 0] = "Teklif Veren";
            teklifBilgileri[4, 1] = ":";
            teklifBilgileri[4, 2] = tRoot.teklifVeren;



            string[,] urunBilgileri = new string[tRoot.tumUrunler.Count, 6];
            string[,] genelToplam = new string[3, 3];

            //dtTeklifUrunler
            for (int i = 0; i < tRoot.tumUrunler.Count; i++)
            {
                urunBilgileri[i, 0] = tRoot.tumUrunler[i].urunKatAdi;
                urunBilgileri[i, 1] = tRoot.tumUrunler[i].urunAdi;
                urunBilgileri[i, 2] = tRoot.tumUrunler[i].marka;
                urunBilgileri[i, 3] = tRoot.tumUrunler[i].adet;
                urunBilgileri[i, 4] = tRoot.tumUrunler[i].fiyat;
                double fiyat, adet;
                fiyat = Convert.ToDouble(tRoot.tumUrunler[i].fiyat);
                adet = Convert.ToDouble(tRoot.tumUrunler[i].adet);
                urunBilgileri[i, 5] = (fiyat * adet).ToString();

            }


            //Genel Toplam Bilgileri

            double toplamFiyat = 0;

            for (int i = 0; i < tRoot.tumUrunler.Count; i++)
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



            //Akvaryum Bilgileri girildi

            for (int i = 0; i < tRoot.tumUrunler.Count; i++)
            {
                string urun = tRoot.tumUrunler[i].urunAdi;
                if (urun.IndexOf(" Akvaryum") != -1)
                {
                    int iNo = urun.IndexOf(" Akvaryum");
                    string parca1 = "", parca2 = "", parca3 = "", gecici = "";
                    parca1 = urun.Substring(0, urun.IndexOf("x"));
                    gecici = urun.Substring(parca1.Length + 1);
                    parca2 = gecici.Substring(0, gecici.IndexOf("x"));
                    gecici = gecici.Substring(parca2.Length + 1, parca2.Length);
                    parca3 = gecici;


                    akvaryumBilgileri[0, 2] = parca1;
                    akvaryumBilgileri[1, 2] = parca2;
                    akvaryumBilgileri[2, 2] = parca3;

                    double p1, p2, p3;
                    p1 = Convert.ToDouble(parca1);
                    p2 = Convert.ToDouble(parca2);
                    p3 = Convert.ToDouble(parca3);

                    double hacim = (p1 / 10) * (p2 / 10) * (p3 / 10);
                    akvaryumBilgileri[3, 2] = hacim.ToString("N0");
                    MessageBox.Show(hacim.ToString());

                    double camK = (Math.Sqrt(p1) * p3) / 78;


                    if (camK <= 3)
                    {
                        akvaryumBilgileri[4, 2] = "3";
                    }
                    else if (camK > 3 && camK <= 4)
                    {
                        akvaryumBilgileri[4, 2] = "4";
                    }
                    else if (camK > 4 && camK <= 5)
                    {
                        akvaryumBilgileri[4, 2] = "5";
                    }
                    else if (camK > 5 && camK <= 6)
                    {
                        akvaryumBilgileri[4, 2] = "6";
                    }
                    else if (camK > 6 && camK <= 8)
                    {
                        akvaryumBilgileri[4, 2] = "8";
                    }
                    else if (camK > 8 && camK <= 10)
                    {
                        akvaryumBilgileri[4, 2] = "10";
                    }
                    else if (camK > 10 && camK <= 12)
                    {
                        akvaryumBilgileri[4, 2] = "12";
                    }
                    else if (camK > 12 && camK <= 15)
                    {
                        akvaryumBilgileri[4, 2] = "15";
                    }
                    else if (camK > 15 && camK <= 19)
                    {
                        akvaryumBilgileri[4, 2] = "19";
                    }
                    else if (camK > 19 && camK <= 20)
                    {
                        akvaryumBilgileri[4, 2] = "20";
                    }
                    else if (camK > 20 && camK <= 24)
                    {
                        akvaryumBilgileri[4, 2] = "24";
                    }



                    //akvaryumBilgileri[4, 2] = "0";
                }
            }


            Microsoft.Office.Interop.Excel.Shape shape;
            shape = sheet1.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 225, 255, 60, 20);
            shape.TextFrame2.TextRange.Text = akvaryumBilgileri[2, 2] + " cm";

            shape = sheet1.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 300, 275, 60, 20);
            shape.TextFrame2.TextRange.Text = akvaryumBilgileri[0, 2] + " cm";

            shape = sheet1.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 410, 270, 60, 20);
            shape.TextFrame2.TextRange.Text = akvaryumBilgileri[1, 2] + " cm";




            sheet1.Range[sheet1.Cells[2, 1], sheet1.Cells[2, 10]].Merge();//Tarih
            Excel.Range rangelTarih = sheet1.Cells[2, 1];
            rangelTarih.Value2 = tRoot.tarih;
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
            string araYazi = "Akvaryum projesi ile ilgili teklif ve teknik detayları aşağıda bilgilerinize sunulmaktadır.\n" +
                "Firmamızdan teklif istemekle göstermiş olduğunuz ilgiye teşekkür eder, değerli siparişlerinizi bekleriz";
            sheet1.Range[sheet1.Cells[9, 1], sheet1.Cells[9, 10]].Merge();
            Excel.Range araDuzYazi = sheet1.Cells[9, 1];
            araDuzYazi.RowHeight = 26.25;
            araDuzYazi.Value2 = araYazi;



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



            //--------------------------
            //Ürünler İçerik Girildi

            for (int i = 0; i < tRoot.tumUrunler.Count; i++)
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


            int gToplamBaslangic = 19 + tRoot.tumUrunler.Count + 2;

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


            //--------------


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
            //sheet1.Cells[altBilgiBaslangic, 1].Font.Bold = true;

            sheet1.Columns.AutoFit();


            //---
            string dosyaAdi = tRoot.teklif_no + " - Teklif -" + tRoot.tarih + ".xlsx";
            calismaKitabi.SaveAs(dosyaAdi, Excel.XlFileFormat.xlWorkbookDefault);
            excelDosya.Workbooks.Close();
            excelDosya.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelDosya);
            MessageBox.Show("Bitti");
        }
    }


}

