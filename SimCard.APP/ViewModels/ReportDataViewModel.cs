using System.Collections.Generic;
using System.Dynamic;

namespace SimCard.APP.ViewModels
{
    public class ReportDataViewModel
    {
        public List<ExpandoObject> Data { get; set; }

        public List<string> Columns { get; set; }

        public List<string> SupportedFilters { get; set; }

        public ExpandoObject FilterData { get; set; }
    }
}