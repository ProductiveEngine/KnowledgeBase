namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Problems", new[] { "SubCategoryID" });
            AlterColumn("dbo.Problems", "SubCategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Problems", "SubCategoryID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Problems", new[] { "SubCategoryID" });
            AlterColumn("dbo.Problems", "SubCategoryID", c => c.Int());
            CreateIndex("dbo.Problems", "SubCategoryID");
        }
    }
}
