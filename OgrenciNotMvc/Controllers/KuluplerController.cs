using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class KuluplerController : Controller
    {
		// GET: Kulupler
		DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
			var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }

		[HttpGet]
		public ActionResult YeniKulupEkle()
		{
			return View();
		}

		[HttpPost]
		public ActionResult YeniKulupEkle(TBLKULUPLER kulupekle)
		{
			db.TBLKULUPLER.Add(kulupekle);
			db.SaveChanges();
			return RedirectToAction("Index");
			
		}

		public ActionResult Sil(int id)
		{
			var kulup = db.TBLKULUPLER.Find(id);
			db.TBLKULUPLER.Remove(kulup);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult KulupGetir(int id)
		{
			var kulup = db.TBLKULUPLER.Find(id);
			return View("KulupGetir", kulup);
		}

		public ActionResult Guncelle(TBLKULUPLER tblkulup)
		{
			var kulup = db.TBLKULUPLER.Find(tblkulup.KULUPID);
			kulup.KULUPAD = tblkulup.KULUPAD;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}