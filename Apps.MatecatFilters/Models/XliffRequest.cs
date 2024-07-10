using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.MatecatFilters.Models
{
    public class XliffRequest
    {
        [Display("Source language", Description = "Two letter language code and two letter country code separated by a hyphen")]
        public string SourceLocale { get; set; }

        [Display("Target language", Description = "Two letter language code and two letter country code separated by a hyphen")]
        public string TargetLocale { get; set; }

        [Display("File")]
        public FileReference File { get; set; }
    }
}
