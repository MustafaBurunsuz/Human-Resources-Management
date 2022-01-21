using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanResourcesWebsite.Models;
namespace HumanResourcesWebsite.Controllers
{
    public class HomeController : Controller
    {
        FindJobEntities db = new FindJobEntities();
        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();
            vm.Company = db.Companies.ToList();
            vm.Sectors = db.Sectors.ToList();
            vm.AD = db.ADs.OrderByDescending(x => x.AdID).Take(5).ToList();
            ViewBag.numberofpostedjobs = db.ADs.Count();
            ViewBag.numberofcompanies = db.Companies.Count();
            ViewBag.numberofmembers = db.Applicants.Count();

            return View(vm);
        }
        public ActionResult Search(string term)
        {
            var names = db.ADs.Where(p => p.Title.Contains(term)).Select(p => p.Title).ToList();
            return Json(names, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FilterJobs(string ara)
        {
            var filterjobs = db.ADs.Where(i => i.Title.Contains(ara) || i.Company.Name.Contains(ara) || ara == null).ToList();
            return View(filterjobs);
        }
        public ActionResult FilterJobsDetailSingle(int id)
        {
            var degerler = db.ADs.Where(x => x.AdID == id).ToList();
            var model = new FilterJobDetailSingleViewModel
            {
                AdId = id,
                ADList = degerler
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult ApplyJob(FilterJobDetailSingleViewModel model)
        {
            int applicantId = (int)Session["ApplicantID"];
            var kullaniciIlans = db.ApplicantAds.FirstOrDefault(a => a.ApplicantID == applicantId && a.AdID == model.AdId);
            if (kullaniciIlans != null)
            {
                TempData["Message"] = "You can only apply for once... ";
                return RedirectToAction("FilterJobsDetailSingle", "Home", new { id = model.AdId });
            }
            ApplicantAd p1 = new ApplicantAd();
            p1.ApplicantID = applicantId; 
            p1.AdID = model.AdId;
            p1.Date = DateTime.Now;
            db.ApplicantAds.Add(p1);
            db.SaveChanges();

            return RedirectToAction("Myapplication", "MemberProfile");
        }


        public ActionResult How()
        {
            return View();
        }
        public ActionResult CompanyAdDetail(int id)
        {
            var degerler = db.ADs.Where(x => x.CompanyID == id).ToList();

            //Sadece 1 veri getirme kodu...
            var firma = db.Companies.Where(i => i.CompanyID == id).SingleOrDefault();
            ViewBag.deneme = firma.Name;

            return View(degerler);
        }
        public ActionResult CompanyAdDetailSingle(int id)
        {
            var degerler = db.ADs.Where(x => x.AdID == id).ToList();
            var model = new CompanyAdDetailSingleViewModel
            {
                AdId = id,
                ADList = degerler
            };
            return View(model);
        }

        public ActionResult SectorAdDetail(int id)
        {

            var degerler = db.ADs.Where(x => x.SectorID == id).ToList();

            //Sadece 1 veri getirme kodu...
            var firma = db.Sectors.Where(i => i.SectorID == id).SingleOrDefault();
            ViewBag.deneme = firma.SectorName;

            return View(degerler);
        }

        public ActionResult SectorAdDetailSingle(int id)
        {
            var degerler = db.ADs.Where(x => x.AdID == id).ToList();
            var model = new SectorAdDetailSingleViewModel
            {
                AdId = id,
                ADList = degerler
            };
            return View(model);
        }
        public ActionResult LatestAdDetailSingle(int id)
        {
            var degerler = db.ADs.Where(x => x.AdID == id).ToList();
            var model = new LatestAdDetailSingleViewModel
            {
                AdId = id,
                ADList = degerler
            };
            return View(model);
        }


        [HttpGet]
        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact x)
        {
            db.Contacts.Add(x);
            db.SaveChanges();
            return RedirectToAction("Contact", "Home");
        }
    }
}