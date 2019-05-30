using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Database;
using SimCard.APP.Models;
using SimCard.APP.Repository;
using SimCard.APP.ViewModels;

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
        public async Task<IEnumerable<DebtbookViewModel>> GetAllDebtbook()
        {
            IEnumerable<Debtbook> debtbook = await _debtbookRepository.GetAllDebtbook();
            return Mapper.Map<IEnumerable<Debtbook>, IEnumerable<DebtbookViewModel>>(debtbook);
        }

        //api/debtbook
        [HttpPost]
        public async Task<IActionResult> AddDebtbook(Debtbook debtbook)
        {
            if (debtbook == null)
            {
                return BadRequest();
            }
            await _debtbookRepository.AddDebtbook(debtbook);
            await _unitOfWork.SaveChangeAsync();
            return StatusCode(201);
        }
    }
}