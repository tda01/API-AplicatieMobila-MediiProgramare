using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieMobila.Models
{
    public class Allergen
    {
        public int ID { get; set; }

        [Display(Name = "Allergen")]
        public string AllergenName { get; set; }

        public ICollection<ProductAllergen>? ProductAllergens { get; set; }
    }
}
