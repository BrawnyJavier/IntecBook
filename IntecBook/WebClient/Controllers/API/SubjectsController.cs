using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntecBook.classes;
using IntecBook.DataModel;
using System.Data.Entity;

namespace WebClient.Controllers.API
{
    public class SubjectsController : ApiController
    {
        public SubjectsController()
        {
            var _Context = new IntecBookContext();
        }
        // GET: api/Subjects
        public IEnumerable<object> Get()
        {
            using (var _context = new IntecBookContext())
            {
                var SubjectsData = _context.Subject.ToList();
                var data = SubjectsData.Select(
                    subject => new 
                    {
                        Creditos = subject.Creditos,
                        Id = subject.Id,
                        Name = subject.Name
                    }).ToList();
                return data;
            }
        }
        // GET: api/Subjects/5
        public Subjects Get(int id)
        {
            using (var _context = new IntecBookContext())
            {
                return _context.Subject.
                    Where(x => x.Id == id).FirstOrDefault();
            }
        }

        // POST: api/Subjects
        public object Post([FromBody]Subjects value)
        {
            try
            {
                using (var _context = new IntecBookContext())
                {
                    _context.Subject.Add(value);
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Subjects/5
        public void Delete(int id)
        {
        }
    }
}
