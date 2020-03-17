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

namespace AquaResifPanel
{
    public partial class siparisOlusturFormu : Form
    {
        SiparisObj.Siparis sipObj = new SiparisObj.Siparis();
        SiparisObj.AkvaryumOlculer geciciAkvaryum = new SiparisObj.AkvaryumOlculer();
        int boy, en, yukseklik, mobilyaYukseklik;
        double konsolKalinlik;
        int sapkaYukseklik = 15;


        JArray gelenTeklifler;

        public siparisOlusturFormu()
        {
            InitializeComponent();
        }

        private void siparisOlusturFormu_Load(object sender, EventArgs e)
        {
            txtTeklifNo.Text = "0320200063";

            sipObj.tumUrunler = new List<SiparisObj.TumUrunler>();
            sipObj.akvaryumOlculer = new List<SiparisObj.AkvaryumOlculer>();
            sipObj.kayitlar = new List<SiparisObj.Kayitlar>();
            sipObj.mobilyaOlculer = new List<SiparisObj.MobilyaOlculer>();
            sipObj.konsolOlculer = new List<SiparisObj.KonsolOlculer>();

            sipObj.akvaryumBase = new SiparisObj.AkvaryumBase();
            sipObj.mobilyaBase = new SiparisObj.MobilyaBase();
            sipObj.konsolBase = new SiparisObj.KonsolBase();

            chcOnExCl.Enabled = false;
            chcArkaExCl.Enabled = false; 
            chcSolExCl.Enabled = false;
            chcSagExCl.Enabled = false;
            chcTabanExCl.Enabled = false;

            /*SiparisObj.TumUrunler yeniUrun = new SiparisObj.TumUrunler();
            SiparisObj.AkvaryumOlculer akvOlculer = new SiparisObj.AkvaryumOlculer();

            sipObj.siparisNo = "123456";
            sipObj.musteri = "Boz Bilişim";
            sipObj.konu = "Deniz Akvaryumu";
            sipObj.teslimYeri = "Ataşehir";
            sipObj.teslimSuresi = "30 iş günü";
            sipObj.teklifVeren = "Salih Torun";
            sipObj.aciklama = "Açıklama metni";
            sipObj.tarih = "01.01.2020";

            sipObj.tumUrunler = new List<SiparisObj.TumUrunler>();
            sipObj.akvaryumOlculer = new List<SiparisObj.AkvaryumOlculer>();
            sipObj.kayitlar = new List<SiparisObj.Kayitlar>();
            sipObj.mobilyaOlculer = new List<SiparisObj.MobilyaOlculer>();
            sipObj.konsolOlculer = new List<SiparisObj.KonsolOlculer>();

            sipObj.akvaryumBase = new SiparisObj.AkvaryumBase();
            sipObj.mobilyaBase = new SiparisObj.MobilyaBase();
            sipObj.konsolBase = new SiparisObj.KonsolBase();

            yeniUrun.urunKatAdi = "Sump Malzemeleri";
            yeniUrun.urunAdi = "T Boru";
            yeniUrun.urunAciklama = "Sump bağlantı elemanı";
            yeniUrun.marka = "Fırat Boru";
            yeniUrun.adet = 5;
            yeniUrun.fiyat = 25.1;
            yeniUrun.toplamFiyat = yeniUrun.adet * yeniUrun.fiyat;

            
            sipObj.tumUrunler.Add(yeniUrun);
            sipObj.tumUrunler.Add(yeniUrun);

            sipObj.akvaryumBase.silikonRengi = "Siyah";
            sipObj.akvaryumBase.camKalinligi = 20;

            akvOlculer.camAdi = "Ön cam";
            akvOlculer.camX = 211.1;
            akvOlculer.camY = 90.1;
            akvOlculer.camTipi = "ExtraClear";

            sipObj.akvaryumOlculer.Add(akvOlculer);

            akvOlculer.camAdi = "Arka cam";
            akvOlculer.camX = 211.1;
            akvOlculer.camY = 90.1;
            akvOlculer.camTipi = "ExtraClear";

            sipObj.akvaryumOlculer.Add(akvOlculer);

            akvOlculer.camAdi = "Sol yan cam";
            akvOlculer.camX = 211.1;
            akvOlculer.camY = 90.1;
            akvOlculer.camTipi = "ExtraClear";

            sipObj.akvaryumOlculer.Add(akvOlculer);

            akvOlculer.camAdi = "Sağ yan cam";
            akvOlculer.camX = 211.1;
            akvOlculer.camY = 90.1;
            akvOlculer.camTipi = "ExtraClear";

            sipObj.akvaryumOlculer.Add(akvOlculer);

            akvOlculer.camAdi = "Taban camı";
            akvOlculer.camX = 211.1;
            akvOlculer.camY = 90.1;
            akvOlculer.camTipi = "ExtraClear";

            sipObj.akvaryumOlculer.Add(akvOlculer);

            MessageBox.Show(sipObj.akvaryumOlculer.Count.ToString());
            string json = new JavaScriptSerializer().Serialize(sipObj);
            MessageBox.Show(json);*/

            /*var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/teklifNo");
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
            }*/



        }

