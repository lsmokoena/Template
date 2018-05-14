using System;
using System.Collections.Generic;
using System.Text;

namespace Datastore.Model
{
    public class Employee : Base
    {
        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ReferenceNumber { get; set; }

        public List<EmployeeProject> EmployeeProjects { get; set; }

        public List<TimeAllocation> TimeAllocation { get; set; }
    }
}
