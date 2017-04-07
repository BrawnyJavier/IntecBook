namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IntecBookStoredEmails",
                c => new
                    {
                        EmailCode = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Body = c.String(nullable: false),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => t.EmailCode);
            
            AddColumn("dbo.Users", "username", c => c.String());
            AddColumn("dbo.Users", "password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "password");
            DropColumn("dbo.Users", "username");
            DropTable("dbo.IntecBookStoredEmails");
        }
    }
}
