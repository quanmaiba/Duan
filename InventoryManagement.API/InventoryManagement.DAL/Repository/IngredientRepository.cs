using InventoryManagement.DAL.Data;
using InventoryManagement.DAL.Interface;
using InventoryManagement.Domain.Request.Ingredient;
using InventoryManagement.Domain.Response.Ingredient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        InventoryDbContext _inventoryDbContext;
        public IngredientRepository(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }

        public async Task<bool> AddIngredient(IngredientCreate model)
        {
            try
            {
                var ingredientCreate = new tblIngredient
                {
                    AmountStock = model.AmountStock,
                    Capacity = model.Capacity,
                    ID = model.ID,
                    IngredientName = model.IngredientName,
                    TypeID = model.TypeID,
                    UnitID = model.UnitID
                };
                if (_inventoryDbContext != null)
                {
                    await _inventoryDbContext.Ingredients.AddAsync(ingredientCreate);
                    await _inventoryDbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IngredientByID> GetIngredientByID(int id)
        {
            var ingredient = new IngredientByID();
            try
            {
                ingredient = await (from i in _inventoryDbContext.Ingredients
                                    join t in _inventoryDbContext.Types on i.TypeID equals t.ID
                                    join u in _inventoryDbContext.Units on i.UnitID equals u.ID
                                    where id == i.ID
                                    select new IngredientByID
                                    {
                                        ID = i.ID,
                                        AmountStock = i.AmountStock,
                                        Capacity = i.Capacity,
                                        IngredientName = i.IngredientName,
                                        TypeName = t.TypeName,
                                        UnitName = u.UnitName
                                    }).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ingredient;
        }

        public async Task<IList<IngredientView>> GetIngredients()
        {
            var ingredients = new List<IngredientView>();
            try
            {
                ingredients = await (from i in _inventoryDbContext.Ingredients
                                     join t in _inventoryDbContext.Types on i.TypeID equals t.ID
                                     join u in _inventoryDbContext.Units on i.UnitID equals u.ID
                                     select new IngredientView
                                     {
                                         ID = i.ID,
                                         AmountStock = i.AmountStock,
                                         Capacity = i.Capacity,
                                         IngredientName = i.IngredientName,
                                         TypeName = t.TypeName,
                                         UnitName = u.UnitName
                                     }).ToListAsync();


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ingredients;
        }

        public async Task<bool> UpdateIngredient(IngredientEdit model)
        {
            try
            {
                var ingredientUpdate = new tblIngredient
                {
                    AmountStock = model.AmountStock,
                    Capacity = model.Capacity,
                    ID = model.ID,
                    IngredientName = model.IngredientName,
                    TypeID = model.TypeID,
                    UnitID = model.UnitID
                };
                if (_inventoryDbContext != null)
                {
                    _inventoryDbContext.Ingredients.Update(ingredientUpdate);
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
