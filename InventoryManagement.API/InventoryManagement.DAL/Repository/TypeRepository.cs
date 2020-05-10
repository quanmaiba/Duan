using InventoryManagement.DAL.Data;
using InventoryManagement.DAL.Interface;
using InventoryManagement.Domain.Request.Type;
using InventoryManagement.Domain.Response.Type;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Repository
{
    public class TypeRepository : ITypeRepository
    {
        InventoryDbContext _inventoryDbContext;
        public TypeRepository(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }

        public async Task<bool> AddType(TypeCreate model)
        {
            try
            {
                var typeCreate = new tblType
                {
                    ID = model.ID,
                    TypeName = model.TypeName
                };
                if (_inventoryDbContext != null)
                {
                    await _inventoryDbContext.Types.AddAsync(typeCreate);
                    await _inventoryDbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<TypeByID> GetTypeByID(int id)
        {
            var type = new TypeByID();
            try
            {
                type = await (from t in _inventoryDbContext.Types
                              select new TypeByID
                              {
                                  ID = t.ID,
                                  TypeName = t.TypeName
                              }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return type;
        }

        public async Task<IList<TypeView>> GetTypes()
        {
            var types = new List<TypeView>();
            try
            {
                types = await (from t in _inventoryDbContext.Types
                               select new TypeView
                               {
                                   ID = t.ID,
                                   TypeName = t.TypeName
                               }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return types;
        }

        public async Task<bool> UpdateType(TypeEdit model)
        {
            try
            {
                var typeUpdate = new tblType
                {
                    ID = model.ID,
                    TypeName = model.TypeName
                };
                if (_inventoryDbContext != null)
                {
                    _inventoryDbContext.Types.Update(typeUpdate);
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
