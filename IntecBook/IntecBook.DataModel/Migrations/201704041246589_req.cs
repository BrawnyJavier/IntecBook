namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class req : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DailySchedules", 
                "Day_Id",
                "dbo.Days");
            DropForeignKey("dbo.StudentSubjects", "Schedule_Id", "dbo.DailySchedules");
            DropForeignKey("dbo.Notes", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.StudentSubjects", "student_Id", "dbo.Users");
            DropForeignKey("dbo.StudentSubjects", "subject_Id", "dbo.Subjects");
            DropIndex("dbo.DailySchedules", new[] { "Day_Id" });
            DropIndex("dbo.Notes", new[] { "Owner_Id" });
            DropIndex("dbo.StudentSubjects", new[] { "Schedule_Id" });
            DropIndex("dbo.StudentSubjects", new[] { "student_Id" });
            DropIndex("dbo.StudentSubjects", new[] { "subject_Id" });
            AlterColumn("dbo.DailySchedules", "Day_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Notes", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Notes", "Owner_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentSubjects", "Schedule_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentSubjects", "student_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentSubjects", "subject_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Subjects", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.DailySchedules", "Day_Id");
            CreateIndex("dbo.Notes", "Owner_Id");
            CreateIndex("dbo.StudentSubjects", "Schedule_Id");
            CreateIndex("dbo.StudentSubjects", "student_Id");
            CreateIndex("dbo.StudentSubjects", "subject_Id");
            AddForeignKey("dbo.DailySchedules", "Day_Id", "dbo.Days", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentSubjects", "Schedule_Id", "dbo.DailySchedules", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Notes", "Owner_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentSubjects", "student_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentSubjects", "subject_Id", "dbo.Subjects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSubjects", "subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.StudentSubjects", "student_Id", "dbo.Users");
            DropForeignKey("dbo.Notes", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.StudentSubjects", "Schedule_Id", "dbo.DailySchedules");
            DropForeignKey("dbo.DailySchedules", "Day_Id", "dbo.Days");
            DropIndex("dbo.StudentSubjects", new[] { "subject_Id" });
            DropIndex("dbo.StudentSubjects", new[] { "student_Id" });
            DropIndex("dbo.StudentSubjects", new[] { "Schedule_Id" });
            DropIndex("dbo.Notes", new[] { "Owner_Id" });
            DropIndex("dbo.DailySchedules", new[] { "Day_Id" });
            AlterColumn("dbo.Subjects", "Name", c => c.String());
            AlterColumn("dbo.StudentSubjects", "subject_Id", c => c.Int());
            AlterColumn("dbo.StudentSubjects", "student_Id", c => c.Int());
            AlterColumn("dbo.StudentSubjects", "Schedule_Id", c => c.Int());
            AlterColumn("dbo.Notes", "Owner_Id", c => c.Int());
            AlterColumn("dbo.Notes", "Title", c => c.String());
            AlterColumn("dbo.DailySchedules", "Day_Id", c => c.Int());
            CreateIndex("dbo.StudentSubjects", "subject_Id");
            CreateIndex("dbo.StudentSubjects", "student_Id");
            CreateIndex("dbo.StudentSubjects", "Schedule_Id");
            CreateIndex("dbo.Notes", "Owner_Id");
            CreateIndex("dbo.DailySchedules", "Day_Id");
            AddForeignKey("dbo.StudentSubjects", "subject_Id", "dbo.Subjects", "Id");
            AddForeignKey("dbo.StudentSubjects", "student_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Notes", "Owner_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.StudentSubjects", "Schedule_Id", "dbo.DailySchedules", "Id");
            AddForeignKey("dbo.DailySchedules", "Day_Id", "dbo.Days", "Id");
        }
    }
}
