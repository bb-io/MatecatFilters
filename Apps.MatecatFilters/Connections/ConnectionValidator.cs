using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;

namespace Apps.MatecatFilters.Connections;

public class ConnectionValidator: IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        CancellationToken cancellationToken)
    {
        return new()
        {
            IsValid = true
        };
    }
}