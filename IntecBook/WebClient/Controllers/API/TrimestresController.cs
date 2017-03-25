using IntecBook.classes;
using IntecBook.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebClient.Controllers.API
{
    public class TrimestresController : ApiController
    {
        // GET: api/Subjects
        public IEnumerable<object> Get()
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
        public Schedule Get(int id)
        {
            using (var _context = new IntecBookContext())
            {
                return _context.Schedule.
                    Where(x => x.Id == id).FirstOrDefault();
            }
        }

        // POST: api/Subjects
        public object Post([FromBody]Schedule value)
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
        public void Put(int id, [FromBody]Schedule value)
        {
            using (var _context = new IntecBookContext())
            {
                var SubjectInDatabase = _context.Schedule.Where(x => x.Id == id).FirstOrDefault();
                //  SubjectInDatabase = value;
                _context.SaveChanges();

            }

        }

        // DELETE: api/Subjects/5
        public object Delete(int id)
        {
            using (var _context = new IntecBookContext())
            {
                try
                {
                    _context.Subject.Remove(
                        _context.Subject.Where(x => x.Id == id).FirstOrDefault()
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
