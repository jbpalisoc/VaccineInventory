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
    public class VaccineHistoriesController : ControllerBase
    {
        private readonly CovidVaccineContext _context;
        private readonly IMediator _mediator;

        public VaccineHistoriesController(CovidVaccineContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/VaccineHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccineHistory>>> GetVaccineHistories()
        {
            var query = new GetVaccineHistoriesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        // GET: api/VaccineHistories/GetAllHistoryJoinPatientJoinInventory
        [HttpGet("GetAllHistoryJoinPatientJoinInventory")]
        public async Task<ActionResult<IEnumerable<VaccineHistory>>> GetAllHistoryJoinPatientJoinInventory()
        {
            var query = new GetAllHistoryJoinPatientJoinInventoryQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/VaccineHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VaccineHistory>> GetVaccineHistory(int id)
        {
            var vaccineHistory = await _context.VaccineHistories.FindAsync(id);

            if (vaccineHistory == null)
            {
                return NotFound();
            }

            return vaccineHistory;
        }

        // PUT: api/VaccineHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VaccineHistory>> PostVaccineHistory(PostVaccineHistoryCommand command)
        {
            var result = await _mediator.Send(command);

            return result != null ? (ActionResult)Ok(result) : NotFound();
        }

        // DELETE: api/VaccineHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccineHistory(int id)
        {
            var vaccineHistory = await _context.VaccineHistories.FindAsync(id);
            if (vaccineHistory == null)
            {
                return NotFound();
            }

            _context.VaccineHistories.Remove(vaccineHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaccineHistoryExists(int id)
        {
            return _context.VaccineHistories.Any(e => e.Id == id);
        }
    }
}
