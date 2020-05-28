using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RostelecomTask.Core.Domain.Entities;
using RostelecomTask.Core.Repositories;

namespace RostelecomTask.Infrastructure.Repositories
{
    class DepartmentRepository: Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        {
        }
        private AppDbContext AppDbContext => Context;
        public async Task<IEnumerable<Department>> GetAllWithUsersAsync()
        {
            return await AppDbContext.Departments
                .Include(a => a.Users)
                .ToListAsync();
        }

        public Task<Department> GetWithUsersByIdAsync(long id)
        {
            return AppDbContext.Departments
                .Include(a => a.Users)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
