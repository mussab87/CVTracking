using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReportViewerCore
{
    public class ReportPreviousEmployment
    {
        public string Period { get; set; }
        public string CountryOfEmployment { get; set; }
        public string CountryOfEmploymentArabic { get; set; }
        public string Position { get; set; }

        public string? PositionAr { get; set; }

    }
}
