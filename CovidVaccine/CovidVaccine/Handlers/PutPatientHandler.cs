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
    public class PutPatientHandler : IRequestHandler<PutPatientCommand, Patient>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public PutPatientHandler(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Patient> Handle(PutPatientCommand request, CancellationToken cancellationToken)
        {
            var model = await _repository.SelectById<Patient>(request.Id);

            if(model == null)
            {
                return null;
            }
            else
            {
                model.UpdatePatient(request.Id,
                request.FirstName,
                request.MiddleName,
                request.LastName,
                request.ContactNo,
                request.Birthday,
                request.Sex);



                _repository.UpdateAsync<Patient>(model);
                _unitOfWork.Commit();
                return model;

            }

            //var model = patient != null ? await _repository.SelectById<Patient>(request.Id) : null;
            
            
            //return model == null ? null : model;
        }
    }
}
