using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.MatecatFilters;

public class Application : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.Utilities];
        set { }
    }

    public string Name
    {
        get => "Matecat Filters";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}