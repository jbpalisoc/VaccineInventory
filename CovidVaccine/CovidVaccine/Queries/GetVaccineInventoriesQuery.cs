using CovidVaccine.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine.Queries
{
    public class GetVaccineInventoriesQuery :  IRequest<List<VaccineInventory>>
    {
    }
}
