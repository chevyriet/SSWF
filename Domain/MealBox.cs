﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MealBox
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naam is verplicht")]
        public string Name { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public DateTime? PickupFromTime { get; set; }

        [Required(ErrorMessage = "OphaalDatumTijd is verplicht")]
        public DateTime? PickupUntilTime { get; set; }

        [Required]
        public bool IsEighteen { get; set; }

        [Required(ErrorMessage = "Prijs is verplicht")]
        public double Price { get; set; }

        [Required]
        public MealType Type { get; set; }

        [Required]
        public bool IsWarm { get; set; }

        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        public Cantina Cantina { get; set; } = null!;

        public ICollection<Product>? Products { get; set; }
    }
}
