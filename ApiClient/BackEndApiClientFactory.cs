using Electrolux.Api.ODataApi.ApiClient.Configuration;
using Electrolux.Api.ODataApi.ApiClient.Interfaces;
using Flurl.Http;

namespace Electrolux.Api.ODataApi.ApiClient
{
    public class BackendApiClientFactory : IBackEndApiClientFactory
    {
        private readonly BackEndApiClientConfig _config;

        public BackendApiClientFactory(BackEndApiClientConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public IFlurlClient CreateClient()
        {
            var client = new FlurlClient(_config.BaseUrl)
                .WithHeader("Ocp-Apim-Subscription-Key", _config.SecretKey)
                .WithTimeout(TimeSpan.FromSeconds(30)); 

            return client;
        }
    }

}
