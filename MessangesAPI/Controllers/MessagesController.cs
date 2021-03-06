﻿using MessangesAPI.Models;
using MessangesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Controllers
{
    [Route("api/message")]
    public class MessagesController : Controller
    {
        private readonly IMessangerRepository _messangerRepository;

        public MessagesController(IMessangerRepository messangerRepository)
        {
            _messangerRepository = messangerRepository;
        }

        [HttpPost("sendMessage")]
        public IActionResult SendMessage([FromBody] MessageForCreationDto message)
        {
            if(message == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_messangerRepository.CaseExists(message.CaseId))
            {
                return BadRequest();
            }
            var messagetoadd = AutoMapper.Mapper.Map<Entities.Message>(message);
            _messangerRepository.AddMessage(messagetoadd);
            if (!_messangerRepository.Save())
            {
                return StatusCode(500, "Problem while handling your request.");
            }
            return Ok();
        }

        [HttpGet("getmessagesforcase/{caseId}")]
        public IActionResult GetMessagesForCase(int caseId)
        {
            if (!_messangerRepository.CaseExists(caseId))
            {
                return BadRequest();
            }

            var MessagesFromRepo = _messangerRepository.GetMessagesForCase(caseId);
            var MessagesToReturn = AutoMapper.Mapper.Map<IEnumerable<MessageDto>>(MessagesFromRepo);

            return Ok(MessagesToReturn);
        }
    }
}
