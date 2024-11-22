using Electrolux.Api.ODataApi.Dto;
using Electrolux.Api.ODataApi.Enum;
using Electrolux.Api.ODataApi.Mock;
using Electrolux.Api.ODataApi.Model.Customer;
using Electrolux.Api.ODataApi.OData;
using Electrolux.Api.ODataApi.Services.Interfaces;
using Microsoft.AspNetCore.OData.Query;

namespace Electrolux.Api.ODataApi.Services
{
    public class IndividualCustomerService : IIndividualCustomerService
    {
        public Task<IEnumerable<IndividualCustomer>> GetIndividualCustomerCollectionByFilter(ODataQueryOptions queryOptions)
        {
            var filter = queryOptions.Filter?.RawValue;
            var filterType = GetFilterType(filter);

            if (filterType == null)
            {
                throw new ArgumentException("Invalid or missing filter");
            }

            var oDataHelper = new ODataHelper();
            var oDataFilter = oDataHelper.ConvertODataToBackendQueryFilter(queryOptions.Filter.FilterClause);

            var mockQuery = MockApiFactory.BuildMockQuery(filterType.ToString(), oDataFilter);

            //simulate httpRequest for backEndApi
            Task.Delay(100).Wait();

            var mockResponse = MockApiResponse.GenerateMockResponse(filterType.ToString(), oDataFilter, 5);

            if (!mockResponse.Success)
                throw new Exception("Error in backend API response");

             var transformedResponse = mockResponse.Records.Data.Select(x=> new IndividualCustomer
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                ContactDetails = new Model.Customer.ContactDetails
                {
                    Phone = x.ContactDetails.Phone.Mobile.Normalized,
                    Address =new Model.Customer.Address {
                        City= x.Addresses.Where(a=> a.Type=="main").FirstOrDefault()?.City,
                        Country = x.Addresses.Where(a => a.Type == "main").FirstOrDefault()?.Country,
                        Postcode = x.Addresses.Where(a => a.Type == "main").FirstOrDefault()?.PostalCode
                    },
                    BillingAddress = new Model.Customer.BillingAddress
                    {
                        City = x.Addresses.Where(a => a.Type == "Billing").FirstOrDefault()?.City,
                        Country = x.Addresses.Where(a => a.Type == "Billing").FirstOrDefault()?.Country,
                        Postcode = x.Addresses.Where(a => a.Type == "Billing").FirstOrDefault()?.PostalCode
                    }

                },
                EmailAddress = x.ContactDetails.Email


            });
            

            return Task.FromResult(transformedResponse);
        }

        private FilterType? GetFilterType(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return null;
            }

            if (filter.Contains("id", StringComparison.OrdinalIgnoreCase))
            {
                return FilterType.Id;
            }
            if (filter.Contains("email", StringComparison.OrdinalIgnoreCase))
            {
                return FilterType.Email;
            }
            if (filter.Contains("phone", StringComparison.OrdinalIgnoreCase))
            {
                return FilterType.Phone;
            }

            return null;
        }
    }
}
