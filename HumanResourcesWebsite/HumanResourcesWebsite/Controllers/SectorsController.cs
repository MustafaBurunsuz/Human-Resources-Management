using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HumanResourcesWebsite.Models;

namespace HumanResourcesWebsite.Controllers
{
    public class SectorsController : Controller
    {
        private FindJobEntities db = new FindJobEntities();

        
        public ActionResult Index(string ara)
        {
            var sectors = db.Sectors.Where(i => i.SectorName.Contains(ara) || ara == null).ToList();
            return View(sectors);
        }

        [HttpGet]
        public ActionResult AddSector()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSector(Sector a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            db.Sectors.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index", "Sectors");
        }
        public ActionResult DeleteSector(int id)
        {
            var sector = db.Sectors.Find(id);
            db.Sectors.Remove(sector);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult UpdateSector(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sectors = db.Sectors.Find(id);
            if (sectors == null)
            {
                return HttpNotFound();
            }
            return View(sectors);
        }

        [HttpPost]
        public ActionResult UpdateMember(Sector p1)
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
