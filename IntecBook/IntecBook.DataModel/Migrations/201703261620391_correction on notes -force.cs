namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctiononnotesforce : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Title", c => c.String());
            AddColumn("dbo.Notes", "content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "content");
            DropColumn("dbo.Notes", "Title");
        }
    }
}
