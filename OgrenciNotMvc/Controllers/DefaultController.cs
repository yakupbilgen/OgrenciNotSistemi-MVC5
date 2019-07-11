using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class DefaultController : Controller
    {
		// GET: Default
		DbMvcOkulEntities db = new DbMvcOkulEntities();
		public ActionResult Index()
		{
			var dersler = db.TBLDERSLER.ToList();
			return View(dersler);
		}

		[HttpGet]
		public ActionResult YeniDersEkle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YeniDersEkle(TBLDERSLER dersekle)
		{
			db.TBLDERSLER.Add(dersekle);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Sil(int id)
		{
			var ders = db.TBLDERSLER.Find(id);
			db.TBLDERSLER.Remove(ders);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DersGetir(int id)
		{
			var ders = db.TBLDERSLER.Find(id);
			return View("DersGetir",ders);
		}

		public ActionResult Guncelle(TBLDERSLER tblders)
		{
			var ders = db.TBLDERSLER.Find(tblders.DersID);
			ders.DersAd = tblders.DersAd;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}