using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimCard.API.Controllers.Resources;
using SimCard.API.Models;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories._Supplier;

namespace SimCard.API.Controllers
{
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository SupplierRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SupplierController (ISupplierRepository SupplierRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.SupplierRepository = SupplierRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("/api/Supplier")]
        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            var Suppliers = await SupplierRepository.GetSuppliers();
            return Suppliers;        }

        [HttpGet("/api/Supplier/{id}")]
        public async Task<Supplier> GetSupplier (int id)
        {
            var Supplier = await SupplierRepository.GetSupplier (id, true);
            return Supplier;
        }

        [HttpPost("/api/Supplier/add")]
        public async Task<IActionResult> AddSupplier(Supplier wh)
        {
            if(await SupplierRepository.IsSupplierExists(wh.Name.ToLower()))
            {
                return BadRequest(wh.Name + " already exists!");
            }

            var SupplierToAdd = new Supplier
            {
                Name = wh.Name.ToLower()
            };

            await SupplierRepository.AddSupplier(SupplierToAdd);
            await unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPut("/api/Supplier/edit/{id}")]
        public async Task<IActionResult> EditSupplier (Supplier wh)
        {
            if(await SupplierRepository.IsSupplierExists(wh.Name.ToLower()))
            {
                return BadRequest(wh.Name + " already exists!");
            }
            
            var SupplierToUpdate = new Supplier
            {
                Id = wh.Id,
                Name = wh.Name.ToLower()
            };

            SupplierRepository.UpdateSupplier(SupplierToUpdate);
            await unitOfWork.CompleteAsync();
            
            return Ok();   
        }

        [HttpDelete("/api/Supplier/remove/{id}")]
        public async Task<IActionResult> RemoveSupplier (int id)
        {
            var Supplier = await SupplierRepository.GetSupplier(id, true);

            if (Supplier == null)
                return NotFound();

            SupplierRepository.Remove(Supplier);
            await unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}