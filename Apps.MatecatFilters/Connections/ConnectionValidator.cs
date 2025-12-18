using Apps.MatecatFilters.Api;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.MatecatFilters.Connections;

public class ConnectionValidator : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        CancellationToken cancellationToken)
    {
        try
        {
            var request = new FiltersRequest("/api/v2/original2xliff", Method.Post, authenticationCredentialsProviders).WithFormData(new
            {
                sourceLocale = "en-GB",
                targetLocale = "it-IT",
            }, isMultipartFormData: true).WithFile(new byte[1], "test.txt", "document");

            var client = new FiltersClient();
            RestResponse restResponse = await client.ExecuteAsync(request);

            if (!restResponse.IsSuccessStatusCode)
            {
                return new ConnectionValidationResponse
                {
                    IsValid = false,
                    Message = restResponse?.ErrorMessage
                };
            }
            return new ConnectionValidationResponse
            {
                IsValid = true
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                IsValid = false,
                Message = ex.Message
            };
        }
    }
}