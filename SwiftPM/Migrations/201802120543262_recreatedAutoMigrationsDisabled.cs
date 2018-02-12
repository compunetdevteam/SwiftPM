namespace SwiftPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recreatedAutoMigrationsDisabled : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignedTasks",
                c => new
                    {
                        AssignedTaskId = c.Int(nullable: false, identity: true),
                        StaffId = c.String(maxLength: 128),
                        TaskActivityId = c.Int(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        TaskStatus = c.String(),
                        CompletedDate = c.DateTime(),
                        ActivityState = c.String(),
                        AssignedBy = c.String(),
                        ApprovedBy = c.String(),
                    })
                .PrimaryKey(t => t.AssignedTaskId)
                .ForeignKey("dbo.Staffs", t => t.StaffId)
                .ForeignKey("dbo.TaskActivities", t => t.TaskActivityId, cascadeDelete: true)
                .Index(t => t.StaffId)
                .Index(t => t.TaskActivityId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.String(nullable: false, maxLength: 128),
                        StaffCode = c.String(),
                        Password = c.String(),
                        IsAssigned = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Title = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        StateOfOrigin = c.String(),
                        MaritalStatus = c.String(),
                        Active = c.Boolean(nullable: false),
                        Passport = c.Binary(),
                        PassportUrl = c.String(),
                        Unit_UnitId = c.Int(),
                    })
                .PrimaryKey(t => t.StaffId)
                .ForeignKey("dbo.Units", t => t.Unit_UnitId)
                .Index(t => t.Unit_UnitId);
            
            CreateTable(
                "dbo.TaskActivities",
                c => new
                    {
                        TaskActivityId = c.Int(nullable: false, identity: true),
                        ModuleTaskId = c.Int(nullable: false),
                        ActivityName = c.String(),
                        IsCompleted = c.Boolean(),
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
                        ModuleTaskName = c.String(),
                        ModuleTaskDescription = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ExpectedCompletionDate = c.DateTime(nullable: false),
                        ProjectModuleId = c.Int(nullable: false),
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
                        DateCreated = c.DateTime(nullable: false),
                        ProjectDescription = c.String(),
                        PriorityLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.AssignStaffToDepts",
                c => new
                    {
                        AssignStaffToDeptId = c.Int(nullable: false, identity: true),
                        StaffRole = c.String(),
                        StaffId = c.String(maxLength: 128),
                        DepartmentId = c.Int(nullable: false),
                        DateOfAssignment = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AssignStaffToDeptId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffId)
                .Index(t => t.StaffId)
                .Index(t => t.DepartmentId);
            
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
                        UnitName = c.String(),
                        UnitCode = c.String(),
                        UnitHead = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UnitId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        MiddleName = c.String(),
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
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.AssignStaffToDepts", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.AssignStaffToDepts", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Staffs", "Unit_UnitId", "dbo.Units");
            DropForeignKey("dbo.Units", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.TaskActivities", "ModuleTaskId", "dbo.ModuleTasks");
            DropForeignKey("dbo.ProjectModules", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ModuleTasks", "ProjectModuleId", "dbo.ProjectModules");
            DropForeignKey("dbo.ModuleTaskIssues", "ModuleTaskId", "dbo.ModuleTasks");
            DropForeignKey("dbo.AssignedTasks", "TaskActivityId", "dbo.TaskActivities");
            DropForeignKey("dbo.AssignedTasks", "StaffId", "dbo.Staffs");
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.Units", new[] { "DepartmentId" });
            DropIndex("dbo.AssignStaffToDepts", new[] { "DepartmentId" });
            DropIndex("dbo.AssignStaffToDepts", new[] { "StaffId" });
            DropIndex("dbo.ProjectModules", new[] { "ProjectId" });
            DropIndex("dbo.ModuleTaskIssues", new[] { "ModuleTaskId" });
            DropIndex("dbo.ModuleTasks", new[] { "ProjectModuleId" });
            DropIndex("dbo.TaskActivities", new[] { "ModuleTaskId" });
            DropIndex("dbo.Staffs", new[] { "Unit_UnitId" });
            DropIndex("dbo.AssignedTasks", new[] { "TaskActivityId" });
            DropIndex("dbo.AssignedTasks", new[] { "StaffId" });
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.Units");
            DropTable("dbo.Departments");
            DropTable("dbo.AssignStaffToDepts");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectModules");
            DropTable("dbo.ModuleTaskIssues");
            DropTable("dbo.ModuleTasks");
            DropTable("dbo.TaskActivities");
            DropTable("dbo.Staffs");
            DropTable("dbo.AssignedTasks");
        }
    }
}
