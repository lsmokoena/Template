using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interface;
using Datastore.Model;
using HourGlass.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HourGlass.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private ICustomerRepository CustomerRepository;
        private readonly IMapper Mapper;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
        {
            CustomerRepository = customerRepository;
            Mapper = mapper;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var customers = await CustomerRepository.GetAllAsync();

            if (customers == null)
            {
                return new NotFoundResult();
            }

            var customerRes = Mapper.Map<IList<Customer>, List<CustomerResource>>(customers);

            return Ok(customerRes);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var customer = await CustomerRepository.GetSingleAsync(c => c.Id == id);

            if (customer == null)
                return new NotFoundResult();

            var customerRes = Mapper.Map<Customer, CustomerResource>(customer);
            return new OkObjectResult(customerRes);
        }
        
        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CustomerResource customerResource)
        {
            try
            {
                var customer = Mapper.Map<CustomerResource, Customer>(customerResource);

                CustomerRepository.Add(customer);
                var customerRes = Mapper.Map<Customer, CustomerResource>(customer);

                return new CreatedResult("http://localhost:42097/api/Customers/" + customer.Id, customerRes);
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }
        
        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]string value)
        {
            var customer = await CustomerRepository.GetSingleAsync(c => c.Id == id);

            if (customer == null)
                return new NotFoundResult();

            customer.Name = value;
            //customer.Projects = null;
            customer.ContactPerson = value;

            CustomerRepository.Update(customer);

            return new OkObjectResult(customer);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await CustomerRepository.GetSingleAsync(c => c.Id == id);

            if (customer == null)
                return new NotFoundResult();

            //Deactivate client
            customer.IsDeleted = true;
            CustomerRepository.Update(customer);

            return new NoContentResult();
        }
    }
}
