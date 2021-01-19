using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine.Models
{
    public class VaccineHistory
    {
        public int Id { get; set; }
        public DateTime VAccinationDate { get; set; }

        public int PatientId { get; set; }
        public int InventoryId { get; set; }


        public Patient Patient { get; set; }
        public Inventory Inventory { get; set; }
    }
}
