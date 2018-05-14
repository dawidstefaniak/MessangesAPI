using MessangesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Models
{
    public class UserListToReturnDto
    {
        public int userId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email {get;set;}
        public string UserType {get;set;}
    }
}

