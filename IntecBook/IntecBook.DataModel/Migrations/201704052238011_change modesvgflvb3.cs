namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemodesvgflvb3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailySchedules", "StartHour", c => c.DateTime(nullable: false));
            AddColumn("dbo.DailySchedules", "EndHour", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DailySchedules", "EndHour");
            DropColumn("dbo.DailySchedules", "StartHour");
        }
    }
}
