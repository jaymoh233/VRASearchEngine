namespace VRASearchEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Department = c.String(),
                        Type = c.Int(nullable: false),
                        LicenseNumber = c.String(),
                        AssignedVehicle = c.String(),
                        Institution = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Supervisor = c.String(),
                        NSSNumber = c.String(),
                        ServiceStart = c.DateTime(),
                        ServiceEnd = c.DateTime(),
                        Position = c.String(),
                        EmployeeId = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        DepartmentModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DepartmentModels", t => t.DepartmentModel_Id)
                .Index(t => t.DepartmentModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonModels", "DepartmentModel_Id", "dbo.DepartmentModels");
            DropIndex("dbo.PersonModels", new[] { "DepartmentModel_Id" });
            DropTable("dbo.PersonModels");
            DropTable("dbo.DepartmentModels");
        }
    }
}
