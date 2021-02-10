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
    public class GetAllHistoryJoinPatientJoinInventoryHandler : IRequestHandler<GetAllHistoryJoinPatientJoinInventoryQuery, IEnumerable<VaccineHistory>>
    {
        private readonly IHistoryRepository _historyRepository;
        public GetAllHistoryJoinPatientJoinInventoryHandler(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }
        public async Task<IEnumerable<VaccineHistory>> Handle(GetAllHistoryJoinPatientJoinInventoryQuery request, CancellationToken cancellationToken)
        {
            var model = await _historyRepository.GetAllHistoryJoinPatientJoinInventory();
            return model;
        }
    }
}
