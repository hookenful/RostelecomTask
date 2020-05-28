using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RostelecomTask.Core.Domain.Entities;
using RostelecomTask.Core.Repositories;

namespace RostelecomTask.Infrastructure.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
        private AppDbContext AppDbContext => Context;

        public async Task<IEnumerable<User>> GetAllWithDepsAsync()
        {
            return await AppDbContext.Users
                .Include(m => m.Department)
                .ToListAsync();
        }

        public async Task<User> GetWithDepByIdAsync(long id)
        {
            return await AppDbContext.Users
                .Include(m => m.Department)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllWithDepsByDepIdAsync(long depId)
        {
            return await AppDbContext.Users
                .Include(m => m.Department)
                .Where(m => m.DepartmentId == depId)
                .ToListAsync();
        }

        
    }
}
