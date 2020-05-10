using InventoryManagement.BAL.Interface;
using InventoryManagement.DAL.Interface;
using InventoryManagement.Domain.Request.Ingredient;
using InventoryManagement.Domain.Response.Ingredient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.BAL
{
    public class IngredientService : IIngredientService
    {
        IIngredientRepository _ingredientRepository;
        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<bool> AddIngredient(IngredientCreate model)
        {
            return await _ingredientRepository.AddIngredient(model);
        }

        public async Task<IngredientByID> GetIngredientByID(int id)
        {
            return await _ingredientRepository.GetIngredientByID(id);
        }

        public async Task<IList<IngredientView>> GetIngredients()
        {
            return await _ingredientRepository.GetIngredients();
        }

        public async Task<bool> UpdateIngredient(IngredientEdit model)
        {
            return await _ingredientRepository.UpdateIngredient(model);
        }
    }
}
