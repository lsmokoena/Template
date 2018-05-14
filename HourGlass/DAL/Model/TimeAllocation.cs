using System;
using System.Collections.Generic;
using System.Text;

namespace Datastore.Model
{
    public class TimeAllocation : Base
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Note { get; set; }
    }
}
