using CovidVaccine.Model;
using MediatR;
using System.Collections.Generic;

namespace CovidVaccine.Queries
{ 
    public class GetVaccinesQuery : IRequest<List<Vaccine>>
    {
    }
}