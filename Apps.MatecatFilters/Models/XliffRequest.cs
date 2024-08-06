using Apps.MatecatFilters.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.MatecatFilters.Models;

public class XliffRequest
{
    [Display("Source language", Description = "Two letter language code and two letter country code separated by a hyphen")]
    public string SourceLocale { get; set; }

    [Display("Target language", Description = "Two letter language code and two letter country code separated by a hyphen")]
    public string TargetLocale { get; set; }

    [Display("File")]
    public FileReference File { get; set; }

    [Display("Segmentation", Description = "Allows to choose the segmentation logic")]
    [StaticDataSource(typeof(SegmentationDataHandler))]
    public string? Segmentation { get; set; }

    [Display("Do not translate keys", Description = "Do not translate specified keys (only for JSON)")]
    public List<string>? DoNotTranslateKeys { get; set; }
}
