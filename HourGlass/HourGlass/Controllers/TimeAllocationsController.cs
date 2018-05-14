using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interface;
using Datastore.Model;
using HourGlass.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HourGlass.Controllers
{
    [Produces("application/json")]
    [Route("api/TimeAllocations")]
    public class TimeAllocationsController : Controller
    {
        private ITimeAllocationRepository TimeAllocationRepository;

        public TimeAllocationsController(ITimeAllocationRepository timeAllocationRepository)
        {
            TimeAllocationRepository = timeAllocationRepository;
        }

        // GET: api/TimeAllocations
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TimeAllocations/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/TimeAllocations
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/TimeAllocations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
