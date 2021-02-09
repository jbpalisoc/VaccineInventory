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
    public class GetVaccineInventoriesHandler : IRequestHandler<GetVaccineInventoriesQuery, List<VaccineInventory>>
    {
        private readonly IRepository _repository;

        public GetVaccineInventoriesHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VaccineInventory>> Handle(GetVaccineInventoriesQuery request, CancellationToken cancellationToken)
        {
            var model = await _repository.SelectAll<VaccineInventory>();
            return model;
        }
    }
}
