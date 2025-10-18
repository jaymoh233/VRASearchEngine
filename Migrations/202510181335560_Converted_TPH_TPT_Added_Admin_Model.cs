namespace VRASearchEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Converted_TPH_TPT_Added_Admin_Model : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PersonModels", newName: "People");
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        PasswordHash = c.String(nullable: false),
                        Role = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LicenseNumber = c.String(),
                        AssignedVehicle = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Interns",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Institution = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Supervisor = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ServicePersonnel",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NSSNumber = c.String(),
                        ServiceStart = c.DateTime(nullable: false),
                        ServiceEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Position = c.String(),
                        EmployeeId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Id)
                .Index(t => t.Id);
            
            DropColumn("dbo.People", "LicenseNumber");
            DropColumn("dbo.People", "AssignedVehicle");
            DropColumn("dbo.People", "Institution");
            DropColumn("dbo.People", "StartDate");
            DropColumn("dbo.People", "EndDate");
            DropColumn("dbo.People", "Supervisor");
            DropColumn("dbo.People", "NSSNumber");
            DropColumn("dbo.People", "ServiceStart");
            DropColumn("dbo.People", "ServiceEnd");
            DropColumn("dbo.People", "Position");
            DropColumn("dbo.People", "EmployeeId");
            DropColumn("dbo.People", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.People", "EmployeeId", c => c.String());
            AddColumn("dbo.People", "Position", c => c.String());
            AddColumn("dbo.People", "ServiceEnd", c => c.DateTime());
            AddColumn("dbo.People", "ServiceStart", c => c.DateTime());
            AddColumn("dbo.People", "NSSNumber", c => c.String());
            AddColumn("dbo.People", "Supervisor", c => c.String());
            AddColumn("dbo.People", "EndDate", c => c.DateTime());
            AddColumn("dbo.People", "StartDate", c => c.DateTime());
            AddColumn("dbo.People", "Institution", c => c.String());
            AddColumn("dbo.People", "AssignedVehicle", c => c.String());
            AddColumn("dbo.People", "LicenseNumber", c => c.String());
            DropForeignKey("dbo.Staff", "Id", "dbo.People");
            DropForeignKey("dbo.ServicePersonnel", "Id", "dbo.People");
            DropForeignKey("dbo.Interns", "Id", "dbo.People");
            DropForeignKey("dbo.Drivers", "Id", "dbo.People");
            DropIndex("dbo.Staff", new[] { "Id" });
            DropIndex("dbo.ServicePersonnel", new[] { "Id" });
            DropIndex("dbo.Interns", new[] { "Id" });
            DropIndex("dbo.Drivers", new[] { "Id" });
            DropTable("dbo.Staff");
            DropTable("dbo.ServicePersonnel");
            DropTable("dbo.Interns");
            DropTable("dbo.Drivers");
            DropTable("dbo.Admins");
            RenameTable(name: "dbo.People", newName: "PersonModels");
        }
    }
}
