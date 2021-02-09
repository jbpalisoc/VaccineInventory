using CovidVaccine.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private CovidVaccineContext _context;
        public InventoryRepository(CovidVaccineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VaccineInventory>> GetAllInventoryJoinVaccine()
        {
            return await _context.VaccineInventories.Include(inventory => inventory.Vaccine).ToListAsync();
        }
    }
}
