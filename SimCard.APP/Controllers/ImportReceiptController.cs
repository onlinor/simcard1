using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Persistence;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

using System.Threading.Tasks;

namespace SimCard.APP.Controllers
{
    [ApiController]
    public class ImportReceiptController : Controller
    {
        private readonly IImportReceiptRepository _importReceiptRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ImportReceiptController(IImportReceiptRepository importReceiptRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _importReceiptRepository = importReceiptRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("/api/importreceipt/GetProductCode")]
        public async Task<ImportReceiptViewModel> GenerateProductCode()
        {
            return new ImportReceiptViewModel
            {
                Ma = await _importReceiptRepository.GenerateProductCode()
            };
        }

        [HttpPost("/api/importreceipt/Add")]
        public async Task<IActionResult> AddImportReceipt(ImportReceiptViewModel importReceipt)
        {
            if (importReceipt == null)
            {
                return BadRequest();
            }
            await _importReceiptRepository.AddImportReceipt(importReceipt);
            await _unitOfWork.SaveChangeAsync();
            return StatusCode(201);
        }
    }
}