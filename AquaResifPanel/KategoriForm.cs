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
    public partial class KategoriForm : Form
    {
        public KategoriForm()
        {
            InitializeComponent();
        }

        string tumKategoriler;
        DataTable dtKategoriler = new DataTable();
        int selectedIndex,selectedId;
        string selectedName;

        private void KategoriForm_Load(object sender, EventArgs e)
        {


            createDatatable();
            kategoriListele();
        }

        public void createDatatable()
        {
            DataColumn columnId;
            columnId = new DataColumn();
            columnId.ColumnName = "katId";
            dtKategoriler.Columns.Add(columnId);

            DataColumn columnAd;
            columnAd = new DataColumn();
            columnAd.ColumnName = "katAdi";
            dtKategoriler.Columns.Add(columnAd);
        }

        public void kategoriListele()
        {
            lstKategoriler.Items.Clear();
            dtKategoriler.Rows.Clear();
            string tumKategoriler;
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
                dtKategoriler.Rows.Add(jkategori["katId"].ToString(), jkategori["katAdi"].ToString());
            }
            for (int i = 0; i < dtKategoriler.Rows.Count; i++)
            {
                lstKategoriler.Items.Add(dtKategoriler.Rows[i]["katId"].ToString() + " "+dtKategoriler.Rows[i]["katAdi"].ToString());
            }

        }

        private void lstKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedIndex = lstKategoriler.SelectedIndex;
                selectedName = dtKategoriler.Rows[selectedIndex]["katAdi"].ToString().Trim();
                selectedId = Convert.ToInt32(dtKategoriler.Rows[selectedIndex]["katId"]);
                lblKatId.Text = selectedId.ToString();
                txtKatAdi.Text = selectedName;
            }
            catch (Exception)
            {
                MessageBox.Show("Boşluğa tıklama");
            }
        }

        private void btnKatEkle_Click(object sender, EventArgs e)
        {
            string kategoriAdi = txtYeniKatAdi.Text.Trim();
            if (kategoriAdi == "" || kategoriAdi == null)
            {
                MessageBox.Show("Boş Geçilemez");

            }
            else
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/kategoriEkle");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        katAdi = txtYeniKatAdi.Text.Trim()
                    });

                    streamWriter.Write(json);


                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    MessageBox.Show(result.ToString());
                    txtYeniKatAdi.Text = "";
                    kategoriListele();

                }
            }
        }

        private void btnKatSil_Click(object sender, EventArgs e)
        {
            //kategoriSil
            //int kategoriId = 
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/kategoriSil");
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
                MessageBox.Show(result.ToString());
                kategoriListele();
                lblKatId.Text = "...";
                txtKatAdi.Text = "";

            }
        }

        private void btnKatGuncelle_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/kategoriGuncelle");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    katId = selectedId,
                    katAdi = txtKatAdi.Text.Trim()
                });

                streamWriter.Write(json);


            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                MessageBox.Show(result.ToString());
                kategoriListele();

            }


            selectedName = "";
            selectedId = -1;
            lblKatId.Text = "...";
            txtKatAdi.Text = "";

        }
    }
    
}
