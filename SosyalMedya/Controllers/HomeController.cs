using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using SosyalMedya.Models;
using StructureMap.Pipeline;

namespace SosyalMedya.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult KayitOl()
        {

            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(FormCollection form)
        {
            var numaraList = db.Hesabims.ToList().LastOrDefault();
            var hesapKontrolList = db.Hesabims.ToList();
            string kullaniciAdi = Request.Form["KullaniciAdi"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            string image = Request.Form["image"];
            int flag = 0;
            foreach (var kontrol in hesapKontrolList)
            {
                if (kontrol.KullaniciAdi !=kullaniciAdi && kontrol.Mail!=email)
                {
                    flag = 0;
                }
                else
                {
                    flag = 1;
                    goto Etiket;
                }
            }
            Etiket:
            if (flag==0)
            {
                Hesabim hesap = new Hesabim();
                hesap.KullaniciAdi = kullaniciAdi;
                hesap.Mail = email;
                hesap.Sifre = password;
                hesap.ProfilFoto = "~/images/user.png";
                hesap.AnasayfaNo = numaraList.AnasayfaNo + 1;
                hesap.ProfilNo = numaraList.ProfilNo + 1;
                hesap.AktifMi = false;
                db.Hesabims.Add(hesap);
                db.SaveChanges();
                MessageBox.Show("KAYIT BAŞARILI");
            }
            else if(flag==1)
            {
                MessageBox.Show("KULLANICI ADINIZ VEYA MAİL ADRESİNİZ DAHA ÖNCE KULLANILMIŞ,KAYIT BAŞARISIZ ");

            }

            return View();
        }
        
        public ActionResult Indexx()
        {

            return View();
        }
        public ActionResult Index(int? id)
        {
            if (id != null && id!=0)
            {
                Hesabim hesap = db.Hesabims.Where(i => i.ProfilNo == id).SingleOrDefault();
                hesap.AktifMi = false;
                db.SaveChanges();
            }
            return View();
        }

      
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string kullaniciAdi= Request.Form["name"];
            string sifre= Request.Form["password"];
            string yönlendirici="";
            string controller="";
            var kullaniciList = db.Hesabims.ToList();
            int i = 0;
            int profilNo = 0;
            foreach (var item in kullaniciList)
            {
                if (item.KullaniciAdi==kullaniciAdi && item.Sifre==sifre )
                {
                    yönlendirici = "Page";
                    controller = "Page";
                    item.AktifMi = true;
                    profilNo = item.ProfilNo;
                    db.SaveChanges();
                    i++;
                }
                else
                {
                    if (i==0)
                    {
                        yönlendirici = "Index";
                        controller = "Home";
                        profilNo = 0;
                    }
                }

               
            }
           
            return RedirectToAction(yönlendirici,controller, new { @id = profilNo }); 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult Listele(int id)
        {
           
            List<AnasayfaYazilari> Listem=db.AnasayfaYazilari.ToList();
            AnasayfaYazilari anasayfaYazilari = Listem.FirstOrDefault(x => x.Id == id);
            return Json(anasayfaYazilari, JsonRequestBehavior.AllowGet);
        }
    }
}