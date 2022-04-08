using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ililce.Models;

namespace ililce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

       DenemeEntities db = new DenemeEntities();
        Class1 cs = new Class1();
        [HttpGet]
        public ActionResult Deneme()
        {
            cs.Sehirler = new SelectList(db.İl, "id", "ad");
            cs.İlceler = new SelectList(db.ilce, "ilceid", "ilcead");
            return View(cs);
        }
        public JsonResult ilcegetir(int p)
        {
            var ilceler =(from x in db.ilce
                          join y in db.İl on x.İl.id equals y.id
                          where x.İl.id == p
                          select new
                          {
                              Text = x.ilcead,
                              Value = x.ilceid.ToString()
                          }).ToList();
            return Json(ilceler, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Deneme(tbldeneme p)
        {
            db.tbldeneme.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}