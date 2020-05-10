using InventoryManagement.Domain.Request.Unit;
using InventoryManagement.Domain.Response.Unit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Interface
{
    public interface IUnitRepository
    {
        Task<IList<UnitView>> GetUnits();
        Task<UnitByID> GetUnitByID(int id);
        Task<bool> AddUnit(UnitCreate model);
        Task<bool> UpdateUnit(UnitEdit model);
    }
}
