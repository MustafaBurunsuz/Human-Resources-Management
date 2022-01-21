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
    public class CompaniesController : Controller
    {
        FindJobEntities db = new FindJobEntities();
        // GET: Companies
        public ActionResult Index(string ara)
        {
            var companies = db.Companies.Where(i=>i.Name.Contains(ara) || ara==null).ToList();
          
            return View(companies);
        }

        [HttpGet]
        public ActionResult AddCompany()

        {
            ViewBag.sectorid = new SelectList(db.Sectors, "SectorID", "SectorName");
            return View();
        }

        [HttpPost]
        public ActionResult AddCompany(Company c)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            db.Companies.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index","Companies"); 
        }

        public ActionResult DeleteCompany(int id)
        {
            var company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      

        public ActionResult UpdateCompany(int? id)
        {
            ViewBag.sectorid = new SelectList(db.Sectors, "SectorID", "SectorName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var companies = db.Companies.Find(id);
            if (companies == null)
            {
                return HttpNotFound();
            }
            return View(companies);
        }

        [HttpPost]
        public ActionResult UpdateCompany(Company p1)
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