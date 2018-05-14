using Business.Interface;
using Datastore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repository
{
    public class ProjectRepository : DataRepository<Project>, IProjectRepository
    {
        public ProjectRepository(HourGlassContext context) : base(context)
        {
        }
    }
}
