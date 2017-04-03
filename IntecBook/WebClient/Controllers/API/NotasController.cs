using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntecBook.classes;
using IntecBook.DataModel;

namespace WebClient.Controllers.API
{
    public class NotasController : ApiController
    {
        // GET: api/Notas
        public IEnumerable<object> Get()
        {
            using (var _context = new IntecBookContext())
            {
                return _context.Notes.ToList();
            }      
        }                // GET: api/Notas/5
        public object Get(int id)
        {
            using (var _context = new IntecBookContext())
            {
                return _context.Notes.Where(x => x.Id == id).FirstOrDefault();
            }
        }
        // POST: api/Notas
        public object Post([FromBody]Notes value)
        {
            try
            {
                using (var _context = new IntecBookContext())
                {
                   _context.Notes.Add(value);
                    _context.SaveChanges();
                    return HttpStatusCode.OK;

                }
            }
            catch (Exception)
            {
                return HttpStatusCode.BadRequest;
            }
        }
        // PUT: api/Notas/5
        public object Put(int id, [FromBody]Notes value)
        {
            try
            {
                using(var context = new IntecBookContext())
                {
                    var NoteInDatabase = context.Notes.Where(x => x.Id == id).FirstOrDefault();
                    NoteInDatabase.content = value.content;
                    NoteInDatabase.Title = value.Title;
                    context.SaveChanges();
                    return HttpStatusCode.OK;

                }
            }
            catch (Exception)
            {
                return HttpStatusCode.NotModified;
            }
        }

        // DELETE: api/Notas/5
        public object Delete(int id)
        {
            try
            {
                using (var contex = new IntecBookContext())
                {
                    contex.Notes.Remove(
                        contex.Notes.Where(x => x.Id == id).FirstOrDefault()
                        );               
                    return HttpStatusCode.OK;
                }

            }catch (Exception)
            {
                return HttpStatusCode.NotFound;
            }
        }
    }
}
