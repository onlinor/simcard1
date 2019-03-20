using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.API.Models;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.API.Controllers
{
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierRepository SupplierRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _supplierRepository = SupplierRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("/api/Supplier")]
        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            var suppliers = await _supplierRepository.GetSuppliers();
            return suppliers;
        }

        [HttpGet("/api/Supplier/{id}")]
        public async Task<Supplier> GetSupplier(int id)
        {
            var supplier = await _supplierRepository.GetSupplier(id, true);
            return supplier;
        }

        [HttpPost("/api/Supplier/add")]
        public async Task<IActionResult> AddSupplier(Supplier wh)
        {
            if (await _supplierRepository.IsSupplierExists(wh.Name.ToLower()))
            {
                return BadRequest(wh.Name + " already exists!");
            }


            await _supplierRepository.AddSupplier(new Supplier
            {
                Name = wh.Name.ToLower()
            });
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpPut("/api/Supplier/edit/{id}")]
        public async Task<IActionResult> EditSupplier(Supplier wh)
        {
            if (await _supplierRepository.IsSupplierExists(wh.Name.ToLower()))
            {
                return BadRequest(wh.Name + " already exists!");
            }


            _supplierRepository.UpdateSupplier(new Supplier
            {
                Id = wh.Id,
                Name = wh.Name.ToLower()
            });
            await _unitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete("/api/Supplier/remove/{id}")]
        public async Task<IActionResult> RemoveSupplier(int id)
        {
            var supplier = await _supplierRepository.GetSupplier(id, true);

            if (supplier == null)
            {
                return NotFound();
            }

            _supplierRepository.Remove(supplier);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}