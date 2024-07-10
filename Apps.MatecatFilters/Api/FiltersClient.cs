using Apps.MatecatFilters.Dtos;
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

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        if (response.Content == null)
            throw new Exception(response.ErrorMessage);

        var error = JsonConvert.DeserializeObject<BaseDto>(response.Content, JsonSettings);

        return new(error.ErrorMessage);
    }
}