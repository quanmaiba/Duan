using System;

namespace InventoryManagement.Domain.Response.BillDetail
{
    public class BillDetailView
    {
        public int ID { get; set; }
        public string IngredientName { get; set; }
        public int AmountBuy { get; set; }
        public string Description { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
