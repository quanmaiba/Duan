using InventoryManagement.Domain.Request.BillDetail;
using InventoryManagement.Domain.Response.BillDetail;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Interface
{
    public interface IBillDetailRepository
    {
        Task<IList<BillDetailView>> GetBillDetails();
        Task<BillDetailByID> GetBillDetailByID(int id);
        Task<bool> AddBillDetail(BillDetailCreate model);
        Task<bool> UpdateBillDetail(BillDetailEdit model);
    }
}
