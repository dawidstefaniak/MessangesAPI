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
    [Route("api/typeofcrime")]
    public class TypeOfCrimeController : Controller
    {
        private readonly IMessangerRepository _messangerRepository;

        public TypeOfCrimeController(IMessangerRepository messangerRepository)
        {
            _messangerRepository = messangerRepository;
        }

        [HttpGet("gettypeofcrime/{typeOfCrimeId}")]
        public IActionResult GetTypeOfCrime(int typeOfCrimeId)
        {
            if(!_messangerRepository.TypeOfCrimeExists(typeOfCrimeId))
            {
                return BadRequest();
            }
            var typeofcrime = _messangerRepository.GetTypeOfCrime(typeOfCrimeId);
            var typeofcrimetoreturn = AutoMapper.Mapper.Map<Models.TypeOfCrimeToReturnDto>(typeofcrime);

            return Ok(typeofcrimetoreturn);
        }
        [HttpPost("addtypeofcrime")]
        public IActionResult AddTypeOfCrime([FromBody] TypeOfCrimeForCreationDto typeofcrime)
        {
            if(typeofcrime == null)
            {
                return BadRequest();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var typeofcrimetoadd = AutoMapper.Mapper.Map<Entities.TypeOfCrime>(typeofcrime);
            _messangerRepository.AddTypeOfCrime(typeofcrimetoadd);
            if(!_messangerRepository.Save())
            {
                return StatusCode(500);
            }
            return Ok();
        }


    }
}
