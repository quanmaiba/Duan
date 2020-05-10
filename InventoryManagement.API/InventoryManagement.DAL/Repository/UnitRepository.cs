using InventoryManagement.DAL.Data;
using InventoryManagement.DAL.Interface;
using InventoryManagement.Domain.Request.Unit;
using InventoryManagement.Domain.Response.Unit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Repository
{
    public class UnitRepository : IUnitRepository
    {
        InventoryDbContext _inventoryDbContext;
        public UnitRepository(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }

        public async Task<bool> AddUnit(UnitCreate model)
        {
            try
            {
                var unitCreate = new tblUnit
                {
                    ID = model.ID,
                    UnitName = model.UnitName
                };
                if (_inventoryDbContext != null)
                {
                    await _inventoryDbContext.Units.AddAsync(unitCreate);
                    await _inventoryDbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<UnitByID> GetUnitByID(int id)
        {
            var unit = new UnitByID();
            try
            {
                unit = await (from u in _inventoryDbContext.Units
                              where u.ID == id
                              select new UnitByID
                              {
                                  ID = u.ID,
                                  UnitName = u.UnitName
                              }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return unit;
        }

        public async Task<IList<UnitView>> GetUnits()
        {
            var units = new List<UnitView>();
            try
            {
                units = await (from u in _inventoryDbContext.Units
                               select new UnitView
                               {
                                   ID = u.ID,
                                   UnitName = u.UnitName
                               }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return units;
        }

        public async Task<bool> UpdateUnit(UnitEdit model)
        {
            try
            {
                var unitUpdate = new tblUnit
                {
                    ID = model.ID,
                    UnitName = model.UnitName
                };
                if (_inventoryDbContext != null)
                {
                    _inventoryDbContext.Units.Update(unitUpdate);
                    await _inventoryDbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
