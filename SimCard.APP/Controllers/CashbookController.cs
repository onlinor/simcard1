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
    public class CashbookController : ControllerBase
    {
        private readonly ICashbookRepository _cashbookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CashbookController(ICashbookRepository cashbookRepository, IUnitOfWork unitOfWork)
        {
            _cashbookRepository = cashbookRepository;
            _unitOfWork = unitOfWork;
        }

        //api/cashbook
        [HttpGet]
        public async Task<IEnumerable<CashbookViewModel>> GetAllCashbook()
        {
            IEnumerable<Cashbook> cashbook = await _cashbookRepository.GetAllCashbook();
            return Mapper.Map<IEnumerable<Cashbook>, IEnumerable<CashbookViewModel>>(cashbook);
        }

        //api/cashbook/id
        [HttpGet("{id}")]
        public async Task<CashbookViewModel> GetCashbook(int id)
        {
            Cashbook cashbook = await _cashbookRepository.GetCashbook(id);
            return Mapper.Map<Cashbook, CashbookViewModel>(cashbook);
        }

        //api/cashbook/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashbook(int id)
        {
            Cashbook cashbook = await _cashbookRepository.GetCashbook(id);

            if (cashbook == null)
            {
                return NotFound();
            }

            _cashbookRepository.Remove(cashbook);
            await _unitOfWork.SaveChangeAsync();

            return Ok(id);
        }

        //api/cashbook
        [HttpPost]
        public async Task<IActionResult> AddCashbook(Cashbook cashbook)
        {
            if (cashbook == null)
            {
                return BadRequest();
            }
            await _cashbookRepository.AddCashbook(cashbook);
            await _unitOfWork.SaveChangeAsync();
            return StatusCode(201);
        }

        //api/cashbook 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCashbook(int id, Cashbook cashbook)
        {
            if (cashbook == null)
            {
                return BadRequest();
            }
            await _cashbookRepository.UpdateCashbook(id, cashbook);
            await _unitOfWork.SaveChangeAsync();
            return StatusCode(201);
        }

        // [HttpGet("last")]
        // public async Task<int> GetLastIDCashbookRecord()
        // {
        //     var lastIDRecord = await cashbookRepository.GetLastIDCashbookRecord();
        //     return lastIDRecord;
        // }
    }
}