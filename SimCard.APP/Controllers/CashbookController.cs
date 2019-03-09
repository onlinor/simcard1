using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimCard.API.Controllers.Resources;
using SimCard.API.Models;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories;

namespace SimCard.API.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashbookController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICashbookRepository cashbookRepository;
        private readonly IUnitOfWork unitOfWork;
        public CashbookController(ICashbookRepository cashbookRepository, IMapper mapper, IUnitOfWork unitOfWork) {
            this.cashbookRepository = cashbookRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        
        //api/cashbook
        [HttpGet]
        public async Task<IEnumerable<CashbookResource>> GetAllCashbook() 
        {
            var cashbook = await cashbookRepository.GetAllCashbook();
            return mapper.Map<IEnumerable<Cashbook>, IEnumerable<CashbookResource>>(cashbook);
        }

        //api/cashbook/id
        [HttpGet("{id}")]
        public async Task<CashbookResource> GetCashbook(int id)
        {
            var cashbook = await cashbookRepository.GetCashbook(id);
            return mapper.Map<Cashbook, CashbookResource>(cashbook);
        }

        //api/cashbook/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashbook(int id)
        {
            var cashbook = await cashbookRepository.GetCashbook(id);

            if (cashbook == null)
                return NotFound();

            cashbookRepository.Remove(cashbook);
            await unitOfWork.CompleteAsync();

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
            await cashbookRepository.AddCashbook(cashbook);
            await unitOfWork.CompleteAsync();
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
            await cashbookRepository.UpdateCashbook(id, cashbook);
            await unitOfWork.CompleteAsync();
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