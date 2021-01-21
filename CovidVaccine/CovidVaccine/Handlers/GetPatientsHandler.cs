using CovidVaccine.Models;
using CovidVaccine.Queries;
using CovidVaccine.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CovidVaccine.Handlers
{
    public class GetPatientsHandler : IRequestHandler<GetPatientsQuery, List<Patient>>
    {
        private readonly IRepository _repository;
        public GetPatientsHandler(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Patient>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            var model = await _repository.SelectAll<Patient>();
            return model;
        }
    }
}
