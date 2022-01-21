using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResourcesWebsite.Models;

namespace HumanResourcesWebsite.Controllers
{
    
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        FindJobEntities db = new FindJobEntities();

        public ActionResult Index()
        {
            ViewBag.companies = db.Companies.Count();
            ViewBag.applicant = db.Applicants.Count();
            ViewBag.ads = db.ADs.Count();
            ViewBag.sectors = db.Sectors.Count();

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin p)
        {
            var admininfo = db.Admins.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);
            if (admininfo != null)
            {

                Session["Email"] = p.Email;

                return RedirectToAction("Index", "AdminHome");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session["Email"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}