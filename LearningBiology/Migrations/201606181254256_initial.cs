namespace LearningBiology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        text = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OfferedAswers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        AnswerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Answers", t => t.AnswerID, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID)
                .Index(t => t.AnswerID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        sectionID = c.Int(nullable: false),
                        Type = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sections", t => t.sectionID, cascadeDelete: true)
                .Index(t => t.sectionID);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortContent = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "sectionID", "dbo.Sections");
            DropForeignKey("dbo.OfferedAswers", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.OfferedAswers", "AnswerID", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "sectionID" });
            DropIndex("dbo.OfferedAswers", new[] { "AnswerID" });
            DropIndex("dbo.OfferedAswers", new[] { "QuestionID" });
            DropTable("dbo.Sections");
            DropTable("dbo.Questions");
            DropTable("dbo.OfferedAswers");
            DropTable("dbo.Answers");
        }
    }
}
