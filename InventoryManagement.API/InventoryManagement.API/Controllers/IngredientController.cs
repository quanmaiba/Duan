using InventoryManagement.BAL.Interface;
using InventoryManagement.Domain.Request.Ingredient;
using InventoryManagement.Domain.Response.Ingredient;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.API.Controllers
{
    [ApiController]
    public class IngredientController : ControllerBase
    {
        IIngredientService _ingredientService;
        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        [Route("api/ingredient/gets")]
        public async Task<IList<IngredientView>> Gets()

        {
            return await _ingredientService.GetIngredients();
        }

        [HttpGet]
        [Route("api/ingredient/get/{id}")]
        public async Task<IngredientByID> Get(int id)
        {
            return await _ingredientService.GetIngredientByID(id);
        }

        [HttpPost]
        [Route("api/ingredient/create")]
        public async Task<bool> Create([FromBody] IngredientCreate model)
        {
            return await _ingredientService.AddIngredient(model);
        }

        [HttpPut]
        [Route("api/ingredient/update")]
        public async Task<bool> Update([FromBody] IngredientEdit model)
        {
            return await _ingredientService.UpdateIngredient(model);
        }
    }
}
