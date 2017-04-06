namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subtitles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Subtitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "Subtitle");
        }
    }
}
