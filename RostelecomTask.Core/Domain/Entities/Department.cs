using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RostelecomTask.Core.Domain.Entities
{
   public class Department: BaseEntity
    {
        public Department()
        {
            Users = new Collection<User>();
        }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
