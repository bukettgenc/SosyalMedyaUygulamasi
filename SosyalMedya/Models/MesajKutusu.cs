using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SosyalMedya.Models
{
    public class MesajKutusu
    {
        public int Id { get; set; }
        public int ProfilNo { get; set; }
        public int MesajıAtan { get; set; }
        public string Mesaj { get; set; }
    }
}