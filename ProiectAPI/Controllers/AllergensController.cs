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
    public class AllergensController : ControllerBase
    {
        private readonly ProiectAPIContext _context;

        public AllergensController(ProiectAPIContext context)
        {
            _context = context;
        }

        // GET: api/Allergens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Allergen>>> GetAllergen()
        {
          if (_context.Allergen == null)
          {
              return NotFound();
          }
            return await _context.Allergen.ToListAsync();
        }

        // GET: api/Allergens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Allergen>> GetAllergen(int id)
        {
          if (_context.Allergen == null)
          {
              return NotFound();
          }
            var allergen = await _context.Allergen.FindAsync(id);

            if (allergen == null)
            {
                return NotFound();
            }

            return allergen;
        }

        // PUT: api/Allergens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllergen(int id, Allergen allergen)
        {
            if (id != allergen.ID)
            {
                return BadRequest();
            }

            _context.Entry(allergen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllergenExists(id))
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

        // POST: api/Allergens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Allergen>> PostAllergen(Allergen allergen)
        {
          if (_context.Allergen == null)
          {
              return Problem("Entity set 'ProiectAPIContext.Allergen'  is null.");
          }
            _context.Allergen.Add(allergen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllergen", new { id = allergen.ID }, allergen);
        }

        // DELETE: api/Allergens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllergen(int id)
        {
            if (_context.Allergen == null)
            {
                return NotFound();
            }
            var allergen = await _context.Allergen.FindAsync(id);
            if (allergen == null)
            {
                return NotFound();
            }

            _context.Allergen.Remove(allergen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllergenExists(int id)
        {
            return (_context.Allergen?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
