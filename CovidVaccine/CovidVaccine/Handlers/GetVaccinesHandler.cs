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
    public class GetVaccinesHandler : IRequestHandler<GetVaccinesQuery, List<Vaccine>>
    {
        private readonly IRepository _repository;

        public GetVaccinesHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Vaccine>> Handle(GetVaccinesQuery request, CancellationToken cancellationToken)
        {
            var model = await _repository.SelectAll<Vaccine>();
            return model;
        }
    }
}
