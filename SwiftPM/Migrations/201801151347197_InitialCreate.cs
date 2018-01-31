namespace SwiftPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                        DeptCode = c.String(),
                        DepartmentHead = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        UnitName = c.String(),
                        UnitCode = c.String(),
                        UnitHead = c.String(),
                    })
                .PrimaryKey(t => t.UnitId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        UnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.AssignedTasks",
                c => new
                    {
                        AssignedTaskId = c.Int(nullable: false, identity: true),
                        StaffId = c.String(maxLength: 128),
                        TaskActivityId = c.Int(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        CompletedDate = c.DateTime(),
                        ActivityState = c.String(),
                        AssignedBy = c.String(),
                    })
                .PrimaryKey(t => t.AssignedTaskId)
                .ForeignKey("dbo.Staffs", t => t.StaffId)
                .ForeignKey("dbo.TaskActivities", t => t.TaskActivityId, cascadeDelete: true)
                .Index(t => t.StaffId)
                .Index(t => t.TaskActivityId);
            
            CreateTable(
                "dbo.TaskActivities",
                c => new
                    {
                        TaskActivityId = c.Int(nullable: false, identity: true),
                        ModuleTaskId = c.Int(nullable: false),
                        ActivityName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.TaskActivityId)
                .ForeignKey("dbo.ModuleTasks", t => t.ModuleTaskId, cascadeDelete: true)
                .Index(t => t.ModuleTaskId);
            
            CreateTable(
                "dbo.ModuleTasks",
                c => new
                    {
                        ModuleTaskId = c.Int(nullable: false, identity: true),
                        ProjectModuleId = c.Int(nullable: false),
                        TaskName = c.String(),
                        TaskDescription = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ExpectedCompletionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleTaskId)
                .ForeignKey("dbo.ProjectModules", t => t.ProjectModuleId, cascadeDelete: true)
                .Index(t => t.ProjectModuleId);
            
            CreateTable(
                "dbo.ModuleTaskIssues",
                c => new
                    {
                        ModuleTaskIssueId = c.Int(nullable: false, identity: true),
                        ModuleTaskId = c.Int(nullable: false),
                        IssueType = c.String(),
                        IssueDescription = c.String(),
                        DateSubmitted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleTaskIssueId)
                .ForeignKey("dbo.ModuleTasks", t => t.ModuleTaskId, cascadeDelete: true)
                .Index(t => t.ModuleTaskId);
            
            CreateTable(
                "dbo.ProjectModules",
                c => new
                    {
                        ProjectModuleId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        ModuleName = c.String(),
                        PriorityLevel = c.Int(nullable: false),
                        ModulePercentage = c.Double(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectModuleId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectCode = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        ProjectDescription = c.String(),
                        PriorityLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
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
            DropForeignKey("dbo.Staffs", "UnitId", "dbo.Units");
            DropForeignKey("dbo.TaskActivities", "ModuleTaskId", "dbo.ModuleTasks");
            DropForeignKey("dbo.ProjectModules", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ModuleTasks", "ProjectModuleId", "dbo.ProjectModules");
            DropForeignKey("dbo.ModuleTaskIssues", "ModuleTaskId", "dbo.ModuleTasks");
            DropForeignKey("dbo.AssignedTasks", "TaskActivityId", "dbo.TaskActivities");
            DropForeignKey("dbo.AssignedTasks", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Units", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProjectModules", new[] { "ProjectId" });
            DropIndex("dbo.ModuleTaskIssues", new[] { "ModuleTaskId" });
            DropIndex("dbo.ModuleTasks", new[] { "ProjectModuleId" });
            DropIndex("dbo.TaskActivities", new[] { "ModuleTaskId" });
            DropIndex("dbo.AssignedTasks", new[] { "TaskActivityId" });
            DropIndex("dbo.AssignedTasks", new[] { "StaffId" });
            DropIndex("dbo.Staffs", new[] { "UnitId" });
            DropIndex("dbo.Units", new[] { "DepartmentId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectModules");
            DropTable("dbo.ModuleTaskIssues");
            DropTable("dbo.ModuleTasks");
            DropTable("dbo.TaskActivities");
            DropTable("dbo.AssignedTasks");
            DropTable("dbo.Staffs");
            DropTable("dbo.Units");
            DropTable("dbo.Departments");
        }
    }
}
