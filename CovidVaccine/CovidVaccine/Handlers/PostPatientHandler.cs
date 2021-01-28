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
    public class PostPatientHandler : IRequestHandler<PostPatientCommand, Patient>
    {
        IRepository _repository;
        IUnitOfWork _unitOfWork;
        public PostPatientHandler(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
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

            _repository.CreateAsync<Patient>(patient);
            _unitOfWork.Commit();
            var model = patient != null ? await _repository.SelectById<Patient>(patient.Id) : null;
            return  model == null ? null : model;
            //return CreatedAtAction("GetPatient", new { id = request.Id }, request);
        }
    }
}
