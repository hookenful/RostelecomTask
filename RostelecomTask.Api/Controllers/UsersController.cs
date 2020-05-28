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
        public async Task<ActionResult<UserResource>> GetUserById(long id)
        {
            var user = await _userService.GetUserById(id);

            var userResource = _mapper.Map<User, UserResource>(user);
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

            return Ok(userResource);


        }

    }
}
