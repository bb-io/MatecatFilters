using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.MatecatFilters.DataSourceHandlers;

public class SegmentationDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            { "paragraph", "Paragraph" },
            { "patent", "Patent" }
        };
    }
}
