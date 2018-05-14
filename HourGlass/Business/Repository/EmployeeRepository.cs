using Business.Interface;
using Datastore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repository
{
    public class EmployeeRepository : DataRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HourGlassContext context) : base(context)
        {
        }
    }
}
