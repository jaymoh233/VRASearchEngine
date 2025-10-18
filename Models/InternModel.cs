using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VRASearchEngine.Models
{
    public class InternModel : PersonModel
    {
        public string Institution { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Supervisor { get; set; }
    }
}