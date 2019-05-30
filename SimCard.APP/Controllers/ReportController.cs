using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Persistence.Services;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("getReport")]
        public async Task<ReportDataViewModel> GetReport([FromBody] ReportFilterViewModel filter, int type)
        {
            ReportDataViewModel result = new ReportDataViewModel
            {
                Data = await GetReport(type, filter)
            };
            result.FilterData = await GetFilterData(type);
            return result;
        }

        private async Task<List<ExpandoObject>> GetReport(int type, ReportFilterViewModel filter)
        {
            return await _reportService.GetReport(type, filter);
        }

        private async Task<ExpandoObject> GetFilterData(int type)
        {
            return await _reportService.GetFilterData(type);
        }
    }
}