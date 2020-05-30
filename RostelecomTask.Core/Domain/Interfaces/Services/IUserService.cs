using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RostelecomTask.Core.Domain.Entities;

namespace RostelecomTask.Core.Services
{
   public interface IUserService
    {
        Task<User> GetUserById(long id);
        Task<IEnumerable<User>> GetUsersByDepId(long depId);
        Task<User> CreateUser(User newUser);
        Task UpdateUser(User userToBeUpdated, User user);
        Task DeleteUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
    }
}
