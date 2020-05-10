using InventoryManagement.Domain.Request.Ingredient;
using InventoryManagement.Domain.Response.Ingredient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.BAL.Interface
{
    public interface IIngredientService
    {
        Task<IList<IngredientView>> GetIngredients();
        Task<IngredientByID> GetIngredientByID(int id);
        Task<bool> AddIngredient(IngredientCreate model);
        Task<bool> UpdateIngredient(IngredientEdit model);
    }
}
