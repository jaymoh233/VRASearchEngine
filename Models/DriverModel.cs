using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VRASearchEngine.Models
{
    public class DriverModel : PersonModel
    {
        public string LicenseNumber { get; set; }
        public string AssignedVehicle { get; set; }
    }
}