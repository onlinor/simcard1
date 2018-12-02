using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimCard.API.Controllers.Resources;
using SimCard.API.Models;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories._Warehouse;

namespace SimCard.API.Controllers
{
    [ApiController]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseRepository warehouseRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public WarehouseController (IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.warehouseRepository = warehouseRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("/api/warehouse")]
        public async Task<IEnumerable<WarehouseResource>> GetWarehouses()
        {
            var warehouses = await warehouseRepository.GetWarehouses();
            return mapper.Map<IEnumerable<Warehouse>, IEnumerable<WarehouseResource>>(warehouses);
        }

        [HttpGet("/api/warehouse/{id}")]
        public async Task<WarehouseResource> GetWarehouse (int id)
        {
            var warehouse = await warehouseRepository.GetWarehouse (id, true);
            return mapper.Map<Warehouse, WarehouseResource>(warehouse);
        }

        [HttpPost("/api/warehouse/add")]
        public async Task<IActionResult> AddWarehouse(WarehouseResource wh)
        {
            if(await warehouseRepository.IsWarehouseExists(wh.Name.ToLower()))
            {
                return BadRequest(wh.Name + " already exists!");
            }

            var warehouseToAdd = new Warehouse
            {
                Name = wh.Name.ToLower(),
                Note = wh.Note
            };

            await warehouseRepository.Addwarehouse(warehouseToAdd);
            await unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPut("/api/warehouse/edit/{id}")]
        public async Task<IActionResult> EditWarehouse (WarehouseResource wh)
        {
            if(await warehouseRepository.IsWarehouseExists(wh.Name.ToLower()))
            {
                return BadRequest(wh.Name + " already exists!");
            }
            
            var warehouseToUpdate = new Warehouse
            {
                Id = wh.Id,
                Name = wh.Name.ToLower(),
                Note = wh.Note
            };

            warehouseRepository.Updatewarehouse(warehouseToUpdate);
            await unitOfWork.CompleteAsync();
            
            return Ok();   
        }

        [HttpDelete("/api/warehouse/remove/{id}")]
        public async Task<IActionResult> RemoveWarehouse (int id)
        {
            var warehouse = await warehouseRepository.GetWarehouse(id, true);

            if (warehouse == null)
                return NotFound();

            warehouseRepository.Remove(warehouse);
            await unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}