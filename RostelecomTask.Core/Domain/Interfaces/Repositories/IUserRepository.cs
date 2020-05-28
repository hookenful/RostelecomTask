using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RostelecomTask.Core.Domain.Entities;

namespace RostelecomTask.Core.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        Task<IEnumerable<User>> GetAllWithDepsAsync();
        Task<User> GetWithDepByIdAsync(long id);
        Task<IEnumerable<User>> GetAllWithDepsByDepIdAsync(long depId);
    }
}
