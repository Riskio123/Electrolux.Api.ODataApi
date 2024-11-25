using Flurl.Http;

namespace Electrolux.Api.ODataApi.ApiClient.Interfaces
{
    public interface IBackEndApiClientFactory
    {
        IFlurlClient CreateClient();
    }
}
