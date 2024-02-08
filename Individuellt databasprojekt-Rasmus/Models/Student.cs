using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_databasprojekt_Rasmus.Models
{
    internal class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(13)]
        public string PersonNr { get; set; }
        [Required]
        [MaxLength(2)]
        public string Class { get; set; }
        public ICollection<Betyg> Students { get; set; }
    }
}
