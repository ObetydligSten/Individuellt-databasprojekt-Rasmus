using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_databasprojekt_Rasmus.Models
{
    internal class Betyg
    {
        [Required]
        public int Grade { get; set; }
        [Required]
        public DateOnly GradeSet { get; set; }
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [Required]
        public int PersonalId { get; set; }
        public Personal Personal { get; set; }
        [Required]
        public int KursId { get; set; }
        public Kurs Kurs { get; set; }
    }
}
