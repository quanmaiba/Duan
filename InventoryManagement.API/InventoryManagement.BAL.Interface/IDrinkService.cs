using InventoryManagement.Domain.Request.Drink;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.BAL.Interface
{
    public interface IDrinkService
    {
        Task<IList<tblDrink>> GetDrinks();
        Task<tblDrink> GetDrinkByID(int id);
        Task<bool> AddDrink(DrinkCreate model);
        Task<bool> UpdateDrink(DrinkEdit model);
    }
}
