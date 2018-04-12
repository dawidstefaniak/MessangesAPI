using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Entities
{
    public class Case
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaseId { get; set; }

        [Required]
        [MaxLength(50)]
        public string RefNumber {get;set;}

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string SecondName { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber{ get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public User Officer {get;set;}
        [Required]
        public int OfficerId{ get; set; }

        public TypeOfCrime TypeOfCrime {get;set;}
        [Required]
        public int TypeOfCrimeId {get;set;}

        public virtual ICollection<Message> Messages {get;set;} = new List<Message>();
    }
}
