using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResourcesWebsite.Models;

namespace HumanResourcesWebsite.Controllers
{
    public class CompanyPanelController : Controller
    {
        FindJobEntities db = new FindJobEntities();


        [HttpGet]
        public ActionResult Index()
        {
            var compmail = (string)Session["EMail"];
            var degerler = db.Companies.FirstOrDefault(z => z.EMail == compmail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(Company p)
        {
            var User = (string)Session["EMail"];
            var member = db.Companies.FirstOrDefault(x => x.EMail == User);
            member.EMail = p.EMail;
            member.Name = p.Name;
            member.Adress = p.Adress;
            member.NumberOfWorkers = p.NumberOfWorkers;
            member.Description = p.Description;
            member.Adress = p.Adress;
            member.NumberOfWorkers = p.NumberOfWorkers;
            member.WebSite = p.WebSite;
            member.FoundationYear = p.FoundationYear;
            member.SectorID = p.SectorID;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}