namespace LearningBiology.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useranswer1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAnswers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        AnswerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            AddColumn("dbo.Answers", "UserAnswer_ID", c => c.Int());
            CreateIndex("dbo.Answers", "UserAnswer_ID");
            AddForeignKey("dbo.Answers", "UserAnswer_ID", "dbo.UserAnswers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAnswers", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.Answers", "UserAnswer_ID", "dbo.UserAnswers");
            DropIndex("dbo.UserAnswers", new[] { "QuestionID" });
            DropIndex("dbo.Answers", new[] { "UserAnswer_ID" });
            DropColumn("dbo.Answers", "UserAnswer_ID");
            DropTable("dbo.UserAnswers");
        }
    }
}
