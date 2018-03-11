using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Models
{
    public class MessageDto
    {
        public int id { get; set; }
        public int senderId { get; set; }
        public int receiverId { get; set; }
        public string message { get; set; }
    }
}
