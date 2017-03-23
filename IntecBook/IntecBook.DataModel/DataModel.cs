using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IntecBook.classes;

namespace IntecBook.DataModel
{
    public class IntecBookContext : DbContext
    {         
        public DbSet<User> Users { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Day> Day { get; set; }
        public DbSet<DailySchedules> DailySchedules { get; set; }
        public DbSet<StudentSubjects> StudentSubjects { get; set; }
        public DbSet<Subjects> Subject { get; set; }
        public DbSet<Notes> Notes { get; set; }
    }
}
