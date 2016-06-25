namespace LearningBiology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagestable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SectionID = c.Int(nullable: false),
                        ParagraphNumber = c.Int(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sections", t => t.SectionID, cascadeDelete: true)
                .Index(t => t.SectionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "SectionID", "dbo.Sections");
            DropIndex("dbo.Images", new[] { "SectionID" });
            DropTable("dbo.Images");
        }
    }
}
