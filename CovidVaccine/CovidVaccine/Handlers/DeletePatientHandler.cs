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
    public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, Patient>
    {
        private readonly IRepository _repository;

        public DeletePatientHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _repository.SelectById<Patient>(request.Id);
            if (patient == null)
            {
                return null;
            }

            await _repository.DeleteAsync<Patient>(patient);

            return patient;

        }
    }
}
