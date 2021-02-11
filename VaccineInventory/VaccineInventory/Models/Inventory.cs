using System;
using System.Collections.Generic;
using System.Text;

namespace VaccineInventory.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int VaccineId { get; set; }
        public decimal StartingStock { get; set; }
        public decimal CurrentStock { get; set; }
        public DateTime StorageDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Vaccine Vaccine { get; set; }
    }
}
