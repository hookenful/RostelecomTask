using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RostelecomTask.Core.Domain.Entities;

namespace RostelecomTask.Api.Resources
{
    public class DepartmentResource
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserResource> Users { get; set; }
    }
}
