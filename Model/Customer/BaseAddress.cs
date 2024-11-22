namespace Electrolux.Api.ODataApi.Model.Customer
{
    public abstract class BaseAddress
    {
        public string? Line1 { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public string? Postcode { get; set; }
        public string? Country { get; set; }
    }

    public class Address : BaseAddress
    {

    }

    public class BillingAddress : BaseAddress
    {

    }
}
