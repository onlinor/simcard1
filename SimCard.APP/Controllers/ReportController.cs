using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Persistence;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace SimCard.APP.Controllers
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
        public async Task<ReportDataViewModel> GetReport([FromBody] ReportFilterViewModel filter, int type)
        {
            ReportDataViewModel result = new ReportDataViewModel
            {
                Data = await GetReport(type, filter)
            };
            result.Columns = GetKeysFromObject(result.Data[0]);
            result.FilterData = await GetFilterData(type);
            result.SupportedFilters = GetKeysFromObject(result.FilterData);
            return result;
        }

        private async Task<List<ExpandoObject>> GetReport(int type, ReportFilterViewModel filter)
        {
            return await _reportRepository.GetReport(type, filter);
        }

        private async Task<ExpandoObject> GetFilterData(int type)
        {
            return await _reportRepository.GetFilterData(type);
        }

        private List<string> GetKeysFromObject(ExpandoObject data)
        {
            List<string> result = new List<string>();
            foreach (KeyValuePair<string, object> property in data)
            {
                result.Add(property.Key);
            }
            return result;
        }
    }
}