using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RostelecomTask.Core.Domain.Entities;

namespace RostelecomTask.Core.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(long id);
        Task<Department> CreateDepartment(Department department);
        Task UpdateDepartment(Department depToBeUpdated, Department department);
        Task DeleteDepartment(Department department);
    }
}
