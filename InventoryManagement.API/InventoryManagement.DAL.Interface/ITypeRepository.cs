using InventoryManagement.Domain.Request.Type;
using InventoryManagement.Domain.Response.Type;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.DAL.Interface
{
    public interface ITypeRepository
    {
        Task<IList<TypeView>> GetTypes();
        Task<TypeByID> GetTypeByID(int id);
        Task<bool> AddType(TypeCreate model);
        Task<bool> UpdateType(TypeEdit model);
    }
}
