using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RostelecomTask.Api.Resources;
using RostelecomTask.Api.Validators;
using RostelecomTask.Core.Domain.Entities;
using RostelecomTask.Core.Services;

namespace RostelecomTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController: ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<DepartmentResource>>> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDeps();
            var departmentResources = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResource>>(departments);

            return Ok(departmentResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentResource>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentById(id);

            if (department == null) return NotFound();

            var departmentResource = _mapper.Map<Department, DepartmentResource>(department);

            return Ok(departmentResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<DepartmentResource>> CreateDepartment([FromBody] SaveDepartmentResource model)
        {
            var validator = new SaveDepartmentResourceValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var departmentToCreate = _mapper.Map<SaveDepartmentResource, Department>(model);

            var newDepartment = await _departmentService.CreateDepartment(departmentToCreate);

            var department = await _departmentService.GetDepartmentById(newDepartment.Id);

            var departmentResource = _mapper.Map<Department, DepartmentResource>(department);

            return Ok(departmentResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentResource>> UpdateDepartment(int id, [FromBody] SaveDepartmentResource model)
        {
            var validator = new SaveDepartmentResourceValidator();
            var validationResult = await validator.ValidateAsync(model);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); 

            var depToBeUpdate = await _departmentService.GetDepartmentById(id);

            if (depToBeUpdate == null)
                return NotFound();

            var department = _mapper.Map<SaveDepartmentResource, Department>(model);

            await _departmentService.UpdateDepartment(depToBeUpdate, department);

            var updatedDep = await _departmentService.GetDepartmentById(id);
            var updatedDepartmentResource = _mapper.Map<Department, DepartmentResource>(updatedDep);

            return Ok(updatedDepartmentResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (id == 0)
                return BadRequest();

            var department = await _departmentService.GetDepartmentById(id);

            if (department == null)
                return NotFound();

            await _departmentService.DeleteDepartment(department);

            return NoContent();
        }


    }
}
