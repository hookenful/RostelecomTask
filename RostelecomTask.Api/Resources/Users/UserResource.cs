using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RostelecomTask.Api.Resources
{
    public class UserResource
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public DepartmentResource Department { get; set; }
    }
}
