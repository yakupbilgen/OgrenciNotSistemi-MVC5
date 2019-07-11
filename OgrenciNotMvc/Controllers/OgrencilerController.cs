using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class OgrencilerController : Controller
    {
		// GET: Ogrenciler
		DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
			var ogr = db.TBLOGRENCILER.ToList();
            return View(ogr);
        }

		[HttpGet]
		public ActionResult YeniOgrenciEkle()
		{
			List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
											 select new SelectListItem
											 {
												 Text = i.KULUPAD,
												 Value = i.KULUPID.ToString()
											 }).ToList();
			ViewBag.dgr = degerler;
			return View();
		}

		[HttpPost]
		public ActionResult YeniOgrenciEkle(TBLOGRENCILER ogrekle)
		{
			var kulup = db.TBLKULUPLER.Where(m => m.KULUPID == ogrekle.TBLKULUPLER.KULUPID).FirstOrDefault();
			ogrekle.TBLKULUPLER = kulup;
			db.TBLOGRENCILER.Add(ogrekle);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Sil(int id)
		{
			var ogr = db.TBLOGRENCILER.Find(id);
			db.TBLOGRENCILER.Remove(ogr);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult OgrenciGetir(int id)
		{
			var ogr = db.TBLOGRENCILER.Find(id);
			List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
											 select new SelectListItem
											 {
												 Text = i.KULUPAD,
												 Value = i.KULUPID.ToString()
											 }).ToList();
			ViewBag.dgr = degerler;
			return View("OgrenciGetir", ogr);
		}

		public ActionResult Guncelle(TBLOGRENCILER tblogr)
		{
			var ogr = db.TBLOGRENCILER.Find(tblogr.OgrenciID);
			ogr.OGRAd = tblogr.OGRAd;
			ogr.OGRSoyad = tblogr.OGRSoyad;
			ogr.OGRFoto = tblogr.OGRFoto;
			ogr.OGRCinsiyet = tblogr.OGRCinsiyet;
			ogr.OGRKulup = tblogr.OGRKulup;
			db.SaveChanges();
			return RedirectToAction("Index", ogr);
		}
	}
}