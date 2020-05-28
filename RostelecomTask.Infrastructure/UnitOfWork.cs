using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RostelecomTask.Core.Domain.Entities;
using RostelecomTask.Core.Domain.Interfaces;
using RostelecomTask.Core.Repositories;
using RostelecomTask.Infrastructure.Repositories;

namespace RostelecomTask.Infrastructure
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;
        private UserRepository _userRepository;
        private DepartmentRepository _departmentRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);
        public IDepartmentRepository Departments => _departmentRepository ??=  new DepartmentRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
