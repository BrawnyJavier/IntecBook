using IntecBook.classes;
using IntecBook.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace WebClient.Controllers.API
{
    public class TrimestresController : ApiController
    {
        // GET: api/Subjects
        [HttpGet]
        public IEnumerable<object> GetTrimestres()
        {
            using (var _context = new IntecBookContext())
            {
                var Schedules = _context.Schedule.ToList();
                var data = Schedules.Select(
                    schedule => new
                    {
                        Id = schedule.Id,
                        Trimestre = schedule.Trimestre,
                        Year = schedule.Year

                    }).ToList();
                return data;
            }
        }
        // GET: api/Trimestres/5
        [HttpGet]
        public object GetTrimestreById(int id)
        {
            //using (var _context = new IntecBookContext())
            //{
            //    return _context.Schedule.
            //        Where(x => x.Id == id).FirstOrDefault();
            //}
            return Thread.CurrentPrincipal.Identity;
        }
        [HttpGet]
        public IEnumerable<object> GetTrimestreSchedule(int id)
        {
            try
            {
                using (var context = new IntecBookContext())
                {

                    var QueryResult = (
                        from schedules in context.Schedule
                        join dailyschedule in context.DailySchedules
                        on schedules.Id equals dailyschedule.Schedule.Id
                        join studentsubjects in context.StudentSubjects
                        on dailyschedule.Id equals studentsubjects.Schedule.Id
                        join subjects in context.Subject
                        on studentsubjects.subject.Id equals subjects.Id
                        join days in context.Day
                        on dailyschedule.Day.Id equals days.Id
                        where schedules.Id == id
                        select new
                        {
                            Trimestre = schedules.Trimestre + " año:" + schedules.Year,
                            //StartHour = dailyschedule.StartHour.Hour,
                            //EndHour = dailyschedule.EndHour.Hour,
                            Horario = days.Name+" "+ dailyschedule.StartHour.Hour+"/"+ dailyschedule.EndHour.Hour,
                            Asignatura = subjects.Name,
                            Creditos = subjects.Creditos

                        }).ToList();
                    return QueryResult;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        // POST: api/Subjects
        [HttpPost]
        public object CreateTrimestre([FromBody]Schedule value)
        {
            try
            {
                using (var _context = new IntecBookContext())
                {
                    _context.Schedule.Add(value);
                    _context.SaveChanges();
                    return HttpStatusCode.OK;
                }
            }
            catch (Exception)
            {
                return HttpStatusCode.BadRequest;
            }
        }

        // PUT: api/Subjects/5
        [HttpPut]
        public void UpdateTrimestre(int id, [FromBody]Schedule value)
        {
            using (var _context = new IntecBookContext())
            {
                var SubjectInDatabase = _context.Schedule.Where(x => x.Id == id).FirstOrDefault();
                SubjectInDatabase.Year = value.Year;
                SubjectInDatabase.Trimestre = value.Trimestre;
                _context.SaveChanges();
            }
        }
        // DELETE: api/Subjects/5
        [HttpDelete]
        public object DeleteTrimestre(int id)
        {
            using (var _context = new IntecBookContext())
            {
                try
                {
                    _context.Schedule.Remove(
                        _context.Schedule.Where(x => x.Id == id).FirstOrDefault()
                            );
                    _context.SaveChanges();
                    return HttpStatusCode.OK;
                }
                catch (Exception)
                {
                    return HttpStatusCode.BadRequest;
                }
            }
        }







    }
}
