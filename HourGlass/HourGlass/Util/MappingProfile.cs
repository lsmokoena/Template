using AutoMapper;
using Datastore.Model;
using HourGlass.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HourGlass.Util
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            //Mapping Domain to API Resources
            CreateMap<Customer, CustomerResource>();

            //Mapping API resources to domain
            CreateMap<CustomerResource, Customer>();

        }
    }
}
