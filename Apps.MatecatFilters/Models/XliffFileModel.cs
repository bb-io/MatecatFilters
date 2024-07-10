using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.MatecatFilters.Models
{
    public class XliffFileModel
    {
        [Display("XLIFF File")]
        public FileReference XliffFile { get; set; }
    }
}
