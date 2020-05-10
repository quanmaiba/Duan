using InventoryManagement.BAL.Interface;
using InventoryManagement.DAL.Interface;
using InventoryManagement.Domain.Request.Type;
using InventoryManagement.Domain.Response.Type;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.BAL
{
    public class TypeService : ITypeService
    {
        ITypeRepository _typeRepository;
        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<bool> AddType(TypeCreate model)
        {
            return await _typeRepository.AddType(model);
        }

        public async Task<TypeByID> GetTypeByID(int id)
        {
            return await _typeRepository.GetTypeByID(id);
        }

        public async Task<IList<TypeView>> GetTypes()
        {
            return await _typeRepository.GetTypes();
        }

        public async Task<bool> UpdateType(TypeEdit model)
        {
            return await _typeRepository.UpdateType(model);
        }
    }
}
