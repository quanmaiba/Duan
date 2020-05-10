namespace InventoryManagement.Domain.Request.ProductionNorm
{

    public class AddOrEditProductionNorm
    {
        public int ID { get; set; }
        public int IngredientID { get; set; }
        public int DrinkID { get; set; }
        public int AmountNorm { get; set; }
    }
}
