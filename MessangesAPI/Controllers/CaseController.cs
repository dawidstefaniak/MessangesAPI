using MessangesAPI.Entities;
using MessangesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using MessangesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Controllers
{
    [Route("api/case")]
    public class CaseController : Controller
    {
        private readonly IMessangerRepository _messangerRepository;

        public CaseController(IMessangerRepository messangerRepository)
        {
            _messangerRepository = messangerRepository;
        }

        //TODO instead of writing typeofcrimeid, send typeofcrimetext
        [HttpGet("getListOfCasesForUser/{userId}")]
        public IActionResult GetListOfCasesForUser(int userId)
        {
            if(!_messangerRepository.UserExists(userId))
            {
                return BadRequest();
            }
            
            var cases = _messangerRepository.GetCasesForUser(userId);
            var casestoreturn = AutoMapper.Mapper.Map<IEnumerable<CaseToReturnDto>>(cases);
            return Ok(casestoreturn);    
        }

        [HttpPost("CreateCase")]
        public IActionResult CreateCase([FromBody] CaseForCreationDto caseforcreation)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(!_messangerRepository.UserExists(caseforcreation.OfficerId))
            {
                return BadRequest();
            }

            var casetoadd = AutoMapper.Mapper.Map<Entities.Case>(caseforcreation);
            _messangerRepository.AddCase(casetoadd);

            if(!_messangerRepository.Save())
            {
                return BadRequest();
            }
            return Ok();

        }
    }
}
