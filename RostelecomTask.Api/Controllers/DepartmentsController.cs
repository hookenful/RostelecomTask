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

        public DepartmentsController( IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
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

            var artistResource = _mapper.Map<Department, DepartmentResource>(department);

            return Ok(department);
        }
    }
}
