using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResourcesWebsite.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Company> Company { get; set; }
        public IEnumerable<Sector> Sectors { get; set; }
        public IEnumerable<AD> AD { get; set; }
    }
}