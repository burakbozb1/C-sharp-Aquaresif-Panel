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

    public partial class ElleUrunFormu : Form
    {
        public string formDurumu = "0";
        public string[] urunVerileri = new string[8];
        public ElleUrunFormu()
        {
            InitializeComponent();
        }

        private void btnElleUrunEkle_Click(object sender, EventArgs e)
        {
            //urunid-ürünadı-katid-katadi-urunaciklama-urunfiyat-urunmarka

            if (txtUrunAdi.Text.Length != 0 && txtKatAdi.Text.Length != 0 && txtUrunAciklama.Text.Length != 0 && txtUrunFiyat.Text.Length != 0 && txtUrunMarka.Text.Length != 0 && txtUrunAdedi.Text.Length!=0)
            {
                try
                {
                    int a = Convert.ToInt32(txtUrunFiyat.Text);
                    int b = Convert.ToInt32(txtUrunAdedi.Text);
                    formDurumu = "1";
                    urunVerileri[0] = "Eklendi";
                    urunVerileri[1] = txtUrunAdi.Text;
                    urunVerileri[2] = "Eklendi";
                    urunVerileri[3] = txtKatAdi.Text;
                    urunVerileri[4] = txtUrunAciklama.Text;
                    urunVerileri[5] = txtUrunFiyat.Text;
                    urunVerileri[6] = txtUrunMarka.Text;
                    urunVerileri[7] = txtUrunAdedi.Text;
                    this.Close();
                }
                catch
                {
                    txtUrunFiyat.Text = "";
                    txtUrunAdedi.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Tüm alanlar doldurulmalıdır");
            }

        }

        private void ElleUrunFormu_Load(object sender, EventArgs e)
        {

        }
    }
}
