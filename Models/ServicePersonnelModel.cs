using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VRASearchEngine.Models
{
    public class ServicePersonnelModel : PersonModel
    {
        public string NSSNumber { get; set; }
        public DateTime ServiceStart { get; set; }
        public DateTime ServiceEnd { get; set; }
    }
}