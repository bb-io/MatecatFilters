using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.MatecatFilters.Models;

public class FileResponse
{
    [Display("File")]
    public FileReference File { get; set; }
}
