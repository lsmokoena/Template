using Business.Interface;
using Datastore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repository
{
    public class CustomerRepository : DataRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HourGlassContext context) : base(context)
        {
        }
    }
}
