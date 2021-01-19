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
    public class InventoriesController : ControllerBase
    {
        private readonly VaccineContext _context;

        public InventoriesController(VaccineContext context)
        {
            _context = context;
        }

        // GET: api/Inventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventoryEntries()
        {
            return await _context.InventoryEntries.ToListAsync();
        }

        // GET: api/Inventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(int id)
        {
            var inventory = await _context.InventoryEntries.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        // PUT: api/Inventories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(int id, Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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

        // POST: api/Inventories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        {
            _context.InventoryEntries.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventory", new { id = inventory.Id }, inventory);
        }

        // DELETE: api/Inventories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inventory>> DeleteInventory(int id)
        {
            var inventory = await _context.InventoryEntries.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.InventoryEntries.Remove(inventory);
            await _context.SaveChangesAsync();

            return inventory;
        }

        private bool InventoryExists(int id)
        {
            return _context.InventoryEntries.Any(e => e.Id == id);
        }
    }
}
