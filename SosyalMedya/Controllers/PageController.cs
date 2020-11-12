using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SosyalMedya.Models;

namespace SosyalMedya.Controllers
{
    public class PageController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Page
        public ActionResult Begen(int id, int tiklananId)
        {
            var allList = new List<AnasayfaYazilari>();
            var begeniList = db.YaziBegenisis.ToList();
            var TakipEdilen = db.Takipcis.Where(x => x.ProfilNo == id).ToList().OrderByDescending(x => x.Id);
            foreach (var item in TakipEdilen)
            {
                var PageList = db.AnasayfaYazilari.Where(x => x.ProfilNo == item.ArkadasProfilNo).ToList().OrderByDescending(x => x.Id);
                allList.AddRange(PageList);

            }

            foreach (var item in allList)
            {
                if (item.Id == tiklananId)
                {
                    YaziBegenisi yaziBegenisi = new YaziBegenisi();

                    int degisken;
                    if (db.YaziBegenisis.Where(x => x.YaziNo == tiklananId && x.BegenenProfilNo == id).ToList().Count == 0)
                    {
                        degisken = item.BeğeniSayisi + 1;
                        item.BeğeniSayisi = degisken;
                        yaziBegenisi.YaziNo = tiklananId;
                        yaziBegenisi.BegenenProfilNo = id;
                        db.YaziBegenisis.Add(yaziBegenisi);

                    }
                    else
                    {
                        degisken = item.BeğeniSayisi - 1;
                        item.BeğeniSayisi = degisken;
                        foreach (var begeni in begeniList)
                        {
                            if (begeni.BegenenProfilNo == id && begeni.YaziNo == tiklananId)
                            {
                                YaziBegenisi deptDelete = db.YaziBegenisis.Find(begeni.Id);
                                db.YaziBegenisis.Remove(deptDelete);
                            }
                        }
                    }
                    db.SaveChanges();

                }
            }
            return RedirectToAction("Anasayfa", "Page", new { @id = id });

        }

