using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RostelecomTask.Core.Domain.Entities;
using RostelecomTask.Core.Domain.Interfaces;

namespace RostelecomTask.Core.Services
{
   public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Department> GetDepartmentById(long id)
        {
            return await _unitOfWork.Departments.GetWithUsersByIdAsync(id);
        }

        public async Task<Department> CreateDepartment(Department newDepartment)
        {
            await _unitOfWork.Departments.AddAsync(newDepartment);
            return newDepartment;
        }

        public async Task UpdateDepartment(Department depToBeUpdated, Department department)
        {
            depToBeUpdated.Name = department.Name;
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteDepartment(Department department)
        {
            _unitOfWork.Departments.Remove(department);
            await _unitOfWork.CommitAsync();
        }
    }
}
