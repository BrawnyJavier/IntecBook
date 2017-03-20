namespace IntecBook.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailySchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartHour = c.DateTime(nullable: false),
                        EndHour = c.DateTime(nullable: false),
                        Day_Id = c.Int(),
                        Schedule_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Days", t => t.Day_Id)
                .ForeignKey("dbo.Schedules", t => t.Schedule_Id)
                .Index(t => t.Day_Id)
                .Index(t => t.Schedule_Id);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        schedule_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schedules", t => t.schedule_Id)
                .Index(t => t.schedule_Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Trimestre = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                        profilePic = c.String(),
                        UserMajor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Majors", t => t.UserMajor_Id)
                .Index(t => t.UserMajor_Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Owner_Id = c.Int(),
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id)
                .ForeignKey("dbo.StudentSubjects", t => t.Subject_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.StudentSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Schedule_Id = c.Int(),
                        student_Id = c.Int(),
                        subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DailySchedules", t => t.Schedule_Id)
                .ForeignKey("dbo.Users", t => t.student_Id)
                .ForeignKey("dbo.Subjects", t => t.subject_Id)
                .Index(t => t.Schedule_Id)
                .Index(t => t.student_Id)
                .Index(t => t.subject_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MajorName = c.String(),
                        MajorDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailySchedules", "Schedule_Id", "dbo.Schedules");
            DropForeignKey("dbo.Users", "UserMajor_Id", "dbo.Majors");
            DropForeignKey("dbo.Schedules", "User_Id", "dbo.Users");
            DropForeignKey("dbo.StudentSubjects", "subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.StudentSubjects", "student_Id", "dbo.Users");
            DropForeignKey("dbo.StudentSubjects", "Schedule_Id", "dbo.DailySchedules");
            DropForeignKey("dbo.Notes", "Subject_Id", "dbo.StudentSubjects");
            DropForeignKey("dbo.Notes", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Days", "schedule_Id", "dbo.Schedules");
            DropForeignKey("dbo.DailySchedules", "Day_Id", "dbo.Days");
            DropIndex("dbo.StudentSubjects", new[] { "subject_Id" });
            DropIndex("dbo.StudentSubjects", new[] { "student_Id" });
            DropIndex("dbo.StudentSubjects", new[] { "Schedule_Id" });
            DropIndex("dbo.Notes", new[] { "Subject_Id" });
            DropIndex("dbo.Notes", new[] { "Owner_Id" });
            DropIndex("dbo.Users", new[] { "UserMajor_Id" });
            DropIndex("dbo.Schedules", new[] { "User_Id" });
            DropIndex("dbo.Days", new[] { "schedule_Id" });
            DropIndex("dbo.DailySchedules", new[] { "Schedule_Id" });
            DropIndex("dbo.DailySchedules", new[] { "Day_Id" });
            DropTable("dbo.Majors");
            DropTable("dbo.Subjects");
            DropTable("dbo.StudentSubjects");
            DropTable("dbo.Notes");
            DropTable("dbo.Users");
            DropTable("dbo.Schedules");
            DropTable("dbo.Days");
            DropTable("dbo.DailySchedules");
        }
    }
}
