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
    public class PostVaccineHandler : IRequestHandler<PostVaccineCommand, Vaccine>
    {
        IRepository _repository;
        IUnitOfWork _unitOfWork;

        public PostVaccineHandler(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Vaccine> Handle(PostVaccineCommand request, CancellationToken cancellationToken)
        {
            Vaccine vaccine = new Vaccine(
                request.Id,
                request.Name,
                request.Description
                );

            _repository.CreateAsync<Vaccine>(vaccine);
            await _unitOfWork.Commit();
            var model = vaccine != null ? await _repository.SelectById<Vaccine>(vaccine.Id) : null;
            return model == null ? null : model;
        }
    }
}
