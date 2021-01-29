using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CovidVaccine.Queries;
using MediatR;
using CovidVaccine.Commands;
using CovidVaccine.Repository;
using CovidVaccine.Model;

namespace CovidVaccine.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        //private readonly IRepository _repository;
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            //_unitOfWork = unitOfWork;
            //_repository = repository;
            _mediator = mediator;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var query = new GetPatientsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
            
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var query = new GetPatientQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (ActionResult) Ok(result) : NotFound();

        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, PutPatientCommand command)
        {
            
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            return result != null ? (ActionResult)Ok(result) : NotFound();

            /*
            await _repository.UpdateAsync<Patient>(patient);

            return NoContent();*/
        }

        // POST: api/Patients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(PostPatientCommand command)
        {
            var result = await _mediator.Send(command);

            return result != null ? (ActionResult)Ok(result) : NotFound();

            //await _repository.CreateAsync<Patient>(patient);
            //return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            var query = new DeletePatientCommand(id);
            var result = await _mediator.Send(query);

            return result != null ? (ActionResult)Ok(result) : NotFound();

            //var model = await _repository.SelectById<Patient>(id);

            //if (model == null)
            //{
            //    return NotFound();
            //}

            //await _repository.DeleteAsync<Patient>(model);

            //return model;
        }

        /*private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }*/
    }
}
