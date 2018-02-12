namespace SwiftPM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makePercentageNullableProjectModule : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectModules", "ModulePercentage", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectModules", "ModulePercentage", c => c.Double(nullable: false));
        }
    }
}
