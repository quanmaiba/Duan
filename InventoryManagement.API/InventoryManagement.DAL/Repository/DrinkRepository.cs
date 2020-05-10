using InventoryManagement.DAL.Data;
using InventoryManagement.DAL.Interface;
using InventoryManagement.Domain.Request.Drink;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Repository
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly InventoryDbContext inventoryDbContext;

        public DrinkRepository(InventoryDbContext inventoryDbContext)
        {
            this.inventoryDbContext = inventoryDbContext;
        }
        public async Task<bool> AddDrink(DrinkCreate model)
        {
            try
            {
                var drinkCreate = new tblDrink
                {

                    ID = model.ID,
                    DrinkName = model.DrinkName

                };
                if (inventoryDbContext != null)
                {
                    await inventoryDbContext.Drinks.AddAsync(drinkCreate);
                    await inventoryDbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<tblDrink> GetDrinkByID(int id)
        {
            return await inventoryDbContext.Drinks.FindAsync(id);
        }

        public async Task<IList<tblDrink>> GetDrinks()
        {
            return await inventoryDbContext.Drinks.ToListAsync();

        }

        public async Task<bool> UpdateDrink(DrinkEdit model)
        {
            try
            {
                var drinkUpdate = new tblDrink
                {

                    ID = model.ID,
                    DrinkName = model.DrinkName
                };
                if (inventoryDbContext != null)
                {
                    inventoryDbContext.Drinks.Update(drinkUpdate);
                    await inventoryDbContext.SaveChangesAsync();
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
