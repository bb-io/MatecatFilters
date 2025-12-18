using Apps.MatecatFilters.Dtos;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace Apps.MatecatFilters.Api;

public class FiltersClient : BlackBirdRestClient
{
    public FiltersClient() : base(new RestClientOptions
    { ThrowOnAnyError = false, BaseUrl = new Uri("https://translated-matecat-filters-v1.p.rapidapi.com"), MaxTimeout = (int)TimeSpan.FromMinutes(5).TotalMilliseconds })
    { }

    public override async Task<T> ExecuteWithErrorHandling<T>(RestRequest request)
    {
        string content = (await ExecuteWithErrorHandling(request)).Content;
        T val = JsonConvert.DeserializeObject<T>(content, JsonSettings);
        if (val == null)
        {
            throw new Exception($"Could not parse {content} to {typeof(T)}");
        }

        return val;
    }

    public override async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request)
    {
        RestResponse restResponse = await ExecuteAsync(request);
        if (!restResponse.IsSuccessStatusCode)
        {
            throw ConfigureErrorException(restResponse);
        }

        return restResponse;
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        if (response.Content == null)
            throw new PluginApplicationException(response.ErrorMessage);

        var error = JsonConvert.DeserializeObject<BaseDto>(response.Content, JsonSettings);

        throw new PluginApplicationException(error.ErrorMessage);
    }
}