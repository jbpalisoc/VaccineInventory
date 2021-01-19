using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CovidVaccine.Models;

namespace CovidVaccine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinesController : ControllerBase
    {
        private readonly VaccineContext _context;

        public VaccinesController(VaccineContext context)
        {
            _context = context;
        }

        // GET: api/Vaccines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaccine>>> GetVaccines()
        {
            return await _context.Vaccines.ToListAsync();
        }

        // GET: api/Vaccines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaccine>> GetVaccine(int id)
        {
            var vaccine = await _context.Vaccines.FindAsync(id);

            if (vaccine == null)
            {
                return NotFound();
            }

            return vaccine;
        }

        // PUT: api/Vaccines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccine(int id, Vaccine vaccine)
        {
            if (id != vaccine.Id)
            {
                return BadRequest();
            }

            _context.Entry(vaccine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccineExists(id))
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

        // POST: api/Vaccines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vaccine>> PostVaccine(Vaccine vaccine)
        {
            _context.Vaccines.Add(vaccine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaccine", new { id = vaccine.Id }, vaccine);
        }

        // DELETE: api/Vaccines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vaccine>> DeleteVaccine(int id)
        {
            var vaccine = await _context.Vaccines.FindAsync(id);
            if (vaccine == null)
            {
                return NotFound();
            }

            _context.Vaccines.Remove(vaccine);
            await _context.SaveChangesAsync();

            return vaccine;
        }

        private bool VaccineExists(int id)
        {
            return _context.Vaccines.Any(e => e.Id == id);
        }
    }
}
