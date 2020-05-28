using System;
using System.Collections.Generic;
using System.Text;

namespace RostelecomTask.Core.Domain.Entities
{
  public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTime SettledAt { get; set; }
        public Department Department { get; set; }
    }
}
