using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HourGlass.Resource
{
    public class CustomerResource
    {
        public string Name { get; set; }

        public string ContactPerson { get; set; }

        public List<ProjectResource> Projects { get; set; }
    }
}
