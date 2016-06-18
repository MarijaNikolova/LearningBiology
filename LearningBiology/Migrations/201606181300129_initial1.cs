namespace LearningBiology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sections", "VideoName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sections", "VideoName");
        }
    }
}
