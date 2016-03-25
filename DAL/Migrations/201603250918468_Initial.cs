namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SubCategoryID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Problems",
                c => new
                    {
                        ProblemID = c.Int(nullable: false, identity: true),
                        Tags = c.String(maxLength: 500),
                        SubCategoryID = c.Int(),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProblemID)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryID)
                .Index(t => t.SubCategoryID);
            
            CreateTable(
                "dbo.Solutions",
                c => new
                    {
                        SolutionId = c.Int(nullable: false, identity: true),
                        Tags = c.String(maxLength: 500),
                        Rating = c.Single(nullable: false),
                        ProblemID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.SolutionId)
                .ForeignKey("dbo.Problems", t => t.ProblemID, cascadeDelete: true)
                .Index(t => t.ProblemID);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        StepID = c.Int(nullable: false, identity: true),
                        Sequence = c.Byte(nullable: false),
                        SolutionID = c.Int(),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.StepID)
                .ForeignKey("dbo.Solutions", t => t.SolutionID)
                .Index(t => t.SolutionID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        StepID = c.Int(),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Steps", t => t.StepID)
                .Index(t => t.StepID);
            
            CreateTable(
                "dbo.UsefulInfos",
                c => new
                    {
                        UsefulInfoID = c.Int(nullable: false, identity: true),
                        ProgamingLang = c.Int(nullable: false),
                        URL = c.String(maxLength: 200),
                        Tags = c.String(maxLength: 500),
                        ProblemID = c.Int(),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UsefulInfoID)
                .ForeignKey("dbo.Problems", t => t.ProblemID)
                .Index(t => t.ProblemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsefulInfos", "ProblemID", "dbo.Problems");
            DropForeignKey("dbo.Problems", "SubCategoryID", "dbo.SubCategories");
            DropForeignKey("dbo.Steps", "SolutionID", "dbo.Solutions");
            DropForeignKey("dbo.Comments", "StepID", "dbo.Steps");
            DropForeignKey("dbo.Solutions", "ProblemID", "dbo.Problems");
            DropForeignKey("dbo.SubCategories", "CategoryID", "dbo.Categories");
            DropIndex("dbo.UsefulInfos", new[] { "ProblemID" });
            DropIndex("dbo.Comments", new[] { "StepID" });
            DropIndex("dbo.Steps", new[] { "SolutionID" });
            DropIndex("dbo.Solutions", new[] { "ProblemID" });
            DropIndex("dbo.Problems", new[] { "SubCategoryID" });
            DropIndex("dbo.SubCategories", new[] { "CategoryID" });
            DropTable("dbo.UsefulInfos");
            DropTable("dbo.Comments");
            DropTable("dbo.Steps");
            DropTable("dbo.Solutions");
            DropTable("dbo.Problems");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Categories");
        }
    }
}
