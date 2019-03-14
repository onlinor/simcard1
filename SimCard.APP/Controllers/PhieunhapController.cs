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
using SimCard.API.Persistence.Repositories._Phieunhap;

namespace SimCard.API.Controllers
{
    [ApiController]
    public class PhieunhapController : Controller
    {
        private readonly IPhieunhapRepository PhieunhapRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PhieunhapController (IPhieunhapRepository PhieunhapRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.PhieunhapRepository = PhieunhapRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("/api/phieunhap/taoma")]
        public async Task<PhieunhapResource> GetPhieunhaps()
        {
            var PhieunhapResource = new PhieunhapResource();
            PhieunhapResource.ID = await PhieunhapRepository.GenerateID();
            return PhieunhapResource;
        }

        [HttpPost("/api/phieunhap/add")]
        public async Task<IActionResult> AddPhieunhap(Phieunhap phieunhap)
        {
            if (phieunhap == null)
            {
                return BadRequest();
            }
            await PhieunhapRepository.AddPhieunhap(phieunhap);
            await unitOfWork.CompleteAsync();
            return StatusCode(201);
        }
    }
}