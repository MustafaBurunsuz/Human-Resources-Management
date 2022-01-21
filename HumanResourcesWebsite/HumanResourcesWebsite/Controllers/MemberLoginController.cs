using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResourcesWebsite.Models;
using System.Web.Security;
namespace HumanResourcesWebsite.Controllers
{
    public class MemberLoginController : Controller
    {
        // GET: Login
        FindJobEntities db = new FindJobEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Applicant p)
        {
            var info = db.Applicants.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);
            if (info != null)
            {
                
                Session["Email"] = p.Email;
                Session["ApplicantID"] = info.ApplicantID;

                return RedirectToAction("Index", "Home");
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