using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaResifPanel
{
    class teklifVerileri
    {
        public class TumUrunler
        {
            public string urunKatAdi { get; set; }
            public string urunAdi { get; set; }
            public string urunAciklama { get; set; }
            public string marka { get; set; }
            public string adet { get; set; }
            public string fiyat { get; set; }
            public string toplamFiyat { get; set; }

            
        }

        public class RootObject
        {
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
            public string teklifVeren { get; set; }
            public string toplamFiyat { get; set; }
            public List<TumUrunler> tumUrunler { get; set; }
        }
        
        
    }
}
