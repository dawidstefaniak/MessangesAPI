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
    }
}
