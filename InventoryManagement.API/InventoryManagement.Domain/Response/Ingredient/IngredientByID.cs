namespace InventoryManagement.Domain.Response.Ingredient
{
    public class IngredientByID
    {
        public int ID { get; set; }
        public string IngredientName { get; set; }
        public string UnitName { get; set; }
        public string TypeName { get; set; }
        public decimal Capacity { get; set; }
        public int AmountStock { get; set; }
    }
}
