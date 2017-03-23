namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DaysChangeinmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Days", "schedule_Id", "dbo.Schedules");
            DropIndex("dbo.Days", new[] { "schedule_Id" });
            DropColumn("dbo.Days", "schedule_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Days", "schedule_Id", c => c.Int());
            CreateIndex("dbo.Days", "schedule_Id");
            AddForeignKey("dbo.Days", "schedule_Id", "dbo.Schedules", "Id");
        }
    }
}
