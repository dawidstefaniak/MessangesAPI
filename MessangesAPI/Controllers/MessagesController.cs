using MessangesAPI.Models;
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
        public IActionResult sendMessage([FromBody] MessageForCreationDto message)
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
            if (!_messangerRepository.UserExists(message.SenderUserId) || !_messangerRepository.UserExists(message.ReceiverUserId))
            {
                return BadRequest();
            }
            AutoMapper.Mapper.Map<Entities.Message>(message);
            if (!_messangerRepository.Save())
            {
                return StatusCode(500, "Problem while handling your request.");
            }
            return Ok();
        }

        //Out of date (sender and receiver ID will be in JSON)
        /*  
        [HttpPost("add/{senderId}/{receiverId}")]
        public IActionResult AddMessage(int senderId, int receiverId, [FromBody] MessageForCreationDto message)
        {
            if (message == null)
            {
                return BadRequest();
            }

            if(senderId == receiverId)
            {
                ModelState.AddModelError("WrongId", "You cannot send message to yourself!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_messangerRepository.UserExists(senderId) || !_messangerRepository.UserExists(receiverId))
            {
                return NotFound();
            }

            //Message which is transformed from ForCreation object to Message object
            var finalMessage = AutoMapper.Mapper.Map<Entities.Message>(message);

            //Adding message to DB
            _messangerRepository.AddMessage(receiverId, senderId, finalMessage);

            //Saving changes
            if (!_messangerRepository.Save())
            {
                return StatusCode(500, "Problem while handling your request.");
            }
            //For now is useless
            var createdMessageToReturn = AutoMapper.Mapper.Map<Models.MessageDto>(finalMessage);

            return Ok();
        }
        */

        [HttpGet("getmessages/{userId}")]
        public IActionResult GetMessages(int userId)
        {
            if(!_messangerRepository.UserExists(userId))
            {
                return NotFound();
            }
            var messages = _messangerRepository.GetMessages(userId);
            if(messages == null)
            {
                return NotFound();
            }
            var MessagesToReturn = AutoMapper.Mapper.Map<IEnumerable<MessageDto>>(messages);
            return Ok(MessagesToReturn);
        }
    }
}
