﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebClient.Controllers.API
{
    public class NotasController : ApiController
    {
        // GET: api/Notas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Notas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Notas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Notas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Notas/5
        public void Delete(int id)
        {
        }
    }
}