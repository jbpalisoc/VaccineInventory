using CovidVaccine.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine.Repository
{
    public class CovidVaccineContext : DbContext
    {
        private readonly DbContextOptions _options;
        public CovidVaccineContext(DbContextOptions<CovidVaccineContext> options) : base(options)
        {
            _options = options;
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
