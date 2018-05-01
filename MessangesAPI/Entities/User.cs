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
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string SecondName { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(1)]
        public string UserType {get;set;} = "U";

        [Required]
        [MaxLength(150)]
        public string Email {get;set;}

        public virtual ICollection<Case> Cases { get; set; } = new List<Case>();
    }
}
