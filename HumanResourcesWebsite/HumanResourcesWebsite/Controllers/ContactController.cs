using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResourcesWebsite.Models;

namespace HumanResourcesWebsite.Controllers
{
    public class ContactController : Controller
    {
        FindJobEntities db = new FindJobEntities();
        // GET: Contact
        public ActionResult Index(string ara)
        {
            var contacts = db.Contacts.Where(i => i.Mail.Contains(ara) || ara == null).ToList();

            return View(contacts);
        }
    }
}