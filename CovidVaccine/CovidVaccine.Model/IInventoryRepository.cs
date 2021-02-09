using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine.Model
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<VaccineInventory>> GetAllInventoryJoinVaccine();
    }
}
