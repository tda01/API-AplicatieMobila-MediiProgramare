using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectAPI.Models;

namespace ProiectAPI.Data
{
    public class ProiectAPIContext : DbContext
    {
        public ProiectAPIContext (DbContextOptions<ProiectAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectAPI.Models.ShopList> ShopList { get; set; } = default!;

        public DbSet<ProiectAPI.Models.Allergen>? Allergen { get; set; }

        public DbSet<ProiectAPI.Models.Category>? Category { get; set; }

        public DbSet<ProiectAPI.Models.Ingredient>? Ingredient { get; set; }

        public DbSet<ProiectAPI.Models.Product>? Product { get; set; }

        public DbSet<ProiectAPI.Models.ProductAllergen>? ProductAllergen { get; set; }

        public DbSet<ProiectAPI.Models.ProductIngredient>? ProductIngredient { get; set; }
    }
}
