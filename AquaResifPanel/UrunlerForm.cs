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
    public partial class UrunlerForm : Form
    {
        public UrunlerForm()
        {
            InitializeComponent();
        }
        string tumUrunler, tumKategoriler;
        int selectedId, selectUpId;
        DataTable dtUrunler = new DataTable();

        private void UrunlerForm_Load(object sender, EventArgs e)
        {
            kategoriListele();
            //ürünid katid ad aciklama,fiyat,marka
            DataColumn columnId = new DataColumn();
            columnId.ColumnName = "urunId";
            dtUrunler.Columns.Add(columnId);

            DataColumn columnCatId = new DataColumn();
            columnCatId.ColumnName = "katId";
            dtUrunler.Columns.Add(columnCatId);

            DataColumn columnUrunAd = new DataColumn();
            columnUrunAd.ColumnName = "urunAdi";
            dtUrunler.Columns.Add(columnUrunAd);

            DataColumn columnUrunAciklama = new DataColumn();
            columnUrunAciklama.ColumnName = "urunAciklama";
            dtUrunler.Columns.Add(columnUrunAciklama);

            DataColumn columnUrunFiyat = new DataColumn();
            columnUrunFiyat.ColumnName = "urunFiyat";
            dtUrunler.Columns.Add(columnUrunFiyat);

            DataColumn columnUrunMarka = new DataColumn();
            columnUrunMarka.ColumnName = "urunMarka";
            dtUrunler.Columns.Add(columnUrunMarka);
        }

        public void urunListele()
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


                JArray jUrunler = JArray.Parse(tumUrunler);
                for (int i = 0; i < jUrunler.Count; i++)
                {
                    //ürünid katid ad aciklama,fiyat,marka
                    JObject jurun = JObject.Parse(jUrunler[i].ToString());
                    //MessageBox.Show(jurun["urunAdi"].ToString());
                    dtUrunler.Rows.Add(jurun["urunId"].ToString(), jurun["katId"], jurun["urunAdi"].ToString(), jurun["urunAciklama"].ToString(), jurun["urunFiyat"].ToString(), jurun["urunMarka"].ToString());
                    lstUrunler.Items.Add(dtUrunler.Rows[i]["urunAdi"].ToString());

                }

                /*MessageBox.Show(dtUrunler.Rows[0]["urunId"].ToString());
                MessageBox.Show(dtUrunler.Rows[0]["katId"].ToString());
                MessageBox.Show(dtUrunler.Rows[0]["urunAciklama"].ToString());
                MessageBox.Show(dtUrunler.Rows[0]["urunFiyat"].ToString());
                MessageBox.Show(dtUrunler.Rows[0]["urunMarka"].ToString());*/

            }
        }

        private void cmbKategoriAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cmbKategoriAdi.SelectedIndex;
            string selectedCat = cmbKategoriAdi.Items[selectedIndex].ToString();
            //MessageBox.Show(selectedIndex.ToString() + " " + selectedCat);
            int boslukBul = selectedCat.IndexOf(" ");
            selectedId = Convert.ToInt32(selectedCat.Substring(0, boslukBul));
            dtUrunler.Rows.Clear();
            lblGuncelId.Text = "...";
            txtGuncelAd.Text = "";
            txtGuncelAciklama.Text = "";
            txtGuncelFiyat.Text = "";
            txtGuncelMarka.Text = "";
            cmbGuncelKat.SelectedIndex = cmbKategoriAdi.SelectedIndex;
            lstUrunler.Items.Clear();
            urunListele();
            //MessageBox.Show(selectedId.ToString());

        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            int urunFiyati, katIdsi, urunIdsi;
            string urunAd, urunAciklamasi, urunMarkasi;
            urunFiyati = Convert.ToInt32(txtGuncelFiyat.Text);

            urunIdsi = Convert.ToInt32(lblGuncelId.Text);
            int boslukbul = cmbGuncelKat.SelectedItem.ToString().IndexOf(" ");
            katIdsi = Convert.ToInt32(cmbGuncelKat.SelectedItem.ToString().Substring(0, boslukbul));
            urunAd = txtGuncelAd.Text;
            urunAciklamasi = txtGuncelAciklama.Text;
            urunMarkasi = txtGuncelMarka.Text;


            //-------
            //{"urunId":4,"katId":"5","urunAdi":"aa","urunAciklama":"aaaa","urunFiyat":2000,"urunMarka":"aaa"}
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/urunGuncelle");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    urunId = urunIdsi,
                    katId = katIdsi,
                    urunAdi = urunAd,
                    urunAciklama = urunAciklamasi,
                    urunFiyat = urunFiyati,
                    urunMarka = urunMarkasi
                });

                streamWriter.Write(json);


            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                MessageBox.Show(result);
            }


            //-------

            //MessageBox.Show("Adı: " + urunAd + "\n" + "açıklama: " + urunAciklama + "\n" + "marka: " + urunMarka + "\n" + "Fiyat: " + urunFiyat.ToString() + "\n" + "kategori: " + katId.ToString());

        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            int urunFiyati, urunKatId;
            string urunAd, urunAciklamasi, urunMarka;
            urunFiyati = Convert.ToInt32(txtUrunFiyat.Text);
            int boslukbul = cmbUrunKategori.SelectedItem.ToString().IndexOf(" ");
            urunKatId = Convert.ToInt32(cmbUrunKategori.SelectedItem.ToString().Substring(0, boslukbul));
            urunAd = txtUrunAd.Text;
            urunAciklamasi = txtUrunAciklama.Text;
            urunMarka = txtUrunMarka.Text;


            //{"katId":"5","urunAdi":"Örnek ürün2","urunAciklama":"Örnek ürün açıklaması2","urunFiyat":2000,"urunMarka":"Örnek Ürün Markası2"}
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/urunEkle");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    katId = urunKatId,
                    urunAdi = urunAd,
                    urunAciklama = urunAciklamasi,
                    urunFiyat = urunFiyati,
                    urunMarka = urunMarka

                });

                streamWriter.Write(json);


            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                MessageBox.Show(result);
            }

            //MessageBox.Show(urunAd + " " + urunAciklamasi + " " + urunMarka + " " + urunFiyati.ToString() + " " + urunKatId.ToString());
            /*
             int boslukbul = cmbGuncelKat.SelectedItem.ToString().IndexOf(" ");
            katIdsi = Convert.ToInt32(cmbGuncelKat.SelectedItem.ToString().Substring(0, boslukbul));*/
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            //{"urunId":1}
            try
            {
                int urunIdsi;
                urunIdsi = Convert.ToInt32(dtUrunler.Rows[lstUrunler.SelectedIndex]["urunId"]);

                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/urunSil");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        urunId = urunIdsi
                    });

                    streamWriter.Write(json);


                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    MessageBox.Show(result);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Boşluğa tıklandı");
            }
        }

        private void lstUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                int selectedIndex = Convert.ToInt32(lstUrunler.SelectedIndex);
                selectUpId = Convert.ToInt32(dtUrunler.Rows[Convert.ToInt32(lstUrunler.SelectedIndex)]["urunId"]);
                lblGuncelId.Text = selectUpId.ToString();
                txtGuncelAd.Text = dtUrunler.Rows[selectedIndex]["urunAdi"].ToString();
                txtGuncelAciklama.Text = dtUrunler.Rows[selectedIndex]["urunAciklama"].ToString();
                txtGuncelFiyat.Text = dtUrunler.Rows[selectedIndex]["urunFiyat"].ToString();
                txtGuncelMarka.Text = dtUrunler.Rows[selectedIndex]["urunMarka"].ToString();
                cmbGuncelKat.SelectedIndex = cmbKategoriAdi.SelectedIndex;
                //cmbGuncelKat.SelectedItem = dtUrunler.Rows[selectedIndex]["katId"].ToString();
                //MessageBox.Show(cmbGuncelKat.SelectedItem.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Boşluğa tıklandı");
            }


        }

        public void kategoriListele()
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
                cmbKategoriAdi.Items.Add(jkategori["katId"].ToString() + " " + jkategori["katAdi"].ToString());
                cmbGuncelKat.Items.Add(jkategori["katId"].ToString() + " " + jkategori["katAdi"].ToString());
                cmbUrunKategori.Items.Add(jkategori["katId"].ToString() + " " + jkategori["katAdi"].ToString());
                //dtKategoriler.Rows.Add(jkategori["katId"].ToString(), jkategori["katAdi"].ToString());
            }
            for (int i = 0; i < jKategoriler.Count; i++)
            {

                //lstKategoriler.Items.Add(dtKategoriler.Rows[i]["katId"].ToString() + " " + dtKategoriler.Rows[i]["katAdi"].ToString());
            }


        }
    }
}
