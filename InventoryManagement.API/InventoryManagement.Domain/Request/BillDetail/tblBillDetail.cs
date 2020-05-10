using System;

namespace InventoryManagement.Domain.Request.BillDetail
{
    public class tblBillDetail
    {
        public int ID { get; set; }
        public int IngredientID { get; set; }
        public int AmountBuy { get; set; }
        public string Description { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
