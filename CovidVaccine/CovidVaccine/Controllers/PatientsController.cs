using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CovidVaccine.Models;
using CovidVaccine.Repositories;

namespace CovidVaccine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IRepository _repository;

        public PatientsController(VaccineContext context, IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var model = await _repository.SelectAll<Patient>();
            return model;
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var model = await _repository.SelectById<Patient>(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync<Patient>(patient);

            return NoContent();
        }

        // POST: api/Patients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            await _repository.CreateAsync<Patient>(patient);
            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            var model = await _repository.SelectById<Patient>(id);

            if (model == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<Patient>(model);

            return model;
        }

        /*private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }*/
    }
}
