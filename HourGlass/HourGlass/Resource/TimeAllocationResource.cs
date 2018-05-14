using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HourGlass.Resource
{
    public class TimeAllocationResource
    {
        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Note { get; set; }
    }
}
