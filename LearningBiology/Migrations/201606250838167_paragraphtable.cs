namespace LearningBiology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paragraphtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paragraphs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SectionID = c.Int(nullable: false),
                        HasPicture = c.Boolean(nullable: false),
                        pictureName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sections", t => t.SectionID, cascadeDelete: true)
                .Index(t => t.SectionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paragraphs", "SectionID", "dbo.Sections");
            DropIndex("dbo.Paragraphs", new[] { "SectionID" });
            DropTable("dbo.Paragraphs");
        }
    }
}
