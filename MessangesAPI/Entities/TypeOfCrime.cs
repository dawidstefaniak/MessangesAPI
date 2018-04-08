using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MessangesAPI.Entities
{
    //TODO Use Authentication Tools instead of saving password as string
    public class TypeOfCrime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeOfCrimeId{get;set;}
        
        [Required]
        [MaxLength(50)]
        public string CrimeDescription{get;set;}

        public virtual ICollection<Case> Cases { get; set; } = new List<Case>();
    }
}
