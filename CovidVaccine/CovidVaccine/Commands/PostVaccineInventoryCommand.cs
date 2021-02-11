using CovidVaccine.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine.Commands
{
    public class PostVaccineInventoryCommand : IRequest<VaccineInventory>
    {
        public int Id { get; set; }
        public int VaccineId { get; set; }
        public decimal StartingStock { get; set; }
        public DateTime StorageDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
