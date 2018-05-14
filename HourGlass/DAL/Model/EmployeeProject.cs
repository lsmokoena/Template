using System;
using System.Collections.Generic;
using System.Text;

namespace Datastore.Model
{
    public class EmployeeProject : Base
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public DateTime AssignmentDate { get; set; }
    }
}
