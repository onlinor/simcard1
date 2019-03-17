using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SimCard.API.Controllers.Resources;
using SimCard.API.Models;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories._ImportReceipt;

namespace SimCard.API.Controllers
{
    [ApiController]
    public class ImportReceiptController : Controller
    {
        private readonly IImportReceiptsRepository importReceiptRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ImportReceiptController (IImportReceiptsRepository ImportReceiptRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.importReceiptRepository = ImportReceiptRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("/api/phieunhap/taoma")]
        public async Task<PhieunhapResource> GetPhieunhaps()
        {
            var PhieunhapResource = new PhieunhapResource();
            PhieunhapResource.ID = await importReceiptRepository.GenerateID();
            return PhieunhapResource;
        }

        [HttpPost("/api/phieunhap/add")]
        public async Task<IActionResult> AddPhieunhap(ImportReceipt importReceipt)
        {
            if (importReceipt == null)
            {
                return BadRequest();
            }
            await importReceiptRepository.AddImportReceipt(importReceipt);
            await unitOfWork.CompleteAsync();
            return StatusCode(201);
        }
    }
}