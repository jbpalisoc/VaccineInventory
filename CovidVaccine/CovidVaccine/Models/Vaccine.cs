using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }

        public ICollection<Inventory> Inventories { get; set; }

    }
}
