
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Persistence;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Controllers
{
    [ApiController]
    public class ExportReceiptController : Controller
    {
        private readonly IExportReceiptRepository _exportReceiptRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExportReceiptController(IExportReceiptRepository exportReceiptRepository, IUnitOfWork unitOfWork)
        {
            _exportReceiptRepository = exportReceiptRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("/api/exportreceipt/GetProductCode")]
        public async Task<ExportReceiptViewModel> GenerateProductCode()
        {
            return new ExportReceiptViewModel
            {
                Ma = await _exportReceiptRepository.GenerateProductCode()
            };
        }

        [HttpPost("/api/exportreceipt/Add")]
        public async Task<IActionResult> AddExportReceipt(ExportReceiptViewModel exportReceipt)
        {
            if (exportReceipt == null)
            {
                return BadRequest();
            }
            await _exportReceiptRepository.AddExportReceipt(exportReceipt);
            await _unitOfWork.SaveChangeAsync();
            return StatusCode(201);
        }
    }
}