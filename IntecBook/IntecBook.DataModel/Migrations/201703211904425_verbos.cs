namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class verbos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "Name", c => c.String(nullable: false, defaultValue: ""));
            
        }
        
        public override void Down()
        {
        }
    }
}
