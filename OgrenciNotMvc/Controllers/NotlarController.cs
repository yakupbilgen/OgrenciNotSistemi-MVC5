using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.Models;

namespace OgrenciNotMvc.Controllers
{
	public class NotlarController : Controller
	{
		// GET: Notlar
		DbMvcOkulEntities db = new DbMvcOkulEntities();
		public ActionResult Index()
		{
			var not = db.TBLNOTLAR.ToList();
			return View(not);
		}
		[HttpGet]
		public ActionResult YeniSinav()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YeniSinav(TBLNOTLAR tblnot)
		{
			db.TBLNOTLAR.Add(tblnot);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult NotGetir(int id)
		{
			var notlar = db.TBLNOTLAR.Find(id);
			return View("NotGetir", notlar);
		}
		[HttpPost]
		public ActionResult NotGetir(Class1 model, TBLNOTLAR tblnot, int sinav1 = 0, int sinav2 = 0, int sinav3 = 0, int proje = 0)
		{
			if (model.islem == "Hesapla")
			{
				//İşlem1
				double ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
				ViewBag.ort = ortalama;
			}

			if (model.islem == "NotGuncelle")
			{
				//İşlem2
				var sinav = db.TBLNOTLAR.Find(tblnot.NOTID);
				sinav.SINAV1 = tblnot.SINAV1;
				sinav.SINAV2 = tblnot.SINAV2;
				sinav.SINAV3 = tblnot.SINAV3;
				sinav.PROJE = tblnot.PROJE;
				sinav.ORTALAMA = tblnot.ORTALAMA;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}