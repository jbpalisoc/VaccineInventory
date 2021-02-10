using CovidVaccine.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine.Commands
{
    public class PostVaccineHistoryCommand : IRequest<VaccineHistory>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int InventoryId { get; set; }
        public decimal Dosage { get; set; }
        public DateTime DateVaccinated { get; set; }
    }
}
