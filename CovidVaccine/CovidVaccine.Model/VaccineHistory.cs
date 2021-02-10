using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine.Model
{
    public class VaccineHistory
    {
        public VaccineHistory(int id, int patientId, int inventoryId, decimal dosage, DateTime dateVaccinated)
        {
            Id = id;
            PatientId = patientId;
            InventoryId = inventoryId;
            Dosage = dosage;
            DateVaccinated = dateVaccinated;
        }

        public int Id { get; private set; }
        public int PatientId { get; private set; }
        public int InventoryId { get; private set; }
        public decimal Dosage { get; private set; }
        public DateTime DateVaccinated { get; private set; }
        public virtual Patient Patient { get; set; }
        public virtual VaccineInventory Inventory { get; set; }
    }
}
