using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RostelecomTask.Core.Repositories;

namespace RostelecomTask.Core.Domain.Interfaces
{
   public interface IUnitOfWork: IDisposable
    {
        IDepartmentRepository Departments { get; }
        IUserRepository Users { get; }
        Task<int> CommitAsync();
    }
}
