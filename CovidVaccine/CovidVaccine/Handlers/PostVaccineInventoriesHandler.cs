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
    public class PostVaccineInventoriesHandler : IRequestHandler<PostVaccineInventoryCommand, VaccineInventory>
    {
        IRepository _repository;
        IUnitOfWork _unitOfWork;

        public PostVaccineInventoriesHandler(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<VaccineInventory> Handle(PostVaccineInventoryCommand request, CancellationToken cancellationToken)
        {
            VaccineInventory vaccineInventory = new VaccineInventory(
               request.Id,
               request.VaccineId,
               request.Amount,
               request.StorageDate,
               request.ExpirationDate
               );

            _repository.CreateAsync<VaccineInventory>(vaccineInventory);
            await _unitOfWork.Commit();
            var model = vaccineInventory != null ? await _repository.SelectById<VaccineInventory>(vaccineInventory.Id) : null;
            return model == null ? null : model;
        }
    }
}
