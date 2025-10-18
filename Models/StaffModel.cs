using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VRASearchEngine.Models
{
    public class StaffModel : PersonModel
    {
        public string Position { get; set; }   // e.g. Team Lead, Manager, Officer
        public string EmployeeId { get; set; } // Optional staff ID
    }
}