using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Entities
{
    //TODO Use Authentication Tools instead of saving password as string
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public virtual ICollection<Message> MessagesSent { get; set; } = new List<Message>();

        public virtual ICollection<Message> MessagesReceived { get; set; } = new List<Message>();
    }
}
