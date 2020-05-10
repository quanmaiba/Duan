using InventoryManagement.BAL.Interface;
using InventoryManagement.DAL.Interface;
using InventoryManagement.Domain.Request.ProductionNorm;
using InventoryManagement.Domain.Response;
using InventoryManagement.Domain.Response.ProductionNorm;
using System.Collections.Generic;

namespace InventoryManagement.BAL
{
    public class ProductionNormService : IProductionNormService
    {
        private readonly IProductionNormRepository productionNormRepository;

        public ProductionNormService(IProductionNormRepository productionNormRepository)
        {
            this.productionNormRepository = productionNormRepository;
        }

        public AddOrEditProductionNormRes AddOrEditProductionNorms(List<AddOrEditProductionNorm> productionNorm, bool check)
        {
            return productionNormRepository.AddOrEditProductionNorms(productionNorm, check);
        }

        public BaseResponse CreateStatisticAll()
        {
            return productionNormRepository.CreateStatisticAll();
        }

        public IEnumerable<ProductionNormItem> GetProductionNormAll()
        {
            return productionNormRepository.GetProductionNormAll();
        }

        public ProductionNormItem GetProductionNormByID(int productionNormID)
        {
            return productionNormRepository.GetProductionNormByID(productionNormID);
        }

        public IEnumerable<StatisticDrinkItem> GetStatisticDrink()
        {
            return productionNormRepository.GetStatisticDrink();
        }

        public IEnumerable<StatisticIngredientItem> GetStatisticIngredient()
        {
            return productionNormRepository.GetStatisticIngredient();
        }

        public UpdateAmountDrinkRes UpdateAmountDrink(List<UpdateAmountDrink> updateAmountDrink)
        {
            return productionNormRepository.UpdateAmountDrink(updateAmountDrink);
        }
    }
}