        [HttpPost]
        public JsonResult Begeni(int id, int tiklananId)
        {
            var allList = new List<AnasayfaYazilari>();
            var begeniList = db.YaziBegenisis.ToList();
            var TakipEdilen = db.Takipcis.Where(x => x.ProfilNo == id).ToList().OrderByDescending(x => x.Id);
            foreach (var item in TakipEdilen)
            {
                var PageList = db.AnasayfaYazilari.Where(x => x.ProfilNo == item.ArkadasProfilNo).ToList().OrderByDescending(x => x.Id);
                allList.AddRange(PageList);

            }

            foreach (var item in allList)
            {
                if (item.Id == tiklananId)
                {
                    YaziBegenisi yaziBegenisi = new YaziBegenisi();

                    int degisken;
                    if (db.YaziBegenisis.Where(x => x.YaziNo == tiklananId && x.BegenenProfilNo == id).ToList().Count == 0)
                    {
                        degisken = item.BeğeniSayisi + 1;
                        item.BeğeniSayisi = degisken;
                        yaziBegenisi.YaziNo = tiklananId;
                        yaziBegenisi.BegenenProfilNo = id;
                        db.YaziBegenisis.Add(yaziBegenisi);

                    }
                    else
                    {
                        degisken = item.BeğeniSayisi - 1;
                        item.BeğeniSayisi = degisken;
                        foreach (var begeni in begeniList)
                        {
                            if (begeni.BegenenProfilNo == id && begeni.YaziNo == tiklananId)
                            {
                                YaziBegenisi deptDelete = db.YaziBegenisis.Find(begeni.Id);
                                db.YaziBegenisis.Remove(deptDelete);
                                
                            }
                        }
                    }
                    db.SaveChanges();

                }
            }

            int i=0;
            List<AnasayfaYazilari> Listem = db.AnasayfaYazilari.ToList();
            AnasayfaYazilari anasayfaYazilari = Listem.FirstOrDefault(x => x.Id == tiklananId);
            string buton_adi = "";
            int flagg = 0;
            //item id aslında tıklananın idsi
         
                
                foreach (var begeni in begeniList)
                {
                    //giriş yapılan
                    if (tiklananId == begeni.YaziNo && begeni.BegenenProfilNo == id)
                    {
                        i = 1;
                        flagg = 1;
                    }
                    else
                    {
                        if (flagg == 0)
                        {
                            i = 0;
                        }
                    }
                }
            

            if (i == 0)
            {
                buton_adi = "Geri Al";
            }
            else
            {
                buton_adi = "Beğen";
            }
            anasayfaYazilari.ProfilYazilari = buton_adi;//profil yazıları yerine yeni bi sütun açılacak.

            return Json(anasayfaYazilari, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProfildeBegen(int id, int tiklananId, int profilId)
        {
            var begeniList = db.YaziBegenisis.ToList();
            var TakipEdilen = db.Takipcis.Where(x => x.ProfilNo == id).ToList().OrderByDescending(x => x.Id);
            var PageList = db.AnasayfaYazilari.Where(x => x.ProfilNo == profilId).ToList().OrderByDescending(x => x.Id);

            foreach (var item in PageList)
            {
                if (item.Id == tiklananId)
                {
                    YaziBegenisi yaziBegenisi = new YaziBegenisi();

                    int degisken;
                    if (db.YaziBegenisis.Where(x => x.YaziNo == tiklananId && x.BegenenProfilNo == id).ToList().Count == 0)
                    {
                        degisken = item.BeğeniSayisi + 1;
                        item.BeğeniSayisi = degisken;
                        yaziBegenisi.YaziNo = tiklananId;
                        yaziBegenisi.BegenenProfilNo = id;
                        db.YaziBegenisis.Add(yaziBegenisi);

                    }
                    else
                    {
                        degisken = item.BeğeniSayisi - 1;
                        item.BeğeniSayisi = degisken;
                        foreach (var begeni in begeniList)
                        {
                            if (begeni.BegenenProfilNo == id && begeni.YaziNo == tiklananId)
                            {
                                YaziBegenisi deptDelete = db.YaziBegenisis.Find(begeni.Id);
                                db.YaziBegenisis.Remove(deptDelete);
                            }
                        }
                    }
                    db.SaveChanges();
                }
            }
            return RedirectToAction("KisiSayfasi", "Page", new { @id = id, @profilId = profilId });

        }
        public ActionResult Anasayfa(int? id)
        {

            ViewBag.Id = id;
            return View();

        }
        public ActionResult Page(int? id)
        {
            ViewBag.Id = id;
            return View();

        }

        [HttpPost]
        public ActionResult Page(FormCollection form, int? id)
        {

            string durum = Request.Form["durum"];
            AnasayfaYazilari anasayfaYazilari = new AnasayfaYazilari();
            var list = db.Hesabims.ToList();
            anasayfaYazilari.ProfilYazilari = durum;
            foreach (var item in list)
            {
                if (item.AktifMi == true && item.Id==id)
                {
                        anasayfaYazilari.ProfilNo = item.ProfilNo;
                }
            }
            db.AnasayfaYazilari.Add(anasayfaYazilari);
            db.SaveChanges();
            ViewBag.Id = id;

            return View();
        }
        public ActionResult KisiSayfasi(int? id, int? profilId)
        {
            ViewBag.Id = id;
            ViewBag.profilId = profilId;
            return View();

        }

        [HttpPost]
        public ActionResult KisiSayfasi(FormCollection form, int? id)
        {

            string durum = Request.Form["durum"];
            AnasayfaYazilari anasayfaYazilari = new AnasayfaYazilari();
            var list = db.Hesabims.ToList();
            anasayfaYazilari.ProfilYazilari = durum;
            foreach (var item in list)
            {
                if (item.AktifMi == true)
                {

                    anasayfaYazilari.ProfilNo = item.ProfilNo;
                }
            }
            db.AnasayfaYazilari.Add(anasayfaYazilari);
            db.SaveChanges();
            ViewBag.Id = id;

            return View();
        }
        public ActionResult Friends(int? id)
        {

            ViewBag.Id = id;
            return View();
        }
        public ActionResult Mesaj(int? id)
        {

            ViewBag.Id = id;
            return View();
        }
        public ActionResult MesajYaz(int? id, int? mesajAtan)
        {

            ViewBag.Id = id;
            ViewBag.mesajAtan = mesajAtan;
            return View();
        }
        [HttpPost]
        public ActionResult MesajYaz(int id, int? mesajAtan, FormCollection form)
        {

            ViewBag.Id = id;
            ViewBag.mesajAtan = mesajAtan;
            string mesajım = Request.Form["mesaj"];
            MesajKutusu mesaj = new MesajKutusu();
            mesaj.ProfilNo = id;
            mesaj.MesajıAtan = (int)mesajAtan;
            mesaj.Mesaj = mesajım;
            db.MesajKutusus.Add(mesaj);
            db.SaveChanges();
            return View();
        }
        [HttpPost]
        public JsonResult mesajListele(int sayi,int mesajAtan,FormCollection form)
        {
            DatabaseContext db = new DatabaseContext();

            //ViewBag.Id = sayi;
            //ViewBag.mesajAtan = mesajAtan;
            string mesajım = Request.Form["mesaj"];
            MesajKutusu mesaj = new MesajKutusu();
            mesaj.ProfilNo = sayi;
            mesaj.MesajıAtan = (int)mesajAtan;
            mesaj.Mesaj = mesajım;
            db.MesajKutusus.Add(mesaj);
            db.SaveChanges();

          //  var mesajKutusuList = db.MesajKutusus.Where(i => i.ProfilNo == sayi || i.ProfilNo == mesajAtan).OrderBy(i => i.Id).ToList();
            
            List<MesajKutusu> Listem = db.MesajKutusus.ToList();
            MesajKutusu MesajKutusus = Listem.LastOrDefault();
          //  MesajKutusus.Mesaj = mesajım;

            return Json(MesajKutusus, JsonRequestBehavior.AllowGet);
        }
    }
}