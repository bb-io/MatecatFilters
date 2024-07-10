using Apps.MatecatFilters.Api;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;

namespace Apps.MatecatFilters.Invocables;

public class FiltersInvocable : BaseInvocable
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected FiltersClient Client { get; }
    protected readonly IFileManagementClient FileManagementClient;

    public FiltersInvocable(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(invocationContext)
    {
        Client = new();
        FileManagementClient = fileManagementClient;
    }
}