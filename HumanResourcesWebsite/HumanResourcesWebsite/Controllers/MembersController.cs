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
    public class MembersController : Controller
    {
        FindJobEntities db = new FindJobEntities();
        // GET: Members
        public ActionResult Index(string ara)
        {
            var applicants = db.Applicants.Where(i=>i.Name.Contains(ara) || ara==null).ToList();

            return View(applicants);
        }

        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMember(Applicant a)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            db.Applicants.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index", "Members");
        }

        public ActionResult DeleteMember(int id)
        {
            var member = db.Applicants.Find(id);
            db.Applicants.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult UpdateMember(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var members = db.Applicants.Find(id);
            if (members == null)
            {
                return HttpNotFound();
            }
            return View(members);
        }

        [HttpPost]
        public ActionResult UpdateMember(Applicant p1)
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