﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntecBook.classes;
using IntecBook.DataModel;
namespace WebClient.Controllers.API
{
    public class SubjectsController : ApiController
    {
        public SubjectsController()
        {
            var _Context = new IntecBookContext();
        }
        // GET: api/Subjects
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Subjects/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Subjects
        public void Post([FromBody]string value)
        {
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
