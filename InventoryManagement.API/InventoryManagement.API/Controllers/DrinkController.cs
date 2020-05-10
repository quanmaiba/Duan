using InventoryManagement.BAL.Interface;
using InventoryManagement.Domain.Request.Drink;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.API.Controllers
{
    [ApiController]
    public class DrinkController : ControllerBase
    {
        // GET: api/Drink
        IDrinkService drinkService;
        public DrinkController(IDrinkService DrinkService)
        {
            drinkService = DrinkService;
        }

        [HttpGet]
        [Route("api/drink/gets")]
        public async Task<IList<tblDrink>> Gets()
        {
            return await drinkService.GetDrinks();
        }

        [HttpGet]
        [Route("api/drink/get/{id}")]
        public async Task<tblDrink> Get(int id)
        {
            return await drinkService.GetDrinkByID(id);
        }

        [HttpPost]
        [Route("api/drink/create")]
        public async Task<bool> Create([FromBody] DrinkCreate model)
        {
            return await drinkService.AddDrink(model);
        }

        [HttpPut]
        [Route("api/drink/update")]
        public async Task<bool> Update([FromBody] DrinkEdit model)
        {
            return await drinkService.UpdateDrink(model);
        }
    }
}
