namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class undele : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Creditos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StudentSubjects", "subject_Id", c => c.Int());
            CreateIndex("dbo.StudentSubjects", "subject_Id");
            AddForeignKey("dbo.StudentSubjects", "subject_Id", "dbo.Subjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSubjects", "subject_Id", "dbo.Subjects");
            DropIndex("dbo.StudentSubjects", new[] { "subject_Id" });
            DropColumn("dbo.StudentSubjects", "subject_Id");
            DropTable("dbo.Subjects");
        }
    }
}
