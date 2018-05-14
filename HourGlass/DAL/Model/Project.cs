using System;
using System.Collections.Generic;
using System.Text;

namespace Datastore.Model
{
    public class Project : Base
    {
        public Customer Customer { get; set; }

        public string Name { get; set; }

        public List<EmployeeProject> ProjectEmployees { get; set; }

        public List<TimeAllocation> TimeAllocations { get; set; }
    }
}
