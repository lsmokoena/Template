using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HourGlass.Resource
{
    public class EmployeeResource
    {
        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ReferenceNumber { get; set; }

        public List<ProjectResource> Projects { get; set; }

        public List<TimeAllocationResource> TimeAllocations { get; set; }
    }
}
