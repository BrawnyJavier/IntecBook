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
        public int user_id { get; set; }
        public int subject_id { get; set; }
        public int DailySchedule_id { get; set; }
        //public List<Notes> Notes { get; set; }
    }
}
