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
    public class VaccineHistoriesController : ControllerBase
    {
        private readonly VaccineContext _context;

        public VaccineHistoriesController(VaccineContext context)
        {
            _context = context;
        }

        // GET: api/VaccineHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccineHistory>>> GetVaccineHistoryEntries()
        {
            return await _context.VaccineHistoryEntries.ToListAsync();
        }

        // GET: api/VaccineHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VaccineHistory>> GetVaccineHistory(int id)
        {
            var vaccineHistory = await _context.VaccineHistoryEntries.FindAsync(id);

            if (vaccineHistory == null)
            {
                return NotFound();
            }

            return vaccineHistory;
        }

        // PUT: api/VaccineHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccineHistory(int id, VaccineHistory vaccineHistory)
        {
            if (id != vaccineHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(vaccineHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccineHistoryExists(id))
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

        // POST: api/VaccineHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VaccineHistory>> PostVaccineHistory(VaccineHistory vaccineHistory)
        {
            _context.VaccineHistoryEntries.Add(vaccineHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaccineHistory", new { id = vaccineHistory.Id }, vaccineHistory);
        }

        // DELETE: api/VaccineHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VaccineHistory>> DeleteVaccineHistory(int id)
        {
            var vaccineHistory = await _context.VaccineHistoryEntries.FindAsync(id);
            if (vaccineHistory == null)
            {
                return NotFound();
            }

            _context.VaccineHistoryEntries.Remove(vaccineHistory);
            await _context.SaveChangesAsync();

            return vaccineHistory;
        }

        private bool VaccineHistoryExists(int id)
        {
            return _context.VaccineHistoryEntries.Any(e => e.Id == id);
        }
    }
}
