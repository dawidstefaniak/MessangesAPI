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

        public Case Case {get;set;}

        public int CaseId {get;set;}
        
        [Required]
        public bool IsPoliceSender {get;set;}

        public string MessageText { get; set; }

        public DateTime SentDate { get; set; } = DateTime.Now;

    }
}
