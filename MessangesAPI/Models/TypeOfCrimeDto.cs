using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Models
{
    //TODO Use Authentication Tools instead of saving password as string
    public class TypeOfCrimeDto
    {
        public int TypeOfCrimeId{get;set;}
        
        public string CrimeDescription{get;set;}
    }
}
