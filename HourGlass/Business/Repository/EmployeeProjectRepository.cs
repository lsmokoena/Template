using Business.Interface;
using Datastore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repository
{
    public class EmployeeProjectRepository : DataRepository<EmployeeProject>, IEmployeeProjectRepository
    {
        public EmployeeProjectRepository(HourGlassContext context) : base(context)
        {
        }
    }
}
