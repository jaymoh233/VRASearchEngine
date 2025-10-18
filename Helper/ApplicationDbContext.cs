using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using System.Web.UI.WebControls.WebParts;
using VRASearchEngine.Models;
using System.Collections;

namespace VRASearchEngine.Helper
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") // Match with connection string in Web.config
        {
        }

        public DbSet<PersonModel> People { get; set; }

        public DbSet<StaffModel> Staff { get; set; }
        public DbSet<DriverModel> Drivers { get; set; }
        public DbSet<InternModel> Interns { get; set; }
        public DbSet<ServicePersonnelModel> ServicePersonnel { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }


    }
}