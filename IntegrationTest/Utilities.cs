using CovidVaccine.Model;
using CovidVaccine.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest
{
    public class Utilities
    {
        public static void InitializeDbForTests(CovidVaccineContext db)
        {
            db.Patients.AddRange(GetSeedingPatients());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(CovidVaccineContext db)
        {
            db.Patients.RemoveRange(db.Patients);
            InitializeDbForTests(db);
        }

        public static List<Patient> GetSeedingPatients()
        {
            return new List<Patient>()
            {
                new Patient(1, "Jason", "Brace", "Palisoc", "09662679535", new DateTime(08/05/1995), 'M'),
                new Patient(2, "Jason2", "Brace2", "Palisoc2", "09662679535", new DateTime(08/05/1995), 'M')
            };
        }
    }
}
