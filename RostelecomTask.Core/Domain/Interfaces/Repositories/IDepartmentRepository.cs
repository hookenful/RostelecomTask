using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RostelecomTask.Core.Domain.Entities;

namespace RostelecomTask.Core.Repositories
{
  public  interface IDepartmentRepository: IRepository<Department>
  {
      Task<IEnumerable<Department>> GetAllWithUsersAsync();
      Task<Department> GetWithUsersByIdAsync(long id);

  }
}
