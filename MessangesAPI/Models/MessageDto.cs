using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Models
{
    public class MessageDto
    {
        public int MessageId { get; set; }
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public DateTime SentDate { get; set; }
        public string MessageText { get; set; }
    }
}
