using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieMobila.Models
{
    public class Ingredient
    {
        public int ID { get; set; }

        [Display(Name = "Ingredient")]
        public string IngredientName { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Calories { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Unsaturated_Fats { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Saturated_Fats { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Sugars { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Fibers { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Proteins { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Minerals { get; set; }

        public ICollection<ProductIngredient>? ProductIngredients { get; set; }
    }
}
