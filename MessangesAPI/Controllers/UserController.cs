﻿using MessangesAPI.Services;
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

        [HttpGet("getUser/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            //if (userId == null)
            //{
            //    return NotFound();
            //}

            if (!_messangerRepository.UserExists(userId))
            {
                return NotFound();
            }

            var userObject = _messangerRepository.GetUser(userId);
            var userToReturn = Mapper.Map<UserToReturnDto>(userObject);
            return Ok(userToReturn);
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
    }
}