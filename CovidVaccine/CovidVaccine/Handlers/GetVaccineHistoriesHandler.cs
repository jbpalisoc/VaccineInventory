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
    public class GetVaccineHistoriesHandler : IRequestHandler<GetVaccineHistoriesQuery, List<VaccineHistory>>
    {
        private readonly IRepository _repository;

        public GetVaccineHistoriesHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<VaccineHistory>> Handle(GetVaccineHistoriesQuery request, CancellationToken cancellationToken)
        {
            var model = await _repository.SelectAll<VaccineHistory>();
            return model;
        }
    }
}
