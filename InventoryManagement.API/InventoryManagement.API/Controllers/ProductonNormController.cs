using InventoryManagement.BAL.Interface;
using InventoryManagement.Domain.Request.ProductionNorm;
using InventoryManagement.Domain.Response;
using InventoryManagement.Domain.Response.ProductionNorm;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryManagement.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]

    public class ProductonNormController : ControllerBase
    {
        private readonly IProductionNormService productionNormService;

        public ProductonNormController(IProductionNormService productionNormService)
        {
            this.productionNormService = productionNormService;
        }
        // GET: api/ProductonNorm
        [HttpGet]
        [Route("api/ProductionNorm/GetProductionNormAll")]
        public IEnumerable<ProductionNormItem> GetProductionNormAll()
        {
            return productionNormService.GetProductionNormAll();
        }

        [HttpGet]
        [Route("api/ProductionNorm/GetProductionNormByID/{productionNormID}")]
        public ProductionNormItem GetProductionNormByID(int productionNormID)
        {
            return productionNormService.GetProductionNormByID(productionNormID);
        }

        // GET: api/ProductonNorm/5

        // POST: api/ProductonNorm
        [HttpPost]
        [Route("api/ProductionNorm/AddOrEditProductionNorm")]
        public IActionResult AddOrEditProductionNorm([FromBody] List<AddOrEditProductionNorm> request)
        {
            var check = false;

            foreach (var item in request)
            {
                if (item.ID == 0)
                {
                    check = true;
                    break;
                }
                break;
            }

            var response = productionNormService.AddOrEditProductionNorms(request, check);

            if (response.Result == 201)
            {
                return Created(response.Message, null);
            }
            else if (response.Result == 200)
            {
                return Ok(response.Message);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/ProductionNorm/UpdateAmountDrink")]
        public UpdateAmountDrinkRes UpdateAmountDrink([FromBody] List<UpdateAmountDrink> request)
        {
            return productionNormService.UpdateAmountDrink(request);
        }

        [HttpGet]
        [Route("api/Statistic/CreateStatisticAll")]
        public BaseResponse CreateStatisticAll()
        {
            return productionNormService.CreateStatisticAll();
        }


        [HttpGet]
        [Route("api/Statistic/GetStatisticDrink")]
        public IEnumerable<StatisticDrinkItem> GetStatisticDrink()
        {
            productionNormService.CreateStatisticAll();
            return productionNormService.GetStatisticDrink();
        }

        [HttpGet]
        [Route("api/Statistic/GetStatisticIngredient")]
        public IEnumerable<StatisticIngredientItem> GetStatisticIngredient()
        {
            productionNormService.CreateStatisticAll();
            return productionNormService.GetStatisticIngredient();
        }
    }
}
