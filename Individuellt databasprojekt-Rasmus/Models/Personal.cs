using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_databasprojekt_Rasmus.Models
{
    internal class Personal
    {
        [Key]
        public int PersonalId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Befattning { get; set; }
        [Required]
        public int YearsService { get; set; }
        [Required]
        public int Salary { get; set; }
        public ICollection<Betyg> Personals { get; set; }


    }
}
