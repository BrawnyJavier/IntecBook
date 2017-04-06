using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntecBook.classes;
using IntecBook.DataModel;
using IntecBook.DTOS;
using IntecBook;
using Newtonsoft.Json;

namespace WebClient.Controllers.API
{
    public class StudentSubjectsController : ApiController
    {
        // GET: api/StudentSubjects
        public IEnumerable<object> GetStudentSubjects()
        {
            using (var context = new IntecBookContext())
            {
                var queryData = (
                 from SS in context.StudentSubjects
                 join S in context.Subject
                 on SS.subject.Id equals S.Id
                 select new
                 {
                     S.Name,
                     S.Creditos,
                     Estudiante = SS.student.Name,
                     Periodo = SS.Id,
                     Periodo_Inicio = SS.Schedule.StartHour,
                     Periodo_Finalizacion = SS.Schedule.EndHour

                 }).ToList();
                return queryData;
            }
        }

        // GET: api/StudentSubjects/5
        public object GetStudentSubjectById(int id)
        {
            using (var context = new IntecBookContext())
            {
                var queryData = (
                  from SS in context.StudentSubjects
                  where (SS.Id == id)
                  join S in context.Subject
                  on SS.subject.Id equals S.Id

                  select new
                  {
                      S.Name,
                      S.Creditos,
                      Estudiante = SS.student.Name,
                      Periodo = SS.Id,
                      Periodo_Inicio = SS.Schedule.StartHour,
                      Periodo_Finalizacion = SS.Schedule.EndHour

                  }).FirstOrDefault();
                return queryData;
            }
        }
        // POST: api/StudentSubjects
        public object CreateStudentSubject([FromBody]StudentSubjectsDTO value)
        {
            try
            {
                using (var context = new IntecBookContext())
                {
                    var DailySchedule = new DailySchedules
                    {
                        Day = context.Day.Where(x => x.Id == value.DayId).FirstOrDefault(),
                        EndHour = value.EndHour,
                        StartHour = value.StartHour,
                        Schedule = context.Schedule.Where(x => x.Id == value.TrimestreId).FirstOrDefault(),
                    };
                    context.DailySchedules.Add(DailySchedule);
                    context.SaveChanges();
                    var toAdd = new StudentSubjects()
                    {
                        Schedule = DailySchedule,
                        //student =value.studentID,
                        subject = context.Subject.Where(x => x.Id == value.subjectID).FirstOrDefault()
                    };
                    context.StudentSubjects.Add(toAdd);
                    context.SaveChanges();
                    return HttpStatusCode.OK;
                }
            }
            catch (Exception e)
            {
                if (e.InnerException != null) return HttpStatusCode.BadRequest;
                else return HttpStatusCode.InternalServerError;
            }
        }
        // PUT: api/StudentSubjects/5
        public void UpdateStudentSubject(int id, [FromBody]string value)
        {
        }

        [HttpGet]
        public IEnumerable<Day> GetDays()
        {
            using (var contex = new IntecBookContext())
            {

                IEnumerable<Day> result = contex.Day.ToArray();
                return result;
            }

        }

        // DELETE: api/StudentSubjects/5
        public void DeleteStudentSubject(int id)
        {
        }
    }
}














