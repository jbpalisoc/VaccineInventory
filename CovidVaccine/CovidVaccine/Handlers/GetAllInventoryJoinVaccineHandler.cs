using CovidVaccine.Model;
using CovidVaccine.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CovidVaccine.Handlers
{
    public class GetAllInventoryJoinVaccineHandler : IRequestHandler<GetAllInventoryJoinVaccineQuery, IEnumerable<VaccineInventory>>
    {
        private readonly IInventoryRepository _inventoryRepository;
        public GetAllInventoryJoinVaccineHandler(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task<IEnumerable<VaccineInventory>> Handle(GetAllInventoryJoinVaccineQuery request, CancellationToken cancellationToken)
        {
            var model = await _inventoryRepository.GetAllInventoryJoinVaccine();
            return model;
        }
    }
}
