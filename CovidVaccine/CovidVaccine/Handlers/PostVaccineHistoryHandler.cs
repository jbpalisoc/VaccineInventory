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
    public class PostVaccineHistoryHandler : IRequestHandler<PostVaccineHistoryCommand, VaccineHistory>
    {
        IRepository _repository;
        IUnitOfWork _unitOfWork;

        public PostVaccineHistoryHandler(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VaccineHistory> Handle(PostVaccineHistoryCommand request, CancellationToken cancellationToken)
        {
            VaccineHistory vaccineHistory = new VaccineHistory(
                request.Id,
                request.PatientId,
                request.InventoryId,
                request.Dosage,
                request.DateVaccinated
                );

            _repository.CreateAsync<VaccineHistory>(vaccineHistory);
            await _unitOfWork.Commit();
            var model = vaccineHistory != null ? await _repository.SelectById<VaccineHistory>(vaccineHistory.Id) : null;
            return model == null ? null : model;
        }
    }
}