        private void btnTeklifGetir_Click(object sender, EventArgs e)
        {
            /* SiparisObj.TumUrunler yeniUrun = new SiparisObj.TumUrunler();
             SiparisObj.AkvaryumOlculer akvOlculer = new SiparisObj.AkvaryumOlculer();*/

            string arananTeklifNo = txtTeklifNo.Text;
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
                var result = streamReader.ReadToEnd();
                gelenTeklifler = JArray.Parse(result);
                //MessageBox.Show(gelenVeriler.ToString());
                if (gelenTeklifler.Count < 1)
                {
                    MessageBox.Show("Teklif Bulunamadı");
                }
                else
                {


                    //MessageBox.Show(gelenTeklifler[0]["teklif_no"] + "\t" + gelenTeklifler[0]["musteri"]);
                    string secilenTeklifNo = gelenTeklifler[0]["teklif_no"].ToString();
                    var httpWebRequestUrunler = (HttpWebRequest)WebRequest.Create("http://localhost:8080/teklifAraBilgiler");
                    httpWebRequestUrunler.ContentType = "application/json";
                    httpWebRequestUrunler.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequestUrunler.GetRequestStream()))
                    {
                        string json = new JavaScriptSerializer().Serialize(new
                        {
                            secilenNo = secilenTeklifNo
                        });

                        streamWriter.Write(json);
                        //MessageBox.Show(json.ToString());

                    }






