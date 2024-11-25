using Electrolux.Api.ODataApi.Dto;

namespace Electrolux.Api.ODataApi.ApiClient.Interfaces
{
    public interface IBackEndApiClient
    {
        Task<BackEndApiResponseDto<BackEndApiDto>> GetCustomerDataAsync(object requestBody);
    }
}
