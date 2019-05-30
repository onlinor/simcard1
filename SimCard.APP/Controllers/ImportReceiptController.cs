
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Persistence;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Controllers
{
    [ApiController]
    public class ImportReceiptController : Controller
    {
        private readonly IImportReceiptRepository _importReceiptRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ImportReceiptController(IImportReceiptRepository importReceiptRepository, IUnitOfWork unitOfWork)
        {
            _importReceiptRepository = importReceiptRepository;
            _unitOfWork = unitOfWork;
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