using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class MealBoxProduct
    {
        [Key]
        public int Id { get; set; }

        public int MealBoxId { get; set; }

        public MealBox? MealBox { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
