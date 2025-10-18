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

        public DbSet<AdminModel> Admins { get; set; }

        public DbSet<PersonModel> People { get; set; }

        public DbSet<StaffModel> Staff { get; set; }
        public DbSet<DriverModel> Drivers { get; set; }
        public DbSet<InternModel> Interns { get; set; }
        public DbSet<ServicePersonnelModel> ServicePersonnel { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TPT mapping
            modelBuilder.Entity<AdminModel>().ToTable("Admins");

            modelBuilder.Entity<PersonModel>().ToTable("People");
            modelBuilder.Entity<StaffModel>().ToTable("Staff");
            modelBuilder.Entity<DriverModel>().ToTable("Drivers");
            modelBuilder.Entity<InternModel>().ToTable("Interns");
            modelBuilder.Entity<ServicePersonnelModel>().ToTable("ServicePersonnel");
        }


    }
}