using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Models
{
    public class CaseForCreationDto
    {
        public string RefNumber {get;set;}
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime ReportDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber{ get; set; }
        public string Email { get; set; }
        public string CaseStatus {get;set;}
        public int OfficerId{ get; set; }
        public int TypeOfCrimeId {get;set;}
    }
}
