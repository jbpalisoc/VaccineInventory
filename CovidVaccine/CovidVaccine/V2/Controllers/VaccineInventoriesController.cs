using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CovidVaccine.Model;
using CovidVaccine.Repository;
using MediatR;
using CovidVaccine.Queries;
using CovidVaccine.Commands;

namespace CovidVaccine.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class VaccineInventoriesController : ControllerBase
    {
        private readonly CovidVaccineContext _context;
        private readonly IMediator _mediator;

        public VaccineInventoriesController(CovidVaccineContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/VaccineInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccineInventory>>> GetVaccineInventories()
        {
            var query = new GetVaccineInventoriesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
            //return await _context.VaccineInventories.ToListAsync();
        }

        // GET: api/VaccineInventories/GetAllInventoryJoinVaccine
        [HttpGet("GetAllInventoryJoinVaccine")]
        public async Task<ActionResult<IEnumerable<VaccineInventory>>> GetAllInventoryJoinVaccine()
        {
            var query = new GetAllInventoryJoinVaccineQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
            //return await _context.VaccineInventories.ToListAsync();
        }

        // GET: api/VaccineInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VaccineInventory>> GetVaccineInventory(int id)
        {
            var vaccineInventory = await _context.VaccineInventories.FindAsync(id);

            if (vaccineInventory == null)
            {
                return NotFound();
            }

            return vaccineInventory;
        }

        // PUT: api/VaccineInventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccineInventory(int id, VaccineInventory vaccineInventory)
        {
            if (id != vaccineInventory.Id)
            {
                return BadRequest();
            }

            _context.Entry(vaccineInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccineInventoryExists(id))
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

        [HttpPut("UpdateCurrentStock/{id}")]
        public async Task<IActionResult> UpdateCurrentStock(int id, UpdateCurrentStockCommand command)
        {

            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return result != null ? (ActionResult)Ok(result) : NotFound();

        }

        // POST: api/VaccineInventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VaccineInventory>> PostVaccineInventory(PostVaccineInventoryCommand command)
        {
            var result = await _mediator.Send(command);

            return result != null ? (ActionResult)Ok(result) : NotFound();
        }

        // DELETE: api/VaccineInventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccineInventory(int id)
        {
            var vaccineInventory = await _context.VaccineInventories.FindAsync(id);
            if (vaccineInventory == null)
            {
                return NotFound();
            }

            _context.VaccineInventories.Remove(vaccineInventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaccineInventoryExists(int id)
        {
            return _context.VaccineInventories.Any(e => e.Id == id);
        }
    }
}
