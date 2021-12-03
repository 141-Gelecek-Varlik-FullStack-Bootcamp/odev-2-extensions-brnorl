using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ExtensionsWebApi.Database;
using ExtensionsWebApi.UserOperations;
using static ExtensionsWebApi.UserOperations.CreateUserCommand;
//Linq dökümantasyonu
//https://docs.microsoft.com/tr-tr/dotnet/csharp/linq/linq-in-csharp

namespace ExtensionsWebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]

    public class UserController : ControllerBase
    {
        private readonly UsersDbContext _context;

        public UserController(UsersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getUsers()
        {
            GetUsersCommand command = new GetUsersCommand(_context);
            var result = command.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsersDetailViewModel result;


            try
            {
                GetUsersDetailCommand command = new GetUsersDetailCommand(_context);

                command.UserId = id;
                result = command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new CreateUserCommand(_context);

            try
            {
                command.Model = newUser;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserModel updatedUser)
        {
            UpdateUserCommand command = new UpdateUserCommand(_context);

            try
            {
                command.Model = updatedUser;
                command.UserId = id;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                DeleteUserCommand command = new DeleteUserCommand(_context);
                command.userId = id;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }


    }
}