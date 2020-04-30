using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloLinuxAPI.Models;

namespace HelloLinuxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingsController : ControllerBase
    {
        private readonly HelloLinuxDbContext _context;

        public GreetingsController(HelloLinuxDbContext context)
        {
            _context = context;
        }

        // GET: api/Greetings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Greetings>>> GetGreetings()
        {
            return await _context.Greetings.ToListAsync();
        }

        // GET: api/Greetings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Greetings>> GetGreetings(int id)
        {
            var greetings = await _context.Greetings.FindAsync(id);

            if (greetings == null)
            {
                return NotFound();
            }

            return greetings;
        }

        // PUT: api/Greetings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGreetings(int id, Greetings greetings)
        {
            if (id != greetings.Id)
            {
                return BadRequest();
            }

            _context.Entry(greetings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GreetingsExists(id))
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

        // POST: api/Greetings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Greetings>> PostGreetings(Greetings greetings)
        {
            _context.Greetings.Add(greetings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGreetings", new { id = greetings.Id }, greetings);
        }

        // DELETE: api/Greetings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Greetings>> DeleteGreetings(int id)
        {
            var greetings = await _context.Greetings.FindAsync(id);
            if (greetings == null)
            {
                return NotFound();
            }

            _context.Greetings.Remove(greetings);
            await _context.SaveChangesAsync();

            return greetings;
        }

        private bool GreetingsExists(int id)
        {
            return _context.Greetings.Any(e => e.Id == id);
        }
    }
}
