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
        public IEnumerable<object> Get()
        {
            using (var context = new IntecBookContext())
            {
                //var data =
                //     context.StudentSubjects.Join(
                //         context.Subject,
                //         StdSub => StdSub.Id,
                //         Subject => Subject.Id,
                //         (StdSub, Subject) =>
                //         new
                //         {
                //             Asignatura = Subject.Name,
                //             Creditos = Subject.Creditos,
                //             Estudiante = StdSub.student,
                //             Periodo = StdSub.Schedule.Id
                //         });
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
        public string Get(int id)
        {
            return "value";
        }
                // POST: api/StudentSubjects
        public object Post([FromBody]object value)
        {
            try
            {
                
                var as_StudentSubject = JsonConvert.DeserializeObject<StudentSubjectsDTO>(value.ToString());
             
                using (var context = new IntecBookContext())
                {
                    var toAdd = new StudentSubjects()
                    {
                       

                        // Schedule = trimestre
                        Schedule = context.DailySchedules.Where(x=> x.Id == as_StudentSubject.Id).FirstOrDefault()
                    };
                    //value.
                    //context.StudentSubjects.Add();
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/StudentSubjects/5
        public void Delete(int id)
        {
        }
    }
}
