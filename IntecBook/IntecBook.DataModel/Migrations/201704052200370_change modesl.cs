namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemodesl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailySchedules", "StartHour", c => c.Double(nullable: false));
            AddColumn("dbo.DailySchedules", "EndHour", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DailySchedules", "EndHour");
            DropColumn("dbo.DailySchedules", "StartHour");
        }
    }
}
