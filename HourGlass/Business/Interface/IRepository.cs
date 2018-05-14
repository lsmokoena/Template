using Datastore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface ICustomerRepository : IDataRepository<Customer> { }

    public interface IEmployeeRepository : IDataRepository<Employee> { }

    public interface IProjectRepository : IDataRepository<Project> { }

    public interface IEmployeeProjectRepository : IDataRepository<EmployeeProject> { }

    public interface ITimeAllocationRepository : IDataRepository<TimeAllocation> { }
}
