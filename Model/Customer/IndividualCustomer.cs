namespace Electrolux.Api.ODataApi.Model.Customer
{
    public class IndividualCustomer
    {
        public int Id { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public SubScriptionSetting[] SubscriptionSettings { get; set; }
        public string AssociatedId { get; set; }
        public string FormOfAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Locale { get; set; }
        public string SourceApplication { get; set; }
        public bool IsPending { get; set; }
        public bool IsNewsletterSubscription { get; set; }

    }
}
