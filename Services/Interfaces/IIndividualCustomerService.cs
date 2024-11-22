using Electrolux.Api.ODataApi.Dto;
using Electrolux.Api.ODataApi.Model.Customer;
using Electrolux.Api.ODataApi.OData;
using Microsoft.AspNetCore.OData.Query;

namespace Electrolux.Api.ODataApi.Services.Interfaces
{
    public interface IIndividualCustomerService
    {
        Task<IEnumerable<IndividualCustomer>> GetIndividualCustomerCollectionByFilter(ODataQueryOptions queryOptions);
    }
}
