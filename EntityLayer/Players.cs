using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Players
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        public string PlayerName { get; set; }
        [Required]
        public string PlayerNationality { get; set; }

        ICollection<Teams> Team { get; set; }  
    }
}
