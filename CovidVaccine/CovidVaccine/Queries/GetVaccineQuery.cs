using CovidVaccine.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine.Queries
{
    public class GetVaccineQuery : IRequest<Vaccine>
    {
        public int Id { get; }

        public GetVaccineQuery(int id)
        {
            Id = id;
        }
    }
}
