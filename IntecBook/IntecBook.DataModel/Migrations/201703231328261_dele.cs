namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dele : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentSubjects", "subject_Id", "dbo.Subjects");
            DropIndex("dbo.StudentSubjects", new[] { "subject_Id" });
            DropColumn("dbo.StudentSubjects", "subject_Id");
            DropTable("dbo.Subjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StudentSubjects", "subject_Id", c => c.Int());
            CreateIndex("dbo.StudentSubjects", "subject_Id");
            AddForeignKey("dbo.StudentSubjects", "subject_Id", "dbo.Subjects", "Id");
        }
    }
}
