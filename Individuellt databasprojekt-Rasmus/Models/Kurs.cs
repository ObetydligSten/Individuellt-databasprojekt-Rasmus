using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_databasprojekt_Rasmus.Models
{
    internal class Kurs
    {
        [Key]
        public int KursId { get; set; }
        [Required]
        [MaxLength(50)]
        public string KursName { get; set; }
        [Required]
        public bool Active { get; set; }
        public ICollection<Betyg> Kurss { get; set; }

    }
}
