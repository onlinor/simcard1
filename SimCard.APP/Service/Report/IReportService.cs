using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

using SimCard.APP.ViewModels;

namespace SimCard.APP.Service
{
    public interface IReportService
    {
        Task<List<ExpandoObject>> GetReport(int type, ReportFilterViewModel filter);

        Task<ExpandoObject> GetFilterData(int type);
    }
}