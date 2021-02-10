using System;
using System.Collections.Generic;
using System.Text;

namespace VaccineInventory.Models
{
    public class History
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string FullName { get { return Patient.FirstName +" "+Patient.LastName; } }
        public int InventoryId { get; set; }
        public decimal Dosage { get; set; }
        public DateTime DateVaccinated { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}
