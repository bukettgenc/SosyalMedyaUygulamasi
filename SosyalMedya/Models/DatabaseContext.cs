using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SosyalMedya.Models
{
    public class DatabaseContext : DbContext
    {
        //public DatabaseContext() : base("SosyalMedyaDb")
        //{
        //    Database.SetInitializer(new DatabaseInitializer());
        //}

        public DbSet<Hesabim> Hesabims { get; set; }
        public DbSet<AnasayfaYazilari> AnasayfaYazilari { get; set; }
        public DbSet<Takipci> Takipcis { get; set; }
        public DbSet<YaziBegenisi> YaziBegenisis { get; set; }
        public DbSet<MesajKutusu> MesajKutusus { get; set; }
    }
}