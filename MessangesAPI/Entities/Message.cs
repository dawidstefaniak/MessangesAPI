using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Entities
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }

        public User Sender { get; set; }
        public int SenderUserId { get; set; }

        public User Receiver { get; set; }
        public int ReceiverUserId { get; set; }

        [MaxLength(500)]
        public string MessageText { get; set; }

        public DateTime SentDate { get; set; } = DateTime.Now;

    }
}
