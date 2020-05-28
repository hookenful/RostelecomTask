using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RostelecomTask.Api.Resources;
using RostelecomTask.Core.Domain.Entities;

namespace RostelecomTask.Api.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<Department, DepartmentResource>();

            CreateMap<UserResource, User>();
            CreateMap<DepartmentResource, Department>();

            CreateMap<SaveDepartmentResource, Department>();
            CreateMap<SaveUserResource, User>();
        }
    }
}
