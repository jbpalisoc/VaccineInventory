using CovidVaccine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        //IPatientRepository Patients { get; }
        Task<int> Commit();
        //void Rollback();
    }
}
