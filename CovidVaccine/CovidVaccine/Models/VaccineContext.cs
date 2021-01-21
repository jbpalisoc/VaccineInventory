using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine.Models
{
    public class VaccineContext : DbContext
    {
        private readonly DbContextOptions _options;
        public VaccineContext(DbContextOptions<VaccineContext> options) : base(options)
        {
            _options = options;
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Inventory> InventoryEntries { get; set; }
        public DbSet<VaccineHistory> VaccineHistoryEntries { get; set; }
    }
}
