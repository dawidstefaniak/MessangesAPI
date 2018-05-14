using MessangesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MessangesAPI.Models;

namespace MessangesAPI.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IMessangerRepository _messangerRepository;
        public UserController(IMessangerRepository messangerRepository)
        {
            _messangerRepository = messangerRepository;
        }

        //TODO
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserToLoginDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var UserFromClient = Mapper.Map<Entities.User>(user);

            if(_messangerRepository.UserWithUsernameAndPasswordExist(UserFromClient))
            {
                var usertoreturnenumerable = _messangerRepository.GetLoggedUser(UserFromClient);
                var UserToReturn = Mapper.Map<Models.LoggedUserToReturnDto>(usertoreturnenumerable);
                return Ok(UserToReturn);
            }
            return BadRequest();
        }
        
        [HttpGet("getUser/{userId}")]
        public IActionResult GetUserById(int userId)
        {

            if (!_messangerRepository.UserExists(userId))
            {
                return NotFound();
            }

            var userObject = _messangerRepository.GetUser(userId);
            var userToReturn = Mapper.Map<UserToReturnDto>(userObject);
            return Ok(userToReturn);
        }
        [HttpGet("getUserToEdit/{userId}")]
        public IActionResult GetUserToEditById(int userId)
        {
            if (!_messangerRepository.UserExists(userId))
            {
                return NotFound();
            }
            var userObject = _messangerRepository.GetUser(userId);
            var userToReturn = Mapper.Map<UserListToReturnDto>(userObject);
            return Ok(userToReturn);
        }
        [HttpGet("getListOfUsers")]
        public IActionResult GetListOfUsers()
        {
            var UserListToReturn = Mapper.Map<IEnumerable<Models.UserListToReturnDto>>(_messangerRepository.GetListOfUsers());
            return Ok(UserListToReturn);
        }
        [HttpPost("createUser")]
        public IActionResult CreateUser([FromBody] UserForCreationDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userToAdd = Mapper.Map<Entities.User>(user);

            //If AddUser method false, username exists
            if (!_messangerRepository.AddUser(userToAdd))
            {
                return BadRequest();
            }

            //If false, there were problem with saving to database
            if (!_messangerRepository.Save())
            {
                return StatusCode(500, "Server error");
            }

            return Ok();
        }
        [HttpPut("updateUser")]
        public IActionResult UpdateUser([FromBody] UserListToReturnDto userToEdit)
        {
            if(userToEdit == null)
            {
                return BadRequest();
            }
            if (!_messangerRepository.UserExists(userToEdit.userId))
            {
                return NotFound();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var UserFromDb = _messangerRepository.GetUser(userToEdit.userId);

            Mapper.Map(userToEdit,UserFromDb);
            _messangerRepository.UpdateUser(UserFromDb);

            if(!_messangerRepository.Save())
            {
                return StatusCode(500,"Problem while handling your request");
            }

            return Ok();
        }
    }
}
