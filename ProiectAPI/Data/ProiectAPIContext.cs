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
    }
}
