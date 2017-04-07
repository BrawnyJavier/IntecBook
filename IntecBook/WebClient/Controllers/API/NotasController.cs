using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntecBook.classes;
using IntecBook.DTOS;
using IntecBook.DataModel;

namespace WebClient.Controllers.API
{
    public class NotasController : ApiController
    {
        // GET: api/Notas
        [HttpGet]
        public IEnumerable<object> GetNotes()
        {
            using (var _context = new IntecBookContext())
            {
                var QueryResult = (
                    from StudentSubject in _context.StudentSubjects
                    join subject in _context.Subject
                    on StudentSubject.subject.Id equals subject.Id
                    join Notes in _context.Notes
                    on StudentSubject.Id equals Notes.Subject.Id
                    select new
                    {
                        id = Notes.Id,
                        subject = subject.Name,
                        subjectId = subject.Id,
                        title = Notes.Title

                    }).ToList();
                return QueryResult;
            }
        }                // GET: api/Notas/5
        [HttpGet]
        public object GetNoteById(int id)
        {
            using (var _context = new IntecBookContext())
            {
                var QueryResult = (
                    from StudentSubject in _context.StudentSubjects
                    join subject in _context.Subject
                    on StudentSubject.subject.Id equals subject.Id
                    join Notes in _context.Notes
                    on StudentSubject.Id equals Notes.Subject.Id
                    where Notes.Id == id
                    select new
                    {
                        id = Notes.Id,
                        subject = subject.Name,
                        subjectId = subject.Id,
                        title = Notes.Title,
                        date = Notes.creationDate.Day + "/" + Notes.creationDate.Month + "/" + Notes.creationDate.Year,
                        content = Notes.content,
                        subtitle = Notes.Subtitle
                    }).FirstOrDefault();
                return QueryResult;
            }
        }
        // POST: api/Notas
        [HttpPost]
        public object CreateNote([FromBody]NoteDTO value)
        {
            try
            {
                using (var _context = new IntecBookContext())
                {
                    Notes Note = new Notes();
                    Note.content = value.content;
                    Note.creationDate = DateTime.Now;
                    Note.Owner = _context.Users.Where(u => u.Id == value.ownerId).FirstOrDefault();
                    Note.Subject = _context.StudentSubjects.Where(ss => ss.Id == value.StudentSubjectId).FirstOrDefault();
                    Note.Title = value.title;
                    _context.Notes.Add(Note);
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
        [HttpPut]
        public object UpdateNote([FromBody]Notes value)
        {
            try
            {
                using (var context = new IntecBookContext())
                {
                    var NoteInDatabase = context.Notes.Where(x => x.Id == value.Id).FirstOrDefault();
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
        [HttpDelete]
        public object DeleteNote(int id)
        {
            try
            {
                using (var contex = new IntecBookContext())
                {
                    var noteindb = contex.Notes.Where(n => n.Id == id).FirstOrDefault();
                    contex.Notes.Remove(
                      noteindb
                        );
                    contex.SaveChanges();
                    return HttpStatusCode.OK;
                }

            }
            catch (Exception)
            {
                return HttpStatusCode.NotFound;
            }
        }
    }
}
