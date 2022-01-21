using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HumanResourcesWebsite.Models;

namespace HumanResourcesWebsite.Controllers
{
    public class AdsController : Controller
    {
        FindJobEntities db = new FindJobEntities();

        public ActionResult Index(string ara)
        {
            var ads = db.ADs.Where(i => i.Title.Contains(ara) || ara == null).ToList();

            return View(ads);
        }

        public ActionResult Showallapplicant(int id)
        {
            var ads = db.ApplicantAds.Where(x => x.AdID == id);
            return View(ads);
        }

        [HttpGet]
        public ActionResult AddAd()
        {
            ViewBag.companyid = new SelectList(db.Companies, "CompanyID", "Name");
            ViewBag.sectorid = new SelectList(db.Sectors, "SectorID", "SectorName");
            return View();
        }

        [HttpPost]
        public ActionResult AddAd(AD c)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }

            db.ADs.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index", "Ads");
        }

        public ActionResult DeleteAd(int id)
        {
            var ad = db.ADs.Find(id);
            db.ADs.Remove(ad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAd(int? id)
        {
            ViewBag.sectorid = new SelectList(db.Sectors, "SectorID", "SectorName");
            ViewBag.companyid = new SelectList(db.Companies, "CompanyID", "Name");
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ads = db.ADs.Find(id);
            if (ads == null)
            {
                return HttpNotFound();
            }
            return View(ads);
        }

        [HttpPost]
        public ActionResult UpdateAd(AD p1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p1);
        }

     

    }
}