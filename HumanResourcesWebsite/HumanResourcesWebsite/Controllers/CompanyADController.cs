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
    public class CompanyADController : Controller
    {
        // GET: CompanyAD
        FindJobEntities db = new FindJobEntities();
        public ActionResult Index()
        {
            var kullanici = (string)Session["EMail"];
            var id = db.Companies.Where(x => x.EMail == kullanici.ToString()).Select(z => z.CompanyID).FirstOrDefault();

            var degerler = db.ADs.Where(x => x.CompanyID == id).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult AddAD()
        {
            return View();
        }

        public ActionResult AddAD(AD p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.ADs.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult DeleteAD(int id)
        {
            var AD = db.ADs.Find(id);
            db.ADs.Remove(AD);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetAD(int? id)
        {
            ViewBag.sectorid = new SelectList(db.Sectors, "SectorID", "SectorName");
            ViewBag.companyid = new SelectList(db.Companies, "CompanyID", "Name");
           
            var ads = db.ADs.Find(id);
           
            return View("GetAd",ads);
        }

        [HttpPost]
        public ActionResult UpdateAD(AD p)
        {
            var ad = db.ADs.Find(p.AdID);
            ad.Title = p.Title;
            ad.NumberOfApplications = p.NumberOfApplications;
            ad.Information = p.Information;
            ad.AdStartDate = p.AdStartDate;
            ad.AdEndDate = p.AdEndDate;
            ad.Experiences = p.Experiences;
            ad.EducationLevel = p.EducationLevel;
            ad.MilitaryState = p.MilitaryState;
            ad.Price = p.Price;
            ad.Criterion1 = p.Criterion1;
            ad.Criterion2 = p.Criterion2;
            ad.Criterion3 = p.Criterion3;
            ad.Criterion4 = p.Criterion4;
            ad.Criterion5 = p.Criterion5;
            db.SaveChanges();


            return RedirectToAction("Index");
        }
        
        public ActionResult ShowApplicant(int id)
        {
            var sorgu = db.ApplicantAds.Where(x => x.AdID == id).ToList();
                
            return View(sorgu);
        }

        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            ApplicantAd guncellenecek = db.ApplicantAds.Find(id);
            return View(guncellenecek);
        }

        [HttpPost]
        public ActionResult ChangeStatus(ApplicantAd p1)
        {
            var sorgu = db.ApplicantAds.FirstOrDefault(x => x.ApplicationID == p1.ApplicationID);
            sorgu.Status = p1.Status;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowAllApplicant()
        {
            int companyId = (int)Session["CompanyID"];
            var model = (from a in db.Applicants
                         join aa in db.ApplicantAds on a.ApplicantID equals aa.ApplicantID
                         join ad in db.ADs on aa.AdID equals ad.AdID
                         join c in db.Companies on ad.CompanyID equals c.CompanyID
                         where c.CompanyID == companyId
                         select new ShowAllApplicantViewModel
                         {
                             Ad = a.Name,
                             Soyad = a.Surname,
                             Adress = a.Adress,
                             Email = a.Email,
                             Phone = a.Phone,
                             ExperienceYear = a.ExperienceYear,
                             GraduationLevel = a.GraduationLevel,
                             Courses = a.Courses,
                             Point = a.Point,
                             MilitaryState = a.MilitaryState,



                         }).Distinct().ToList();
            return View(model);
        }

    }
}