using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectAPI.Data;
using ProiectAPI.Models;

namespace ProiectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAllergensController : ControllerBase
    {
        private readonly ProiectAPIContext _context;

        public ProductAllergensController(ProiectAPIContext context)
        {
            _context = context;
        }

        // GET: api/ProductAllergens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductAllergen>>> GetProductAllergen()
        {
          if (_context.ProductAllergen == null)
          {
              return NotFound();
          }
            return await _context.ProductAllergen.ToListAsync();
        }

        // GET: api/ProductAllergens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductAllergen>> GetProductAllergen(int id)
        {
          if (_context.ProductAllergen == null)
          {
              return NotFound();
          }
            var productAllergen = await _context.ProductAllergen.FindAsync(id);

            if (productAllergen == null)
            {
                return NotFound();
            }

            return productAllergen;
        }

        // PUT: api/ProductAllergens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductAllergen(int id, ProductAllergen productAllergen)
        {
            if (id != productAllergen.ID)
            {
                return BadRequest();
            }

            _context.Entry(productAllergen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductAllergenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductAllergens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductAllergen>> PostProductAllergen(ProductAllergen productAllergen)
        {
          if (_context.ProductAllergen == null)
          {
              return Problem("Entity set 'ProiectAPIContext.ProductAllergen'  is null.");
          }
            _context.ProductAllergen.Add(productAllergen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductAllergen", new { id = productAllergen.ID }, productAllergen);
        }

        // DELETE: api/ProductAllergens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAllergen(int id)
        {
            if (_context.ProductAllergen == null)
            {
                return NotFound();
            }
            var productAllergen = await _context.ProductAllergen.FindAsync(id);
            if (productAllergen == null)
            {
                return NotFound();
            }

            _context.ProductAllergen.Remove(productAllergen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductAllergenExists(int id)
        {
            return (_context.ProductAllergen?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
