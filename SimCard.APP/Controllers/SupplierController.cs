
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Models;
using SimCard.APP.Persistence;
using SimCard.APP.Persistence.Repositories;

namespace SimCard.APP.Controllers
{
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SupplierController(ISupplierRepository SupplierRepository, IUnitOfWork unitOfWork)
        {
            _supplierRepository = SupplierRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("/api/Supplier")]
        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            IEnumerable<Supplier> suppliers = await _supplierRepository.GetSuppliers();
            return suppliers;
        }

        [HttpGet("/api/Supplier/{id}")]
        public async Task<Supplier> GetSupplier(int id)
        {
            Supplier supplier = await _supplierRepository.GetSupplier(id);
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
            await _unitOfWork.SaveChangeAsync();

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
            await _unitOfWork.SaveChangeAsync();

            return Ok();
        }

        [HttpDelete("/api/Supplier/remove/{id}")]
        public async Task<IActionResult> RemoveSupplier(int id)
        {
            Supplier supplier = await _supplierRepository.GetSupplier(id);

            if (supplier == null)
            {
                return NotFound();
            }

            _supplierRepository.Remove(supplier);
            await _unitOfWork.SaveChangeAsync();

            return Ok();
        }
    }
}