using MessangesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Models
{
    public class UserToLoginDto
    {
        public string UserName { get; set; }
        public string Password {get;set;}
    }
}

