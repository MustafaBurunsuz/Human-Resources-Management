using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResourcesWebsite.Models;
using System.Web.Security;
namespace HumanResourcesWebsite.Controllers
{
    public class CompanyLoginController : Controller
    {
        // GET: Login
        FindJobEntities db = new FindJobEntities();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Company p)
        {
            var info = db.Companies.FirstOrDefault(x => x.EMail == p.EMail && x.Password == p.Password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.EMail, false);
                Session["EMail"] = info.EMail.ToString();
                Session["CompanyID"] = info.CompanyID;

                return RedirectToAction("Index", "CompanyAd");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["EMail"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}