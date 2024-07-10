using Apps.MatecatFilters.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Apps.MatecatFilters.Api
{
    public class FiltersRequest : BlackBirdRestRequest
    {
        public FiltersRequest(string endpoint, Method method, IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders) : base(endpoint, method, authenticationCredentialsProviders)
        {
            
        }

        protected override void AddAuth(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            var apiKey = authenticationCredentialsProviders.First(p => p.KeyName == CredsNames.RapidApiKey).Value;

            this.AddHeader("x-rapidapi-host", "translated-matecat-filters-v1.p.rapidapi.com");
            this.AddHeader("x-rapidapi-key", apiKey);
        }
    }
}
