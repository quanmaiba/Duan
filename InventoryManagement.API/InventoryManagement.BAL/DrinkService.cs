using InventoryManagement.BAL.Interface;
using InventoryManagement.DAL.Interface;
using InventoryManagement.Domain.Request.Drink;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.BAL
{
    public class DrinkService : IDrinkService

    {
        private readonly IDrinkRepository drinkRepository;

        public DrinkService(IDrinkRepository drinkRepository)
        {
            this.drinkRepository = drinkRepository;
        }
        public async Task<bool> AddDrink(DrinkCreate model)
        {
            return await drinkRepository.AddDrink(model);
        }

        public async Task<tblDrink> GetDrinkByID(int id)
        {
            return await drinkRepository.GetDrinkByID(id);
        }

        public async Task<IList<tblDrink>> GetDrinks()
        {
            return await drinkRepository.GetDrinks();
        }

        public async Task<bool> UpdateDrink(DrinkEdit model)
        {
            return await drinkRepository.UpdateDrink(model);
        }
    }
}
