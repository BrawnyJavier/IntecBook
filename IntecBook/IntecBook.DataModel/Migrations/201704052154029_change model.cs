namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DailySchedules", "StartHour");
            DropColumn("dbo.DailySchedules", "EndHour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DailySchedules", "EndHour", c => c.Int(nullable: false));
            AddColumn("dbo.DailySchedules", "StartHour", c => c.Int(nullable: false));
        }
    }
}
