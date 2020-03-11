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

namespace AquaResifPanel
{
    public partial class tekliflerFormu : Form
    {
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
                if (txtTeklifNoAra.Text.Length>0)
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
            if (lblTeklifNo.Text!="...")
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
            if (lblTeklifNo.Text!="...")
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
            if (lblTeklifNo.Text!="...")
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
            if (lblTeklifNo.Text!="...")
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
    }


}

