using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HourGlass.Resource
{
    public class ProjectResource
    {
        public CustomerResource Customer { get; set; }

        public string Name { get; set; }

        public List<EmployeeResource> Employees { get; set; }

        public List<TimeAllocationResource> TimeAllocations { get; set; }
    }
}
