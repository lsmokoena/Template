using Business.Interface;
using Datastore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repository
{
    public class TimeAllocationRepository : DataRepository<TimeAllocation>, ITimeAllocationRepository
    {
        public TimeAllocationRepository(HourGlassContext context) : base(context)
        {
        }
    }
}
