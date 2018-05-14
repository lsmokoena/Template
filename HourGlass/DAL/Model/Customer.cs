using System;
using System.Collections.Generic;
using System.Text;

namespace Datastore.Model
{
    public class Customer : Base
    {
        public string Name { get; set; }

        public string ContactPerson { get; set; }

        //public List<Project> Projects { get; set; }
    }
}
