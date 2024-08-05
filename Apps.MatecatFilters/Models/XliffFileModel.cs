using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.MatecatFilters.Models;

public class XliffFileModel
{
    [Display("XLIFF File")]
    public FileReference XliffFile { get; set; }
}
