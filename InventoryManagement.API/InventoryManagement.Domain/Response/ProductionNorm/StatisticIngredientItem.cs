namespace InventoryManagement.Domain.Response.ProductionNorm
{
    public class StatisticIngredientItem
    {
        public string IngredientName { get; set; }
        public int TotalIngredients { get; set; }
        public float TotalIngredientType { get; set; }
        public int ResidualAmount { get; set; }
        public float ResidualAmountIngredients { get; set; }
        public string UnitName { get; set; }
        public string TypeName { get; set; }
        public string DayExport { get; set; }

    }
}
