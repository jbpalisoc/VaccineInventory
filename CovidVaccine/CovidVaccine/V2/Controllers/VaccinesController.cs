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
    public class VaccinesController : ControllerBase
    {
        //private readonly CovidVaccineContext _context;
        private readonly IMediator _mediator;
        public VaccinesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Vaccines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaccine>>> GetVaccines()
        {
            var query = new GetVaccinesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Vaccines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vaccine>> GetVaccine(int id)
        {
            var query = new GetVaccineQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (ActionResult)Ok(result) : NotFound();
        }

        // PUT: api/Vaccines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccine(int id, PutVaccineCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return result != null ? (ActionResult)Ok(result) : NotFound();
        }

        // POST: api/Vaccines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vaccine>> PostVaccine(PostVaccineCommand command)
        {
            var result = await _mediator.Send(command);

            return result != null ? (ActionResult)Ok(result) : NotFound();
        }

        // DELETE: api/Vaccines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccine(int id)
        {
            var query = new DeleteVaccineCommand(id);
            var result = await _mediator.Send(query);

            return result != null ? (ActionResult)Ok(result) : NotFound();
        }

        /*private bool VaccineExists(int id)
        {
            return _context.Vaccines.Any(e => e.Id == id);
        }*/
    }
}
