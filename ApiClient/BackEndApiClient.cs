using Electrolux.Api.ODataApi.ApiClient.Interfaces;
using Electrolux.Api.ODataApi.Dto;
using Flurl.Http;

namespace Electrolux.Api.ODataApi.ApiClient
{
    public class BackEndApiClient : IBackEndApiClient
    {
        private readonly IBackEndApiClientFactory _clientFactory;

        public BackEndApiClient(IBackEndApiClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<BackEndApiResponseDto<BackEndApiDto>> GetCustomerDataAsync(object requestBody)
        {
            var client = _clientFactory.CreateClient();

            var response = await client
                .Request("customers") 
                .PostJsonAsync(requestBody)
                .ReceiveJson<BackEndApiResponseDto<BackEndApiDto>>();

            return response;
        }
    }

}
