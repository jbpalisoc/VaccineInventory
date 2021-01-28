using CovidVaccine.Commands;
using CovidVaccine.Model;
using CovidVaccine.Repository;
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
        private readonly IUnitOfWork _unitOfWork;

        public DeletePatientHandler(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Patient> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _repository.SelectById<Patient>(request.Id);
            if (patient == null)
            {
                return null;
            }

            _repository.DeleteAsync<Patient>(patient);
            _unitOfWork.Commit();

            return patient;

        }
    }
}
