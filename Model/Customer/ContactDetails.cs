using Microsoft.AspNetCore.Http;

namespace Electrolux.Api.ODataApi.Model.Customer
{
    public class ContactDetails
    {
        public string Phone { get; set; }
        public string PhoneMobile { get; set; }
        public Address Address { get; set; }
        public BillingAddress BillingAddress { get; set; }
    }
}
