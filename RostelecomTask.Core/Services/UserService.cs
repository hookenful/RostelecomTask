using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RostelecomTask.Core.Domain.Entities;
using RostelecomTask.Core.Domain.Interfaces;

namespace RostelecomTask.Core.Services
{
    class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> GetUserById(long id)
        {
            return await _unitOfWork.Users.GetWithDepByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersByDepId(int depId)
        {
            return await _unitOfWork.Users.GetAllWithDepsByDepIdAsync(depId);
        }

        public async Task<User> CreateUser(User newUser)
        {
            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }

        public async Task UpdateUser(User userToBeUpdated, User user)
        {
            userToBeUpdated.UserName = user.UserName;
            userToBeUpdated.FullName = user.FullName;
            userToBeUpdated.DepartmentId = user.DepartmentId;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteUser(User user)
        {
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();
        }
    }
}
