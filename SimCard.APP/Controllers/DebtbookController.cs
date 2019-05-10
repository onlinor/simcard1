using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Models;
using SimCard.APP.Persistence;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtbookController : ControllerBase
    {
        private readonly IDebtbookRepository _debtbookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DebtbookController(IDebtbookRepository debtbookRepository, IUnitOfWork unitOfWork)
        {
            _debtbookRepository = debtbookRepository;
            _unitOfWork = unitOfWork;
        }

        //api/debtbook
        [HttpGet]
        public async Task<IEnumerable<DebtbookViewModel>> getAllDebtbook()
        {
            IEnumerable<Debtbook> debtbook = await _debtbookRepository.getAllDebtbook();
            return Mapper.Map<IEnumerable<Debtbook>, IEnumerable<DebtbookViewModel>>(debtbook);
        }

        //api/debtbook
        [HttpPost]
        public async Task<IActionResult> addDebtbook(Debtbook debtbook)
        {
            if (debtbook == null)
            {
                return BadRequest();
            }
            await _debtbookRepository.addDebtbook(debtbook);
            await _unitOfWork.SaveChangeAsync();
            return StatusCode(201);
        }
    }
}