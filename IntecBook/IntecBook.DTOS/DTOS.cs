using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntecBook.DTOS
{
    public class StudentSubjectsDTO
    {
        public int Id { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public int DayId { get; set; }
        public int TrimestreId { get; set; }
        public int studentID { get; set; }
        public int subjectID { get; set;}
        //public List<Notes> Notes { get; set; }
    }
    public class NoteDTO
    {
        public int id { get; set; }
        public int StudentSubjectId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime creationDate { get; set; }
        public int ownerId { get; set; }
    }

}
