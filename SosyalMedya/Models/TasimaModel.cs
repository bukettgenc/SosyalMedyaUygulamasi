using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SosyalMedya.Models
{
    public class TasimaModel : IEnumerable
    {
        public int Id { get; set; }
        public int ProfilNo { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}