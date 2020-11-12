using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SosyalMedya.Models
{
    public class Hesabim
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public string ProfilFoto { get; set; }
        public int AnasayfaNo { get; set; }
        public int ProfilNo { get; set; }
        public bool AktifMi { get; set; }
    }
}