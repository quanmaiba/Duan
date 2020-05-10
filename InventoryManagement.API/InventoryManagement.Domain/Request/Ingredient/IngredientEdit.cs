namespace InventoryManagement.Domain.Request.Ingredient
{
    public class IngredientEdit
    {
        public int ID { get; set; }
        public string IngredientName { get; set; }
        public int UnitID { get; set; }
        public int TypeID { get; set; }
        public int Capacity { get; set; }
        public int AmountStock { get; set; }
    }
}
