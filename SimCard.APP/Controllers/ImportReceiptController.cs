using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Controllers.Resources;
using SimCard.APP.Models;
using SimCard.APP.Persistence;
using SimCard.APP.Persistence.Repositories;

using System.Threading.Tasks;

namespace SimCard.APP.Controllers
{
    [ApiController]
    public class ImportReceiptController : Controller
    {
        private readonly IImportReceiptRepository _importReceiptRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ImportReceiptController(IImportReceiptRepository ImportReceiptRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _importReceiptRepository = ImportReceiptRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("/api/phieunhap/taoma")]
        public async Task<PhieunhapResource> GetPhieunhaps()
        {
            return new PhieunhapResource
            {
                ID = await _importReceiptRepository.GenerateID()
            };
        }

        [HttpPost("/api/phieunhap/add")]
        public async Task<IActionResult> AddPhieunhap(ImportReceipt importReceipt)
        {
            if (importReceipt == null)
            {
                return BadRequest();
            }
            await _importReceiptRepository.AddImportReceipt(importReceipt);
            await _unitOfWork.CompleteAsync();
            return StatusCode(201);
        }
    }
}