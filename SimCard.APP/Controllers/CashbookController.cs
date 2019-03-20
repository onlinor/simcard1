using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.API.Controllers.Resources;
using SimCard.API.Models;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashbookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICashbookRepository _cashbookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CashbookController(ICashbookRepository cashbookRepository, IMapper mapper, IUnitOfWork unitOfWork) {
            _cashbookRepository = cashbookRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        
        //api/cashbook
        [HttpGet]
        public async Task<IEnumerable<CashbookResource>> GetAllCashbook() 
        {
            var cashbook = await _cashbookRepository.GetAllCashbook();
            return _mapper.Map<IEnumerable<Cashbook>, IEnumerable<CashbookResource>>(cashbook);
        }

        //api/cashbook/id
        [HttpGet("{id}")]
        public async Task<CashbookResource> GetCashbook(int id)
        {
            var cashbook = await _cashbookRepository.GetCashbook(id);
            return _mapper.Map<Cashbook, CashbookResource>(cashbook);
        }

        //api/cashbook/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashbook(int id)
        {
            var cashbook = await _cashbookRepository.GetCashbook(id);

            if (cashbook == null)
                return NotFound();

            _cashbookRepository.Remove(cashbook);
            await _unitOfWork.CompleteAsync();

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
            await _unitOfWork.CompleteAsync();
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
            await _unitOfWork.CompleteAsync();
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