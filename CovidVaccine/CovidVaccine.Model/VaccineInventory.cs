using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine.Model
{
    public class VaccineInventory
    {
        public VaccineInventory(int id, int vaccineId, decimal startingStock, DateTime storageDate, DateTime expirationDate)
        {
            Id = id;
            VaccineId = vaccineId;
            StartingStock = startingStock;
            CurrentStock = startingStock;
            StorageDate = storageDate;
            ExpirationDate = expirationDate;
        }

        public int Id { get; private set;}
        public int VaccineId { get; private set; }
        public decimal StartingStock { get; private set; }
        public decimal CurrentStock { get; private set; }
        public DateTime StorageDate { get; private set; }

        public DateTime ExpirationDate { get; private set; }
        public virtual Vaccine Vaccine { get; set; }
    }
}
