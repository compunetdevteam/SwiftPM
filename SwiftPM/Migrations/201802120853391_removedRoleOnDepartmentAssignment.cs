namespace SwiftPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedRoleOnDepartmentAssignment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Department_DepartmentId", c => c.Int());
            CreateIndex("dbo.Projects", "Department_DepartmentId");
            AddForeignKey("dbo.Projects", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
            DropColumn("dbo.AssignStaffToDepts", "StaffRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssignStaffToDepts", "StaffRole", c => c.String());
            DropForeignKey("dbo.Projects", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Projects", new[] { "Department_DepartmentId" });
            DropColumn("dbo.Projects", "Department_DepartmentId");
        }
    }
}
