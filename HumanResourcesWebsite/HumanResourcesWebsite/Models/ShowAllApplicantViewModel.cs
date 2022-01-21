using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResourcesWebsite.Models
{
    public class ShowAllApplicantViewModel
    {
       
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

        public bool? MilitaryState { get; set; }
        public string GraduationLevel { get; set; }
        public int? Courses { get; set; }
        public int? ExperienceYear { get; set; }


        public int? Point { get; set; }
    }
}