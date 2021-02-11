using CovidVaccine.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine.Commands
{
    public class UpdateCurrentStockCommand : IRequest<VaccineInventory>
    {
        public int Id { get; set; }
        public decimal Dosage { get; set; }
    }
}
