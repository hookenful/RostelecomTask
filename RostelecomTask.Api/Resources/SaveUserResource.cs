using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RostelecomTask.Api.Resources
{
    public class SaveUserResource
    {
        public string FullName { get; set; }

        public string UserName { get; set; }

        public long DepartmentId { get; set; }

    }
}
