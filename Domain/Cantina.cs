using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Cantina
    {
        public int Id { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public bool ServesWarm { get; set; }
    }
}
