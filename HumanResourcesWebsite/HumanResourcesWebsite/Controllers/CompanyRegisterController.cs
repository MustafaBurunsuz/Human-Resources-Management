using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResourcesWebsite.Models;
namespace HumanResourcesWebsite.Controllers
{
    public class CompanyRegisterController : Controller
    {
        
        FindJobEntities db = new FindJobEntities();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Company p)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            db.Companies.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}