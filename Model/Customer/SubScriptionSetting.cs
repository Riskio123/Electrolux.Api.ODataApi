namespace Electrolux.Api.ODataApi.Model.Customer
{
    public class SubScriptionSetting
    {
        public string Brand { get; set; }
        public string CountryCode { get; set; }
        public bool OptInDAndG { get; set; }
        public bool OptInElectrolux { get; set; }
        public bool WantsNewsletter { get; set; }
    }
}
