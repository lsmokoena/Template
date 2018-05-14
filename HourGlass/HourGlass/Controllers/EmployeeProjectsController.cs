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
    [Route("api/EmployeeProjects")]
    public class EmployeeProjectsController : Controller
    {
        private IEmployeeProjectRepository EmployeeProjectRepository;

        public EmployeeProjectsController(IEmployeeProjectRepository employeeProjectRepository)
        {
            EmployeeProjectRepository = employeeProjectRepository;
        }

        // GET: api/EmployeeProjects
        [HttpGet]
        public IEnumerable<EmployeeProjectResource> Get()
        {
            return null;
        }

        // GET: api/EmployeeProjects/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/EmployeeProjects
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/EmployeeProjects/5
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
