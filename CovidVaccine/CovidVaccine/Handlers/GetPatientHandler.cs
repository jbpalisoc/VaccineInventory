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
    public class GetPatientHandler : IRequestHandler<GetPatientQuery, Patient>
    {
        private readonly IRepository _repository;

        public GetPatientHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient> Handle(GetPatientQuery request, CancellationToken cancellationToken)
        {
            var model = await _repository.SelectById<Patient>(request.Id);
            return model == null ? null : model;
        }
    }
}
