using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RostelecomTask.Core.Domain.Entities;

namespace RostelecomTask.Core.Services
{
    interface IUserService
    {
        Task<User> GetUserById(long id);
        Task<IEnumerable<User>> GetUsersByDepId(int depId);
        Task<User> CreateUser(User newUser);
        Task UpdateUser(User userToBeUpdated, User user);
        Task DeleteUser(User user);
    }
}
