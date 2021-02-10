using CovidVaccine.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private CovidVaccineContext _context;
        public HistoryRepository(CovidVaccineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VaccineHistory>> GetAllHistoryJoinPatientJoinInventory()
        {
            return await _context.VaccineHistories
                .Include(history => history.Patient)
                .Include(history => history.Inventory).ThenInclude(inventory => inventory.Vaccine)
                .ToListAsync();
        }
    }
}
