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
    public class PutVaccineHandler : IRequestHandler<PutVaccineCommand, Vaccine>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PutVaccineHandler(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Vaccine> Handle(PutVaccineCommand request, CancellationToken cancellationToken)
        {
            var model = await _repository.SelectById<Vaccine>(request.Id);

            if (model == null)
            {
                return null;
            }
            else
            {
                model.UpdateVaccine(request.Id,
                request.Name,
                request.Description
                );



                _repository.UpdateAsync<Vaccine>(model);
                await _unitOfWork.Commit();
                return model;

            }
        }
    }
}
