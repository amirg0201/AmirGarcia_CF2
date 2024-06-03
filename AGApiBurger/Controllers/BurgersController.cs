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
    public class BurgersController : ControllerBase
    {
        private readonly AGApiBurgerContext _context;

        public BurgersController(AGApiBurgerContext context)
        {
            _context = context;
        }

        // GET: api/Burgers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Burger>>> GetBurger()
        {
            return await _context.Burger.ToListAsync();
        }

        // GET: api/Burgers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Burger>> GetBurger(int id)
        {
            var burger = await _context.Burger.FindAsync(id);

            if (burger == null)
            {
                return NotFound();
            }

            return burger;
        }

        // PUT: api/Burgers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBurger(int id, Burger burger)
        {
            if (id != burger.Burgerid)
            {
                return BadRequest();
            }

            _context.Entry(burger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BurgerExists(id))
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

        // POST: api/Burgers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Burger>> PostBurger(Burger burger)
        {
            _context.Burger.Add(burger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBurger", new { id = burger.Burgerid }, burger);
        }

        // DELETE: api/Burgers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBurger(int id)
        {
            var burger = await _context.Burger.FindAsync(id);
            if (burger == null)
            {
                return NotFound();
            }

            _context.Burger.Remove(burger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BurgerExists(int id)
        {
            return _context.Burger.Any(e => e.Burgerid == id);
        }
    }
}
