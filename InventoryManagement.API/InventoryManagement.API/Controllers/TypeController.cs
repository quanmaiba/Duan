using InventoryManagement.BAL.Interface;
using InventoryManagement.Domain.Request.Type;
using InventoryManagement.Domain.Response.Type;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.API.Controllers
{
    [ApiController]
    public class TypeController : ControllerBase
    {
        ITypeService _typeService;
        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        [Route("api/type/gets")]
        public async Task<IList<TypeView>> Gets()
        {
            return await _typeService.GetTypes();
        }

        [HttpGet]
        [Route("api/type/get/{id}")]
        public async Task<TypeByID> Get(int id)
        {
            return await _typeService.GetTypeByID(id);
        }

        [HttpPost]
        [Route("api/type/create")]
        public async Task<bool> Create([FromBody] TypeCreate model)
        {
            return await _typeService.AddType(model);
        }

        [HttpPut]
        [Route("api/type/update")]
        public async Task<bool> Update([FromBody] TypeEdit model)
        {
            return await _typeService.UpdateType(model);
        }
    }
}