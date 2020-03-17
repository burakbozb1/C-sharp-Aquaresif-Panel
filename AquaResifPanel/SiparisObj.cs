using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaResifPanel
{
    class SiparisObj
    {
        public class TumUrunler
        {
            public string urunKatAdi { get; set; }
            public string urunAdi { get; set; }
            public string urunAciklama { get; set; }
            public string marka { get; set; }
            public int adet { get; set; }
            public double fiyat { get; set; }
            public double toplamFiyat { get; set; }
        }

        public class AkvaryumBase
        {
            public string silikonRengi { get; set; }
            public int camKalinligi { get; set; }
        }

        public class AkvaryumOlculer
        {
            public string camAdi { get; set; }
            public double camX { get; set; }
            public double camY { get; set; }
            public string camTipi { get; set; }
        }

        public class Kayitlar
        {
            public string kayitAdi { get; set; }
            public double kayitX { get; set; }
            public double kayitY { get; set; }
            public int kayitAdet { get; set; }
        }

        public class MobilyaBase
        {
            public string mobilyaTipi { get; set; }
            public string mobilyaRengi { get; set; }
        }

        public class MobilyaOlculer
        {
            public string panelAdi { get; set; }
            public double panelX { get; set; }
            public double panelY { get; set; }
            public int panelAdet { get; set; }
        }

        public class KonsolBase
        {
            public string konsolTuru { get; set; }
            public double konsolKalinligi { get; set; }
        }

        public class KonsolOlculer
        {
            public string konsolTur { get; set; }
            public double konsolUzunluk { get; set; }
            public int konsolAdet { get; set; }
        }

        public class Siparis
        {
            public string siparisNo { get; set; }
            public string musteri { get; set; }
            public string konu { get; set; }
            public string teslimYeri { get; set; }
            public string teslimSuresi { get; set; }
            public string teklifVeren { get; set; }
            public string aciklama { get; set; }
            public string tarih { get; set; }
            public List<TumUrunler> tumUrunler { get; set; }
            public AkvaryumBase akvaryumBase { get; set; }
            public List<AkvaryumOlculer> akvaryumOlculer { get; set; }
            public List<Kayitlar> kayitlar { get; set; }
            public MobilyaBase mobilyaBase { get; set; }
            public List<MobilyaOlculer> mobilyaOlculer { get; set; }
            public KonsolBase konsolBase { get; set; }
            public List<KonsolOlculer> konsolOlculer { get; set; }
        }
    }
}
