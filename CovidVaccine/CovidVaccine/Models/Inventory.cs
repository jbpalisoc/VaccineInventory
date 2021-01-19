using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public DateTime RecieveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Quantity { get; set; }

        public int VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }
        public ICollection<VaccineHistory> VaccinesHistory { get; set; }


    }
}
