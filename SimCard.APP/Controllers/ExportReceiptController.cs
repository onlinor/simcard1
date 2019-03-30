using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Persistence;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

using System.Threading.Tasks;

namespace SimCard.APP.Controllers
{
    [ApiController]
    public class ExportReceiptController : Controller
    {
        private readonly IExportReceiptRepository _exportReceiptRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExportReceiptController(IExportReceiptRepository exportReceiptRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _exportReceiptRepository = exportReceiptRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("/api/exportreceipt/GetProductCode")]
        public async Task<ExportReceiptViewModel> GenerateProductCode()
        {
            return new ExportReceiptViewModel
            {
                Ma = await _exportReceiptRepository.GenerateProductCode()
            };
        }
    }
}