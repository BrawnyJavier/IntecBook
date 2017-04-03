namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correctionondailyschedules : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DailySchedules", "StartHour");
            DropColumn("dbo.DailySchedules", "EndHour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DailySchedules", "EndHour", c => c.DateTime(nullable: false));
            AddColumn("dbo.DailySchedules", "StartHour", c => c.DateTime(nullable: false));
        }
    }
}
