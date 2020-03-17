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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }
        User user = new User();
        public static String[] userInfo = new String[5];


        private void Form1_Load(object sender, EventArgs e)
        {
            txtKadi.Text = "boz";
            txtSfr.Text = "1234";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //{"kulAdi":"Boz","kulSifre":"1234"}
            dynamic newUser = new JObject();
            newUser.kulAdi = txtKadi.Text.Trim();
            newUser.kulSifre = txtSfr.Text.Trim();
            

            string jsonOut = JsonConvert.SerializeObject(newUser);

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/login");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        kulAdi = txtKadi.Text.Trim(),
                        kulSifre = txtSfr.Text.Trim()
                    });

                    streamWriter.Write(json);


                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (result.ToString() == "Geçersiz Giriş")
                    {
                        MessageBox.Show("Geçersiz kullanıcı bilgisi");
                    }
                    else
                    {

                        /*
                         kulId: 1,
                            kulAdi: 'Boz',
                            kulAdSoyad: 'Burak Boz',
                            kulSifre: '1234',
                            kulTip: 'Admin*/


                        JArray jsonArray = JArray.Parse(result);
                        JObject data = JObject.Parse(jsonArray[0].ToString());



                        user.setUserId(Convert.ToInt32(jsonArray[0]["kulId"]));
                        user.setUserName(jsonArray[0]["kulAdi"].ToString());
                        user.setUserNS(jsonArray[0]["kulAdSoyad"].ToString());
                        user.setUserPass(jsonArray[0]["kulSifre"].ToString());
                        user.setUserType(jsonArray[0]["kulTip"].ToString());

                        //MessageBox.Show("Hoşgeldiniz\n" + user.getUserNS());

                        
                        userInfo[0] = user.getUserId().ToString();
                        userInfo[1] = user.getUserName().ToString();
                        userInfo[2] = user.getUserNS().ToString();
                        userInfo[3] = user.getUserPass().ToString();
                        userInfo[4] = user.getUserType().ToString();


                        AnaForm anaForm = new AnaForm();
                        anaForm.Show();
                        this.Hide();


                    }
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            




        }
    }
}
