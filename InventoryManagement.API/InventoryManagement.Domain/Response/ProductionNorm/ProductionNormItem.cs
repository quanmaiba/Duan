namespace InventoryManagement.Domain.Response.ProductionNorm
{
    public class ProductionNormItem
    {
        public int ID { get; set; }
        public int DrinkID { get; set; }
        public string IngredientName { get; set; }
        public string DrinkName { get; set; }
        public int AmountNorm { get; set; }
    }
}
