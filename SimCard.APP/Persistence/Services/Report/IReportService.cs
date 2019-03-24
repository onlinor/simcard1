using SimCard.APP.ViewModels;

using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Services
{
    public interface IReportService
    {
        Task<List<ExpandoObject>> GetReport(int type, ReportFilterViewModel filter);

        Task<ExpandoObject> GetFilterData(int type);
    }
}