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
    public class MemberProfileController : Controller
    {
        FindJobEntities db = new FindJobEntities();

        public ActionResult Profil()
        {
            string email = Session["Email"].ToString();
            var kisi = db.Applicants.Where(i => i.Email == email).SingleOrDefault();

            return View(kisi);
        }
        public ActionResult Myapplication()
        {
            int applicantid = Convert.ToInt16(Session["ApplicantID"]);

            var applicantad = db.ApplicantAds.Where(x => x.ApplicantID == applicantid).ToList();

            ViewBag.AdCount = applicantad.Count;

            return View(applicantad);
        }
        
        public ActionResult MyApplicationDetailSingle(int id)
        {
            var myapplicationdetail = db.ADs.Where(x => x.AdID == id).ToList();

            return View(myapplicationdetail);
        }

        public ActionResult DeleteMyApplication(int id)
        {
            var member = db.ApplicantAds.Find(id);
            db.ApplicantAds.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Myapplication","MemberProfile");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }


        [HttpPost]
        public ActionResult Edit(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Profil", "MemberProfile");
            }
            return View(applicant);
        }
    }
}