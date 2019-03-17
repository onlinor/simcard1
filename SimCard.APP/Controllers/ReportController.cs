using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimCard.API.Controllers.Resources;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories;
using SimCard.APP.Controllers.Resources;

namespace SimCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportController(IReportRepository reportRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("/api/Report/GetReport")]
        public async Task<ReportDataResource> GetReport([FromBody] ReportFilterResource filter, int type)
        {
            var result = new ReportDataResource();
            result.Data = await GetReport(type, filter);
            result.FilterData = await GetFilterData(type);
            result.SupportedFilters = GetKeyFromObject(result.FilterData);
            result.Columns = GetKeyFromObject(result.Data[0]);
            return result;
        }

        private async Task<List<ExpandoObject>> GetReport(int type, ReportFilterResource filter)
        {
            return await _reportRepository.GetReport(type, filter);
        }

        private async Task<ExpandoObject> GetFilterData(int type)
        {
            return await _reportRepository.GetFilterData(type);
        }

        private List<String> GetKeyFromObject(ExpandoObject data)
        {
            var result = new List<String>();
            foreach (var property in (IDictionary<String, Object>)data)
            {
                result.Add(property.Key);
            }
            return result;
        }
    }
}