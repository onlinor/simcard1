using System;
using System.Collections.Generic;
using System.Dynamic;

namespace SimCard.APP.Controllers.Resources
{
    public class ReportDataResource
    {
        public List<ExpandoObject> Data { get; set; }

        public List<String> Columns { get; set; }

        public List<String> SupportedFilters { get; set; }

        public ExpandoObject FilterData { get; set; }
    }
}