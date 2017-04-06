namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemodesl2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudentSubjects", "subject_Id", "dbo.Subjects");
            DropIndex("dbo.StudentSubjects", new[] { "subject_Id" });
            AlterColumn("dbo.StudentSubjects", "subject_Id", c => c.Int());
            CreateIndex("dbo.StudentSubjects", "subject_Id");
            AddForeignKey("dbo.StudentSubjects", "subject_Id", "dbo.Subjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSubjects", "subject_Id", "dbo.Subjects");
            DropIndex("dbo.StudentSubjects", new[] { "subject_Id" });
            AlterColumn("dbo.StudentSubjects", "subject_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentSubjects", "subject_Id");
            AddForeignKey("dbo.StudentSubjects", "subject_Id", "dbo.Subjects", "Id", cascadeDelete: true);
        }
    }
}
