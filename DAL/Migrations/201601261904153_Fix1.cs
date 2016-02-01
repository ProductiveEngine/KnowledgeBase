namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "StepVO_StepID", newName: "StepID");
            RenameIndex(table: "dbo.Comments", name: "IX_StepVO_StepID", newName: "IX_StepID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Comments", name: "IX_StepID", newName: "IX_StepVO_StepID");
            RenameColumn(table: "dbo.Comments", name: "StepID", newName: "StepVO_StepID");
        }
    }
}
