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
    public class DeleteVaccineHandler : IRequestHandler<DeleteVaccineCommand, Vaccine>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVaccineHandler(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Vaccine> Handle(DeleteVaccineCommand request, CancellationToken cancellationToken)
        {
            var vaccine = await _repository.SelectById<Vaccine>(request.Id);
            if (vaccine == null)
            {
                return null;
            }

            _repository.DeleteAsync<Vaccine>(vaccine);
            await _unitOfWork.Commit();

            return vaccine;
        }
    }
}
