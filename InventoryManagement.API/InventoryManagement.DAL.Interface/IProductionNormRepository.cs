﻿using InventoryManagement.Domain.Request.ProductionNorm;
using InventoryManagement.Domain.Response;
using InventoryManagement.Domain.Response.ProductionNorm;
using System.Collections.Generic;

namespace InventoryManagement.DAL.Interface
{
    public interface IProductionNormRepository
    {
        AddOrEditProductionNormRes AddOrEditProductionNorms(List<AddOrEditProductionNorm> productionNorm, bool check);
        IEnumerable<ProductionNormItem> GetProductionNormAll();
        ProductionNormItem GetProductionNormByID(int productionNormID);
        UpdateAmountDrinkRes UpdateAmountDrink(List<UpdateAmountDrink> updateAmountDrink);
        BaseResponse CreateStatisticAll();
        IEnumerable<StatisticIngredientItem> GetStatisticIngredient();
        IEnumerable<StatisticDrinkItem> GetStatisticDrink();
    }
}
