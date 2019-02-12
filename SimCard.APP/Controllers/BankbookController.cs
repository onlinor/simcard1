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
    public class BankbookController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBankbookRepository bankbookRepository;
        private readonly IUnitOfWork unitOfWork;
        public BankbookController(IBankbookRepository bankbookRepository, IMapper mapper, IUnitOfWork unitOfWork) {
            this.bankbookRepository = bankbookRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        //api/bankbook
        [HttpGet]
        public async Task<IEnumerable<BankbookResource>> GetAllBankbook() 
        {
            var bankbook = await bankbookRepository.GetAllBankbook();
            return mapper.Map<IEnumerable<Bankbook>, IEnumerable<BankbookResource>>(bankbook);
        }

        //api/bankbook/id
        [HttpGet("{id}")]
        public async Task<BankbookResource> GetBankbook(int id)
        {
            var bankbook = await bankbookRepository.GetBankbook(id);
            return mapper.Map<Bankbook, BankbookResource>(bankbook);
        }

        //api/bankbook/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankbook(int id)
        {
            var bankbook = await bankbookRepository.GetBankbook(id);

            if (bankbook == null)
                return NotFound();

            bankbookRepository.Remove(bankbook);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        //api/bankbook
        [HttpPost]
        public async Task<IActionResult> AddBankbook(Bankbook bankbook)
        {
            if (bankbook == null)
            {
                return BadRequest();
            }
            await bankbookRepository.AddBankbook(bankbook);
            await unitOfWork.CompleteAsync();
            return StatusCode(201);
        }

        //api/bankbook 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBankbook(int id, Bankbook bankbook)
        {
            if (bankbook == null)
            {
                return BadRequest();
            }
            await bankbookRepository.UpdateBankbook(id, bankbook);
            await unitOfWork.CompleteAsync();
            return StatusCode(201);
        }

        [HttpGet("last")]
        public async Task<int> GetLastIDBankbookRecord()
        {
            var lastIDRecord = await bankbookRepository.GetLastIDBankbookRecord();
            return lastIDRecord;
        }
    }
}