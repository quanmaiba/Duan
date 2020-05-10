using InventoryManagement.BAL.Interface;
using InventoryManagement.Domain.Request.Unit;
using InventoryManagement.Domain.Response.Unit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.API.Controllers
{
    [ApiController]
    public class UnitController : ControllerBase
    {
        IUnitService _unitService;
        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        [Route("api/unit/gets")]
        public async Task<IList<UnitView>> Gets()
        {
            return await _unitService.GetUnits();
        }

        [HttpGet]
        [Route("api/unit/get/{id}")]
        public async Task<UnitByID> Get(int id)
        {
            return await _unitService.GetUnitByID(id);
        }

        [HttpPost]
        [Route("api/unit/create")]
        public async Task<bool> Create([FromBody] UnitCreate model)
        {
            return await _unitService.AddUnit(model);
        }

        [HttpPut]
        [Route("api/unit/update")]
        public async Task<bool> Update([FromBody] UnitEdit model)
        {
            return await _unitService.UpdateUnit(model);
        }
    }
}