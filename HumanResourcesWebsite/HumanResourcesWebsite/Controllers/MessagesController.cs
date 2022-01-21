using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResourcesWebsite.Models;

namespace HumanResourcesWebsite.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Mesajlar
        FindJobEntities db = new FindJobEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["EMail"].ToString();
            var mesajlar = db.Messages.Where(x => x.Receiver == uyemail.ToString()).ToList(); ;
            return View(mesajlar);
        }

        public ActionResult To()
        {
            var uyemail = (string)Session["EMail"].ToString();
            var mesajlar = db.Messages.Where(x => x.Sender == uyemail.ToString()).ToList(); ;
            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message t)
        {
            var uyemail = (string)Session["EMail"].ToString();
            t.Sender = uyemail.ToString();
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Messages.Add(t);
            db.SaveChanges();
            return RedirectToAction("To", "Messages");
        }
    }
}

