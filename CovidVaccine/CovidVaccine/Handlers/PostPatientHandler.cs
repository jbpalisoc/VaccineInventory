using CovidVaccine.Commands;
using CovidVaccine.Models;
using CovidVaccine.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CovidVaccine.Handlers
{
    public class PostPatientHandler : IRequestHandler<PostPatientCommand, Patient>
    {
        IRepository _repository;
        public PostPatientHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient> Handle(PostPatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = new Patient()
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Birthday = request.Birthday,
                ContactNo = request.ContactNo,
                Sex = request.Sex
            };

            await _repository.CreateAsync<Patient>(patient);
            var model = patient != null ? await _repository.SelectById<Patient>(patient.Id) : null;
            return  model == null ? null : model;
            //return CreatedAtAction("GetPatient", new { id = request.Id }, request);
        }
    }
}
