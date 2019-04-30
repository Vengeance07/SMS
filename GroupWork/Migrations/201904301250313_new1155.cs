namespace GroupWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1155 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(),
                        CourseId = c.Int(),
                        ModuleTypeId = c.Int(),
                        StudentId = c.Int(),
                        TimeTableId = c.Int(),
                        Date = c.String(),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.ModuleTypes", t => t.ModuleTypeId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .ForeignKey("dbo.TimeTables", t => t.TimeTableId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId)
                .Index(t => t.ModuleTypeId)
                .Index(t => t.StudentId)
                .Index(t => t.TimeTableId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModuleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Contact = c.String(),
                        Email = c.String(),
                        EnrollDate = c.String(),
                        AddressId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        Contact = c.String(),
                        Email = c.String(),
                        AddressId = c.Int(nullable: false),
                        ModuleTypeId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.ModuleTypes", t => t.ModuleTypeId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.ModuleTypeId)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.Int(),
                        ModuleId = c.Int(),
                        StartTime = c.String(nullable: false),
                        EndTime = c.String(nullable: false),
                        Day = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Modules", t => t.ModuleId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.CourseId)
                .Index(t => t.TeacherId)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Attendences", "TimeTableId", "dbo.TimeTables");
            DropForeignKey("dbo.TimeTables", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TimeTables", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.TimeTables", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendences", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "ModuleTypeId", "dbo.ModuleTypes");
            DropForeignKey("dbo.Teachers", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.Modules", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Teachers", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Attendences", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Students", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Attendences", "ModuleTypeId", "dbo.ModuleTypes");
            DropForeignKey("dbo.Attendences", "CourseId", "dbo.Courses");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TimeTables", new[] { "ModuleId" });
            DropIndex("dbo.TimeTables", new[] { "TeacherId" });
            DropIndex("dbo.TimeTables", new[] { "CourseId" });
            DropIndex("dbo.Modules", new[] { "CourseId" });
            DropIndex("dbo.Teachers", new[] { "ModuleId" });
            DropIndex("dbo.Teachers", new[] { "ModuleTypeId" });
            DropIndex("dbo.Teachers", new[] { "AddressId" });
            DropIndex("dbo.Students", new[] { "CourseId" });
            DropIndex("dbo.Students", new[] { "AddressId" });
            DropIndex("dbo.Attendences", new[] { "TimeTableId" });
            DropIndex("dbo.Attendences", new[] { "StudentId" });
            DropIndex("dbo.Attendences", new[] { "ModuleTypeId" });
            DropIndex("dbo.Attendences", new[] { "CourseId" });
            DropIndex("dbo.Attendences", new[] { "TeacherId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TimeTables");
            DropTable("dbo.Modules");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.ModuleTypes");
            DropTable("dbo.Courses");
            DropTable("dbo.Attendences");
            DropTable("dbo.Addresses");
        }
    }
}
