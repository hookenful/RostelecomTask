using System;
using System.Collections;
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
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

     
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResource>> GetUsersByDepId(long depId)
        {
            var users = await _userService.GetUsersByDepId(depId);

            if (users == null) return NotFound();

            var userResource = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return Ok(userResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<UserResource>> CreateUser([FromBody] SaveUserResource model)
        {
            var validator = new SaveUserResourceValidator();

            var validationResult = validator.Validate(model);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var userToCreate = _mapper.Map<SaveUserResource, User>(model);

            var newUser = await _userService.CreateUser(userToCreate);

            var user = await _userService.GetUserById(newUser.Id);

            var userResource = _mapper.Map<User, UserResource>(user);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserResource>> UpdateUser(int id, [FromBody] SaveUserResource model)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var userToBeUpdated = await _userService.GetUserById(id);

            if (userToBeUpdated == null)
                return NotFound();

            var user = _mapper.Map<SaveUserResource, User>(model);

            await _userService.UpdateUser(userToBeUpdated, user);

            var updatedUser = await _userService.GetUserById(id);

            var updatedUserResource = _mapper.Map<User, UserResource>(updatedUser);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserById(id);

            await _userService.DeleteUser(user);

            return NoContent();
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

            return Ok(userResources);
        }
    }
}
