﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TestOwin
{
    public class ValuesController : ApiController
    {
        //[Route("api/shit")]
        // GET api/values 
        public IEnumerable<string> Get()
        {
            throw new Exception("Dummy error");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5 
        public string Get(string id)
        {
            return "value of String" + id;
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    } 
}
