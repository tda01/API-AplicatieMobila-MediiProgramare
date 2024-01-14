using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieMobila.Models
{
    public class ProductIngredient
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int IngredientID { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
