using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntecBook.classes
{

    public class Major
    {
        public int Id { get; set; }
        public string MajorName { get; set; }
        public string MajorDescription { get; set; }
        public List<User> Users { get; set; }
    }
    public class Schedule
    {
        public int Id { get; set; }
        public User User { get; set; }
        //public int UserID { get; set; }
        public List<Day> Days { get; set; }
        public int Year { get; set; }
        public int Trimestre { get; set; }
    }
    public class Day
    {
        public int Id { get; set; }
        public Schedule schedule { get; set; }
        public string Name { get; set; }
        public List<DailySchedules> DaySchedule { get; set; }

    }
    public class User
    {
        public int Id { get; set; }
        public Major UserMajor { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<StudentSubjects> Subjects { get; set; }
        public List<Notes> Notes { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string profilePic { get; set; }
    }
    public class DailySchedules
    {
        public int Id { get; set; }
        public Schedule Schedule { get; set; }
        public Day Day { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public List<StudentSubjects> Subjects { get; set; }
    }
    public class StudentSubjects
    {
        public int Id { get; set; }
        public User student { get; set; }
        public Subject subject { get; set; }
        public DailySchedules Schedule { get; set; }
        public List<Notes> Notes { get; set; }
    }
    public class Subject
    {
        public int Id { get; set; }
        string name { get; set; }
        public List<StudentSubjects> EnrolledStudents;

    }
    public class Notes
    {
        public int Id { get; set; }
        public User Owner { get; set; }
        public StudentSubjects Subject { get; set; }
    }

}
