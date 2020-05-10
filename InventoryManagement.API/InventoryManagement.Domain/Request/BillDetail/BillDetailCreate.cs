using System;

namespace InventoryManagement.Domain.Request.BillDetail
{
    public class BillDetailCreate
    {
        public int ID { get; set; }
        public int IngredientID { get; set; }
        public int AmountBuy { get; set; }
        public string Description { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
