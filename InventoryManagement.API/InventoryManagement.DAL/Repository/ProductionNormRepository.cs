using Dapper;
using InventoryManagement.DAL.Data;
using InventoryManagement.DAL.Interface;
using InventoryManagement.Domain.Request.ProductionNorm;
using InventoryManagement.Domain.Response;
using InventoryManagement.Domain.Response.ProductionNorm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace InventoryManagement.DAL.Repository
{
    public class ProductionNormRepository : BaseRepository, IProductionNormRepository
    {

        public IEnumerable<ProductionNormItem> GetProductionNormAll()
        {
            IEnumerable<ProductionNormItem> productionNormByViews = SqlMapper.Query<ProductionNormItem>(con, "GetProductionNormAll", null,
                 commandType: CommandType.StoredProcedure).ToList();

            return productionNormByViews;
        }


        public ProductionNormItem GetProductionNormByID(int productionNormID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", productionNormID);
            ProductionNormItem productionNormItem = SqlMapper.Query<ProductionNormItem>(con, "GetProductionNormByID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return productionNormItem;
        }

        public AddOrEditProductionNormRes AddOrEditProductionNorms(List<AddOrEditProductionNorm> productionNorm, bool check)
        {
            int a;
            var result = new AddOrEditProductionNormRes()
            {
                Result = 0,
                Message = $"Lỗi, vui lòng thử lại"
            };
            try
            {
                if (check)
                {
                    string processQuery = "INSERT INTO ProductionNorms(IngredientID,DrinkID,AmountNorm) VALUES (@IngredientID,@DrinkID,@AmountNorm)";
                    a = con.Execute(processQuery, productionNorm);

                    if (a == productionNorm.Count)
                    {
                        result.Result = 201;
                        result.Message = $"Them KO!";

                    };
                }
                else
                {
                    string processQuery = "UPDATE ProductionNorms SET IngredientID = @IngredientID, DrinkID = @DrinkID,AmountNorm = @AmountNorm WHERE ID = @ID";
                    a = con.Execute(processQuery, productionNorm);

                    if (a == productionNorm.Count)
                    {
                        result.Result = 200;
                        result.Message = $"Cap nhat ok!";

                    };
                }

                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public UpdateAmountDrinkRes UpdateAmountDrink(List<UpdateAmountDrink> updateAmountDrink)
        {
            int a;
            var result = new UpdateAmountDrinkRes()
            {
                Result = 0,
                Message = $"Lỗi, vui lòng thử lại"
            };
            try
            {
                string processQuery = "UPDATE ProductionNorms SET AmountDrink = AmountDrink + @AmountDrink WHERE DrinkID = @DrinkID GO " +
                "UPDATE ProductionNorms SET TotalCapacity = (ProductionNorms.AmountNorm * AmountDrink) WHERE DrinkID = @DrinkID";

                a = con.Execute(processQuery, updateAmountDrink);

                if (a == updateAmountDrink.Count)
                {
                    result.Result = 200;
                    result.Message = $"Cap nhat ok!";

                };

                //DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("@DrinkID", updateAmountDrink.DrinkID);
                //parameters.Add("@AmountDrink", updateAmountDrink.AmountDrink);

                //var response = SqlMapper.ExecuteScalar<int>(con, "UpdateAmountDrink",
                //                        param: parameters,
                //                        commandType: CommandType.StoredProcedure);
                //result.Result = response;
                //result.Message = result.Result == 1 ?
                //                    $"Thêm món thành công." :
                //                    $"Lỗi, vui lòng thử lại.";
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public BaseResponse CreateStatisticAll()
        {
            var result = new BaseResponse()
            {
                Result = 0,
                Message = $"Lỗi, vui lòng thử lại"
            };
            try
            {
                var response = SqlMapper.ExecuteScalar<int>(con, "CreateStatisticAll", null,
                                        commandType: CommandType.StoredProcedure);
                result.Result = response;
                result.Message = result.Result == 1 ?
                                    $"Thống kê thành công." :
                                    $"Lỗi, vui lòng thử lại.";
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public IEnumerable<StatisticIngredientItem> GetStatisticIngredient()
        {
            IEnumerable<StatisticIngredientItem> statisticIngredientItems = SqlMapper.Query<StatisticIngredientItem>(con, "GetStatisticIngredient", null,
                  commandType: CommandType.StoredProcedure).ToList();

            return statisticIngredientItems;
        }

        public IEnumerable<StatisticDrinkItem> GetStatisticDrink()
        {
            IEnumerable<StatisticDrinkItem> statisticDrinkItems = SqlMapper.Query<StatisticDrinkItem>(con, "GetStatisticDrink", null,
                 commandType: CommandType.StoredProcedure).ToList();

            return statisticDrinkItems;
        }


    }
}
