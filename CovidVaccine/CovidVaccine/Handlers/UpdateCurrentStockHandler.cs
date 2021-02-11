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
    public class UpdateCurrentStockHandler : IRequestHandler<UpdateCurrentStockCommand, VaccineInventory>
    {
        private readonly IRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCurrentStockHandler(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VaccineInventory> Handle(UpdateCurrentStockCommand request, CancellationToken cancellationToken)
        {
            var model = await _repository.SelectById<VaccineInventory>(request.Id);

            if (model == null)
            {
                return null;
            }
            else
            {
                decimal currentStock = model.CurrentStock - request.Dosage;

                model.UpdateCurrentStock(
                    request.Id,
                    currentStock
                );

                _repository.UpdateAsync<VaccineInventory>(model);
                await _unitOfWork.Commit();
                return model;

            }
        }
    }
}
