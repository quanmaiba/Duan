using InventoryManagement.Domain.Request.Type;
using InventoryManagement.Domain.Response.Type;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.BAL.Interface
{
    public interface ITypeService
    {
        Task<IList<TypeView>> GetTypes();
        Task<TypeByID> GetTypeByID(int id);
        Task<bool> AddType(TypeCreate model);
        Task<bool> UpdateType(TypeEdit model);
    }
}