                    var httpResponseUrunler = (HttpWebResponse)httpWebRequestUrunler.GetResponse();
                    using (var streamReaderUrunler = new StreamReader(httpResponseUrunler.GetResponseStream()))
                    {
                        var resultUrunler = streamReaderUrunler.ReadToEnd();
                        JArray gelenVeriler = JArray.Parse(resultUrunler);
                        //MessageBox.Show(gelenVeriler.ToString());
                        if (gelenVeriler.Count < 1)
                        {
                            MessageBox.Show("Teklif Bulunamadı");
                        }
                        else
                        {
                            //MessageBox.Show(gelenVeriler.Count.ToString());


                            //SiparisObj.AkvaryumOlculer akvOlculer = new SiparisObj.AkvaryumOlculer();


                            sipObj.siparisNo = gelenTeklifler[0]["teklif_no"].ToString();
                            sipObj.musteri = gelenTeklifler[0]["musteri"].ToString().Trim();
                            sipObj.konu = gelenTeklifler[0]["konu"].ToString().Trim();
                            sipObj.teslimYeri = gelenTeklifler[0]["teslimYeri"].ToString().Trim();
                            sipObj.teslimSuresi = gelenTeklifler[0]["teslimSuresi"].ToString().Trim();
                            sipObj.teklifVeren = gelenTeklifler[0]["teklifVeren"].ToString().Trim();
                            sipObj.aciklama = "Açıklama metni";
                            sipObj.tarih = gelenTeklifler[0]["tarih"].ToString().Trim();

                            /*dtUrunler.Rows.Clear();

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

                           
                            tUrunler = new teklifVerileri.TumUrunler();*/
                            

                            for (int i = 0; i < gelenVeriler.Count; i++)
                            {
                                //MessageBox.Show(gelenVeriler[i]["urunKatAdi"].ToString().Trim());
                                if (gelenVeriler[i]["urunKatAdi"].ToString().Trim() == "Akvaryum" || gelenVeriler[i]["urunKatAdi"].ToString().Trim() == "Sehpa" || gelenVeriler[i]["urunKatAdi"].ToString().Trim() == "Konsol")
                                {
                                    if (gelenVeriler[i]["urunKatAdi"].ToString().Trim() == "Akvaryum")
                                    {

                                        string gecici = gelenVeriler[i]["urunAdi"].ToString().Trim();
                                        boy = Convert.ToInt32(gecici.Substring(0, gecici.IndexOf("x")));
                                        gecici = gecici.Substring(boy.ToString().Length + 1, gecici.Length - (boy.ToString().Length + 1));
                                        en = Convert.ToInt32(gecici.Substring(0, gecici.IndexOf("x")));
                                        gecici = gecici.Substring(en.ToString().Length + 1, gecici.Length - (en.ToString().Length + 1));
                                        yukseklik = Convert.ToInt32(gecici.Substring(0, gecici.IndexOf(" ")));
                                    }
                                    else if (gelenVeriler[i]["urunKatAdi"].ToString().Trim() == "Sehpa")
                                    {
                                        string gecici = gelenVeriler[i]["urunAciklama"].ToString().Trim();
                                        string gecici2="";
                                        gecici = gecici.Substring(0, gecici.IndexOf(" "));
                                        gecici2 = gecici.Substring(0, gecici.IndexOf("x")+1);
                                        gecici = gecici.Substring(gecici2.Length, gecici.Length - (gecici2.Length));

                                        gecici2 = gecici.Substring(0, gecici.IndexOf("x") + 1);
                                        gecici = gecici.Substring(gecici2.Length, gecici.Length - (gecici2.Length));

                                        mobilyaYukseklik = Convert.ToInt32(gecici);
                                    }
                                    else if (gelenVeriler[i]["urunKatAdi"].ToString().Trim() == "Konsol")
                                    {
                                        string gecici = gelenVeriler[i]["urunAciklama"].ToString().Trim();
                                        if (gecici.IndexOf("Ağaç Konsol") == -1)
                                        {
                                            string gecici2 = "";
                                            gecici = gecici.Substring(0, gecici.IndexOf(" ") + 1);
                                            gecici2 = gelenVeriler[i]["urunAciklama"].ToString().Trim();

                                            //MessageBox.Show("Gecici:" + gecici + " Gecici2: " + gecici2);

                                            gecici = gecici2.Substring(gecici.Length, gecici2.IndexOf("x"));
                                            gecici = gecici.Substring(0, gecici.IndexOf("x"));

                                            //MessageBox.Show("Gecici:" + gecici + " Gecici2: " + gecici2);

                                            gecici2 = gecici2.Substring(0, gecici2.IndexOf(" Konsol"));
                                            //MessageBox.Show("Gecici:" + gecici + " Gecici2: " + gecici2);
                                            //MessageBox.Show(konsolKalinlik.ToString());
                                            sipObj.konsolBase.konsolTuru = gecici2;

                                            konsolKalinlik = Convert.ToDouble(gecici);
                                            konsolKalinlik = konsolKalinlik / 10;


                                        }
                                        else
                                        {
                                            konsolKalinlik = Convert.ToInt32(Interaction.InputBox("Ağaç konsolun kalınlığını milimetre olarak giriniz", "Ağaç Konsol Kalınlığı", "30", 0, 0));
                                            konsolKalinlik = konsolKalinlik / 10;
                                            sipObj.konsolBase.konsolTuru = "Ağaç Konsol";
                                            //MessageBox.Show("Girilen isim: " + IsimGirisi);
                                        }
                                        sipObj.konsolBase.konsolKalinligi = konsolKalinlik;
                                        MessageBox.Show("Konsol Kalınlığı "+konsolKalinlik.ToString());
                                        
                                    }
                                }
                                else
                                {
                                    SiparisObj.TumUrunler yeniUrun = new SiparisObj.TumUrunler();
                                    yeniUrun.urunKatAdi = gelenVeriler[i]["urunKatAdi"].ToString().Trim();
                                    yeniUrun.urunAdi = gelenVeriler[i]["urunAdi"].ToString().Trim();
                                    yeniUrun.urunAciklama = gelenVeriler[i]["urunAciklama"].ToString().Trim();
                                    yeniUrun.marka = gelenVeriler[i]["urunMarka"].ToString().Trim();
                                    yeniUrun.adet = Convert.ToInt32(gelenVeriler[i]["urunAdet"].ToString().Trim());
                                    yeniUrun.fiyat = Convert.ToDouble(gelenVeriler[i]["urunBirimFiyat"].ToString().Trim());
                                    yeniUrun.toplamFiyat = yeniUrun.adet * yeniUrun.fiyat;


                                    sipObj.tumUrunler.Add(yeniUrun);
                                }

                                /*tVeriler = new teklifVerileri.TumUrunler();

                                tVeriler.urunKatAdi = gelenVeriler[i]["urunKatAdi"].ToString().Trim();
                                tVeriler.urunAdi = gelenVeriler[i]["urunAdi"].ToString().Trim();
                                tVeriler.urunAciklama = gelenVeriler[i]["urunAciklama"].ToString().Trim();
                                tVeriler.marka = gelenVeriler[i]["urunMarka"].ToString().Trim();
                                tVeriler.adet = gelenVeriler[i]["urunAdet"].ToString().Trim();
                                tVeriler.fiyat = gelenVeriler[i]["urunBirimFiyat"].ToString().Trim();
                                tVeriler.toplamFiyat = gelenVeriler[i]["urunToplamFiyat"].ToString().Trim();*/

                                /*tRoot.tumUrunler.Add(tVeriler);

                                dtUrunler.Rows.Add(tVeriler.urunKatAdi,
                                    tVeriler.urunAdi,
                                    tVeriler.urunAciklama,
                                    tVeriler.marka,
                                    tVeriler.adet,
                                    tVeriler.fiyat,
                                    tVeriler.toplamFiyat);*/

                            }



                            //dtListelenenler.DataSource = dtUrunler;*/

                        }
                        //MessageBox.Show(sipObj.tumUrunler.Count.ToString());

                        
                        for (int i = 0; i < gelenVeriler.Count; i++)
                        {
                            if (gelenVeriler[i]["urunKatAdi"].ToString().Trim() == "Akvaryum")
                            {
                                
                                //MessageBox.Show("boy: " + boy.ToString() + " en: " + en.ToString() + " yükseklik: " + yukseklik.ToString() + " gecici : " + gecici);
                                sipObj.akvaryumBase.camKalinligi = camK(boy, en, yukseklik);
                                double cK = (sipObj.akvaryumBase.camKalinligi) / 10.0;
                                //MessageBox.Show("Cam Kalınlığı: " + cK.ToString());




                                //Akvaryum Camlarının eklenmesi
                                SiparisObj.AkvaryumOlculer akvOnCam = new SiparisObj.AkvaryumOlculer();
                                akvOnCam.camAdi = "Ön cam";
                                akvOnCam.camX = boy;
                                akvOnCam.camY = yukseklik;
                                akvOnCam.camTipi = "Düz Cam";

                                sipObj.akvaryumOlculer.Add(akvOnCam);

                                SiparisObj.AkvaryumOlculer akvArkaCam = new SiparisObj.AkvaryumOlculer();
                                akvArkaCam.camAdi = "Arka cam";
                                akvArkaCam.camX = boy;
                                akvArkaCam.camY = yukseklik;
                                akvArkaCam.camTipi = "Düz Cam";

                                sipObj.akvaryumOlculer.Add(akvArkaCam);

                                SiparisObj.AkvaryumOlculer akvTabanCam = new SiparisObj.AkvaryumOlculer();
                                akvTabanCam.camAdi = "Taban camı";
                                akvTabanCam.camX = boy;
                                akvTabanCam.camY = en - cK;
                                akvTabanCam.camTipi = "Düz Cam";

                                sipObj.akvaryumOlculer.Add(akvTabanCam);

                                SiparisObj.AkvaryumOlculer akvSolCam = new SiparisObj.AkvaryumOlculer();
                                akvSolCam.camAdi = "Sol cam";
                                akvSolCam.camX = yukseklik - cK;
                                akvSolCam.camY = en - (cK * 2);
                                akvSolCam.camTipi = "Düz Cam";

                                sipObj.akvaryumOlculer.Add(akvSolCam);

                                SiparisObj.AkvaryumOlculer akvSagCam = new SiparisObj.AkvaryumOlculer();
                                akvSagCam.camAdi = "Sağ cam";
                                akvSagCam.camX = yukseklik - cK;
                                akvSagCam.camY = en - (cK * 2);
                                akvSagCam.camTipi = "Düz Cam";

                                sipObj.akvaryumOlculer.Add(akvSagCam);


                                //Kayıtların eklenmesi
                                SiparisObj.Kayitlar kOnArkaUst = new SiparisObj.Kayitlar();
                                kOnArkaUst.kayitAdi = "Ön, arka ve üst kayıtlar";
                                kOnArkaUst.kayitX = boy-(cK*2);
                                kOnArkaUst.kayitY = 8;
                                kOnArkaUst.kayitAdet = 2;
                                sipObj.kayitlar.Add(kOnArkaUst);

                                SiparisObj.Kayitlar ktaban = new SiparisObj.Kayitlar();
                                ktaban.kayitAdi = "Taban Kayıtları";
                                ktaban.kayitX = boy - (cK * 2);
                                ktaban.kayitY = 5;
                                ktaban.kayitAdet = 2;
                                sipObj.kayitlar.Add(ktaban);

                                SiparisObj.Kayitlar kOrta = new SiparisObj.Kayitlar();
                                kOrta.kayitAdi = "Orta Kayıt";
                                kOrta.kayitX = en-(cK*2);
                                kOrta.kayitY = 12;
                                kOrta.kayitAdet = 1;
                                sipObj.kayitlar.Add(kOrta);

                                SiparisObj.Kayitlar kAlt = new SiparisObj.Kayitlar();
                                kAlt.kayitAdi = "Yan Kayıtlar";
                                kAlt.kayitX = boy - (cK * 2);
                                kAlt.kayitY = 5;
                                kAlt.kayitAdet = 3;
                                sipObj.kayitlar.Add(kAlt);


                            }
                            else if (gelenVeriler[i]["urunKatAdi"].ToString().Trim() == "Sehpa")
                            {
                                SiparisObj.MobilyaOlculer mOnPanel = new SiparisObj.MobilyaOlculer();
                                mOnPanel.panelAdi = "Ön Panel";
                                mOnPanel.panelX = boy + 4;
                                mOnPanel.panelY = mobilyaYukseklik;
                                mOnPanel.panelAdet = 1;
                                sipObj.mobilyaOlculer.Add(mOnPanel);

                                SiparisObj.MobilyaOlculer mYanPanel = new SiparisObj.MobilyaOlculer();
                                mYanPanel.panelAdi = "Yan Paneller";
                                mYanPanel.panelX = mobilyaYukseklik;
                                mYanPanel.panelY = en;
                                mYanPanel.panelAdet = 2;
                                sipObj.mobilyaOlculer.Add(mYanPanel);

                                SiparisObj.MobilyaOlculer mAltPanel = new SiparisObj.MobilyaOlculer();
                                mAltPanel.panelAdi = "Alt Panel";
                                mAltPanel.panelX = boy-0.5;
                                mAltPanel.panelY = en-0.5;
                                mAltPanel.panelAdet = 1;
                                sipObj.mobilyaOlculer.Add(mAltPanel);

                                SiparisObj.MobilyaOlculer mArkaPanel = new SiparisObj.MobilyaOlculer();
                                mArkaPanel.panelAdi = "Arka Panel";
                                mArkaPanel.panelX = boy;
                                mArkaPanel.panelY = mobilyaYukseklik-5;
                                mArkaPanel.panelAdet = 1;
                                sipObj.mobilyaOlculer.Add(mArkaPanel);

                                SiparisObj.MobilyaOlculer sOn = new SiparisObj.MobilyaOlculer();
                                sOn.panelAdi = "Şapka ön panel";
                                sOn.panelX = boy+4;
                                sOn.panelY = sapkaYukseklik;
                                sOn.panelAdet = 1;
                                sipObj.mobilyaOlculer.Add(sOn);

                                SiparisObj.MobilyaOlculer sOnIc = new SiparisObj.MobilyaOlculer();
                                sOnIc.panelAdi = "Şapka ön ve arka paneller (İç kısım)";
                                sOnIc.panelX = boy ;
                                sOnIc.panelY = sapkaYukseklik-6;
                                sOnIc.panelAdet = 2;
                                sipObj.mobilyaOlculer.Add(sOnIc);

                                SiparisObj.MobilyaOlculer sYan = new SiparisObj.MobilyaOlculer();
                                sYan.panelAdi = "Şapka yan paneller";
                                sYan.panelX = sapkaYukseklik;
                                sYan.panelY = en+0.5;
                                sYan.panelAdet = 2;
                                sipObj.mobilyaOlculer.Add(sYan);

                                SiparisObj.MobilyaOlculer sYanIc = new SiparisObj.MobilyaOlculer();
                                sYanIc.panelAdi = "Şapka yan paneller (İç kısım)";
                                sYanIc.panelX = sapkaYukseklik;
                                sYanIc.panelY = en-4;
                                sYanIc.panelAdet = 2;
                                sipObj.mobilyaOlculer.Add(sYanIc);

                                SiparisObj.MobilyaOlculer sArka = new SiparisObj.MobilyaOlculer();
                                sArka.panelAdi = "Şapka arka panel";
                                sArka.panelX = boy-30;
                                sArka.panelY = sapkaYukseklik-1.8;
                                sArka.panelAdet = 1;
                                sipObj.mobilyaOlculer.Add(sArka);

                                SiparisObj.MobilyaOlculer sArkaIc = new SiparisObj.MobilyaOlculer();
                                sArkaIc.panelAdi = "Şapka arka panel (İç kısım)";
                                sArkaIc.panelX = boy-30;
                                sArkaIc.panelY = sapkaYukseklik-6;
                                sArkaIc.panelAdet = 1;
                                sipObj.mobilyaOlculer.Add(sArkaIc);

                                //Şapka üst kapak bilgileri eksik

                            }
                            else if (gelenVeriler[i]["urunKatAdi"].ToString().Trim() == "Konsol")
                            {
                                SiparisObj.KonsolOlculer kBoy = new SiparisObj.KonsolOlculer();
                                kBoy.konsolTur = "Boy";
                                kBoy.konsolUzunluk = boy;
                                kBoy.konsolAdet = 2;
                                sipObj.konsolOlculer.Add(kBoy);

                                SiparisObj.KonsolOlculer kYan = new SiparisObj.KonsolOlculer();
                                kYan.konsolTur = "Yan";
                                kYan.konsolUzunluk = en-(konsolKalinlik*2);
                                kYan.konsolAdet = demirYanAdet(boy);
                                sipObj.konsolOlculer.Add(kYan);

                                SiparisObj.KonsolOlculer kYuk = new SiparisObj.KonsolOlculer();
                                kYuk.konsolTur = "Yükseklik";
                                kYuk.konsolUzunluk = mobilyaYukseklik - 5 - konsolKalinlik;
                                kYuk.konsolAdet = demirYukseklikAdet(boy);
                                sipObj.konsolOlculer.Add(kYuk);

                                SiparisObj.KonsolOlculer kUst = new SiparisObj.KonsolOlculer();
                                kUst.konsolTur = "Üst";
                                kUst.konsolUzunluk = boy - (konsolKalinlik * 2);
                                kUst.konsolAdet = 2;
                                sipObj.konsolOlculer.Add(kUst);

                            }
                        }
                        chcOnExCl.Enabled = true;
                        chcArkaExCl.Enabled = true;
                        chcSolExCl.Enabled = true;
                        chcSagExCl.Enabled = true;
                        chcTabanExCl.Enabled = true;
                    }
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chcTumuExCl_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTumuExCl.Checked == true)
            {
                chcSagExCl.Checked = true;
                chcSolExCl.Checked = true;
                chcOnExCl.Checked = true;
                chcArkaExCl.Checked = true;
                chcTabanExCl.Checked = true;

                if (sipObj.akvaryumOlculer.Count==5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sipObj.akvaryumOlculer[i].camTipi = "ExtraClear";
                    }
                }
            }
            else
            {
                chcSagExCl.Checked = false;
                chcSolExCl.Checked = false;
                chcOnExCl.Checked = false;
                chcArkaExCl.Checked = false;
                chcTabanExCl.Checked = false;

                if (sipObj.akvaryumOlculer.Count == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sipObj.akvaryumOlculer[i].camTipi = "Düz Cam";
                    }
                }
            }
        }

        private void chcOnExCl_CheckedChanged(object sender, EventArgs e)
        {
            if (chcOnExCl.Checked == true)
            {
                if (sipObj.akvaryumOlculer.Count == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (sipObj.akvaryumOlculer[i].camAdi == "Ön cam")
                        {
                            sipObj.akvaryumOlculer[i].camTipi = "ExtraClear";
                        }
                    }
                }
            }
            else
            {
                if (sipObj.akvaryumOlculer.Count == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (sipObj.akvaryumOlculer[i].camAdi == "Ön cam")
                        {
                            sipObj.akvaryumOlculer[i].camTipi = "Düz Cam";
                        }
                    }
                }
            }
        }

        private void chcArkaExCl_CheckedChanged(object sender, EventArgs e)
        {
            if (chcArkaExCl.Checked == true)
            {
                if (sipObj.akvaryumOlculer.Count == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (sipObj.akvaryumOlculer[i].camAdi == "Arka cam")
                        {
                            sipObj.akvaryumOlculer[i].camTipi = "ExtraClear";
                        }
                    }
                }
            }
            else
            {
                if (sipObj.akvaryumOlculer.Count == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (sipObj.akvaryumOlculer[i].camAdi == "Arka cam")
                        {
                            sipObj.akvaryumOlculer[i].camTipi = "Düz Cam";
                        }
                    }
                }
            }
        }

        private void chcSolExCl_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSolExCl.Checked == true)
            {
                if (sipObj.akvaryumOlculer.Count == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (sipObj.akvaryumOlculer[i].camAdi == "Sol cam")
                        {
                            sipObj.akvaryumOlculer[i].camTipi = "ExtraClear";
                        }
                    }
                }
            }
            else
            {
                if (sipObj.akvaryumOlculer.Count == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (sipObj.akvaryumOlculer[i].camAdi == "Sol cam")
                        {
                            sipObj.akvaryumOlculer[i].camTipi = "Düz Cam";
                        }
                    }
                }
            }
        }

        private void chcSagExCl_CheckedChanged(object sender, EventArgs e)
        {
            if (chcSagExCl.Checked == true)
            {
                if (sipObj.akvaryumOlculer.Count == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (sipObj.akvaryumOlculer[i].camAdi == "Sağ cam")
                        {
                            sipObj.akvaryumOlculer[i].camTipi = "ExtraClear";
                        }
                    }
                }
            }
            else
            {
                if (sipObj.akvaryumOlculer.Count == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (sipObj.akvaryumOlculer[i].camAdi == "Sağ cam")
                        {
                            sipObj.akvaryumOlculer[i].camTipi = "Düz Cam";
                        }
                    }
                }
            }
        }

        private void chcTabanExCl_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTabanExCl.Checked == true)
            {
                if (sipObj.akvaryumOlculer.Count == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (sipObj.akvaryumOlculer[i].camAdi == "Taban camı")
                        {
                            sipObj.akvaryumOlculer[i].camTipi = "ExtraClear";
                        }
                    }
                }
            }
            else
            {
                if (sipObj.akvaryumOlculer.Count == 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (sipObj.akvaryumOlculer[i].camAdi == "Taban camı")
                        {
                            sipObj.akvaryumOlculer[i].camTipi = "Düz Cam";
                        }
                    }
                }
            }
        }

        private void btnSiparisOlustur_Click(object sender, EventArgs e)
        {
            sipObj.aciklama = rtxAciklama.Text;
            sipObj.akvaryumBase.silikonRengi = cmbSilikonRengi.SelectedItem.ToString();
            sipObj.mobilyaBase.mobilyaRengi = txtMobilyaRengi.Text;
            sipObj.mobilyaBase.mobilyaTipi = txtMobilyaTipi.Text;
            MessageBox.Show("kontrol");

        }

        public int camK(int boy, int en, int yukseklik)
        {
            double camK = (Math.Sqrt(boy) * yukseklik) / 78;
            int camKalinligi = 0;
            if (camK <= 3)
            {
                camKalinligi = 3;
            }
            else if (camK > 3 && camK <= 4)
            {
                camKalinligi = 4;
            }
            else if (camK > 4 && camK <= 5)
            {
                camKalinligi = 5;
            }
            else if (camK > 5 && camK <= 6)
            {
                camKalinligi = 6;
            }
            else if (camK > 6 && camK <= 8)
            {
                camKalinligi = 8;
            }
            else if (camK > 8 && camK <= 10)
            {
                camKalinligi = 10;
            }
            else if (camK > 10 && camK <= 12)
            {
                camKalinligi = 12;
            }
            else if (camK > 12 && camK <= 15)
            {
                camKalinligi = 15;
            }
            else if (camK > 15 && camK <= 19)
            {
                camKalinligi = 19;
            }
            else if (camK > 19 && camK <= 20)
            {
                camKalinligi = 20;
            }
            else if (camK > 20 && camK <= 24)
            {
                camKalinligi = 24;
            }
            return camKalinligi;
        }
        public int demirYanAdet(int uzunluk)
        {
            if (uzunluk <= 100)
            {
                return 5;
            }
            else if (uzunluk > 100 && uzunluk <= 150)
            {
                return 7;
            }
            else if (uzunluk > 150 && uzunluk <= 200)
            {
                return 10;
            }
            else if (uzunluk > 200 && uzunluk <= 250)
            {
                return 12;
            }
            else
            {
                return 14;
            }
        }

        public int demirYukseklikAdet(int uzunluk)
        {
            if (uzunluk <= 100)
            {
                return 4;
            }
            else if (uzunluk > 100 && uzunluk <= 150)
            {
                return 6;
            }
            else if (uzunluk > 150 && uzunluk <= 200)
            {
                return 8;
            }
            else if (uzunluk > 200 && uzunluk <= 250)
            {
                return 10;
            }
            else
            {
                return 12;
            }
        }

    }
}

