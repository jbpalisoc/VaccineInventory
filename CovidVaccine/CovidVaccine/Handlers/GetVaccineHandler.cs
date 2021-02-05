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
    public class GetVaccineHandler : IRequestHandler<GetVaccineQuery, Vaccine>
    {
        private readonly IRepository _repository;

        public GetVaccineHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Vaccine> Handle(GetVaccineQuery request, CancellationToken cancellationToken)
        {
            var model = await _repository.SelectById<Vaccine>(request.Id);
            return model == null ? null : model;
        }
    }
}
