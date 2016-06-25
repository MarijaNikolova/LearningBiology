namespace LearningBiology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paragraphtable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paragraphs", "content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Paragraphs", "content");
        }
    }
}
