using InventoryManagement.BAL.Interface;
using InventoryManagement.DAL.Interface;
using InventoryManagement.Domain.Request.Unit;
using InventoryManagement.Domain.Response.Unit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.BAL
{
    public class UnitService : IUnitService
    {
        IUnitRepository _unitRepository;
        public UnitService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<bool> AddUnit(UnitCreate model)
        {
            return await _unitRepository.AddUnit(model);
        }

        public async Task<UnitByID> GetUnitByID(int id)
        {
            return await _unitRepository.GetUnitByID(id);
        }

        public async Task<IList<UnitView>> GetUnits()
        {
            return await _unitRepository.GetUnits();
        }

        public async Task<bool> UpdateUnit(UnitEdit model)
        {
            return await _unitRepository.UpdateUnit(model);
        }
    }
}
