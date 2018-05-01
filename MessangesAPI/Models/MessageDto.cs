using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Models
{
    public class MessageDto
    {
        public int MessageId { get; set; }

        public int CaseId {get;set;}

        public bool IsPoliceSender {get;set;}

        public string MessageText { get; set; }

        public DateTime SentDate { get; set; }
    }
}
