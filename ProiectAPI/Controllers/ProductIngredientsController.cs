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
    public class ProductIngredientsController : ControllerBase
    {
        private readonly ProiectAPIContext _context;

        public ProductIngredientsController(ProiectAPIContext context)
        {
            _context = context;
        }

        // GET: api/ProductIngredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductIngredient>>> GetProductIngredient()
        {
          if (_context.ProductIngredient == null)
          {
              return NotFound();
          }
            return await _context.ProductIngredient.ToListAsync();
        }

        // GET: api/ProductIngredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductIngredient>> GetProductIngredient(int id)
        {
          if (_context.ProductIngredient == null)
          {
              return NotFound();
          }
            var productIngredient = await _context.ProductIngredient.FindAsync(id);

            if (productIngredient == null)
            {
                return NotFound();
            }

            return productIngredient;
        }

        // PUT: api/ProductIngredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductIngredient(int id, ProductIngredient productIngredient)
        {
            if (id != productIngredient.ID)
            {
                return BadRequest();
            }

            _context.Entry(productIngredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductIngredientExists(id))
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

        // POST: api/ProductIngredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductIngredient>> PostProductIngredient(ProductIngredient productIngredient)
        {
          if (_context.ProductIngredient == null)
          {
              return Problem("Entity set 'ProiectAPIContext.ProductIngredient'  is null.");
          }
            _context.ProductIngredient.Add(productIngredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductIngredient", new { id = productIngredient.ID }, productIngredient);
        }

        // DELETE: api/ProductIngredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductIngredient(int id)
        {
            if (_context.ProductIngredient == null)
            {
                return NotFound();
            }
            var productIngredient = await _context.ProductIngredient.FindAsync(id);
            if (productIngredient == null)
            {
                return NotFound();
            }

            _context.ProductIngredient.Remove(productIngredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductIngredientExists(int id)
        {
            return (_context.ProductIngredient?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
