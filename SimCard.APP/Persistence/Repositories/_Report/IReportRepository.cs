using SimCard.API.Controllers.Resources;

using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace SimCard.API.Persistence.Repositories
{
    public interface IReportRepository
    {
        Task<List<ExpandoObject>> GetReport(int type, ReportFilterResource filter);

        Task<ExpandoObject> GetFilterData(int type);
    }
}