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
    public class BankbookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBankbookRepository _bankbookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BankbookController(IBankbookRepository bankbookRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _bankbookRepository = bankbookRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        //api/bankbook
        [HttpGet]
        public async Task<IEnumerable<BankbookResource>> GetAllBankbook()
        {
            IEnumerable<Bankbook> bankbook = await _bankbookRepository.GetAllBankbook();
            return _mapper.Map<IEnumerable<Bankbook>, IEnumerable<BankbookResource>>(bankbook);
        }

        //api/bankbook/id
        [HttpGet("{id}")]
        public async Task<BankbookResource> GetBankbook(int id)
        {
            Bankbook bankbook = await _bankbookRepository.GetBankbook(id);
            return _mapper.Map<Bankbook, BankbookResource>(bankbook);
        }

        //api/bankbook/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankbook(int id)
        {
            Bankbook bankbook = await _bankbookRepository.GetBankbook(id);

            if (bankbook == null)
            {
                return NotFound();
            }

            _bankbookRepository.Remove(bankbook);
            await _unitOfWork.CompleteAsync();

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
            await _bankbookRepository.AddBankbook(bankbook);
            await _unitOfWork.CompleteAsync();
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
            await _bankbookRepository.UpdateBankbook(id, bankbook);
            await _unitOfWork.CompleteAsync();
            return StatusCode(201);
        }

        // [HttpGet("last")]
        // public async Task<int> GetLastIDBankbookRecord()
        // {
        //     var lastIDRecord = await bankbookRepository.GetLastIDBankbookRecord();
        //     return lastIDRecord;
        // }
    }
}