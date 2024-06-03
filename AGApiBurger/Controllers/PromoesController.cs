using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AGApiBurger.Data;
using AmirGarcia_EjercicioCF.Models;

namespace AGApiBurger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoesController : ControllerBase
    {
        private readonly AGApiBurgerContext _context;

        public PromoesController(AGApiBurgerContext context)
        {
            _context = context;
        }

        // GET: api/Promoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promo>>> GetPromo()
        {
            return await _context.Promo.ToListAsync();
        }

        // GET: api/Promoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Promo>> GetPromo(int id)
        {
            var promo = await _context.Promo.FindAsync(id);

            if (promo == null)
            {
                return NotFound();
            }

            return promo;
        }

        // PUT: api/Promoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromo(int id, Promo promo)
        {
            if (id != promo.Id)
            {
                return BadRequest();
            }

            _context.Entry(promo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromoExists(id))
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

        // POST: api/Promoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Promo>> PostPromo(Promo promo)
        {
            _context.Promo.Add(promo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPromo", new { id = promo.Id }, promo);
        }

        // DELETE: api/Promoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePromo(int id)
        {
            var promo = await _context.Promo.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }

            _context.Promo.Remove(promo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PromoExists(int id)
        {
            return _context.Promo.Any(e => e.Id == id);
        }
    }
}
