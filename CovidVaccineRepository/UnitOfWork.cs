using CovidVaccine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CovidVaccineContext _databaseContext;
        public UnitOfWork(CovidVaccineContext databaseContext)
        {
            _databaseContext = databaseContext;      
        }

        public async Task<int> Commit()
        {
            return await(_databaseContext.SaveChangesAsync());
            
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }
    }
}
