using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VRASearchEngine.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }

        // Identifies their type
        public PersonTypeEnum Type { get; set; }  // Enum: Staff, Driver, Intern, NSS
    }
}