namespace Electrolux.Api.ODataApi.Dto
{
    public class BackEndApiDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public object MiddleName { get; set; }
        public string LastName { get; set; }
        public object NickName { get; set; }
        public string Birthdate { get; set; }
        public string Status { get; set; }
        public string RoleCode { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public Personalinfo PersonalInfo { get; set; }
        public Address[] Addresses { get; set; }
        public Externalsystemids ExternalSystemIds { get; set; }
        public object SystemSettings { get; set; }
        public Metadata Metadata { get; set; }
        public string CreatedAt { get; set; }
        public string LastUpdatedDate { get; set; }
    }

    public class ContactDetails
    {
        public string Email { get; set; }
        public Phone Phone { get; set; }
    }

    public class Phone
    {
        public Main Main { get; set; }
        public Mobile Mobile { get; set; }
    }

    public class Main
    {
        public string Number { get; set; }
        public string Normalized { get; set; }
    }

    public class Mobile
    {
        public string Number { get; set; }
        public string Normalized { get; set; }
    }

    public class Personalinfo
    {
        public Title Title { get; set; }
        public Gender Gender { get; set; }
        public Preferredlanguage PreferredLanguage { get; set; }
        public object Nationality { get; set; }
        public Relationalstatus RelationalStatus { get; set; }
    }

    public class Title
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }

    public class Gender
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }

    public class Preferredlanguage
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }

    public class Relationalstatus
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }

    public class Externalsystemids
    {
        public C4C C4C { get; set; }
    }

    public class C4C
    {
        public string ID { get; set; }
        public string ObjectID { get; set; }
    }

    public class Metadata
    {
        public Source Source { get; set; }
    }

    public class Source
    {
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public string LastUpdatedAt { get; set; }
    }

    public class Address
    {
        public string Type { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public object State { get; set; }
        public object District { get; set; }
        public object County { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public object Building { get; set; }
        public object Floor { get; set; }
        public object Room { get; set; }
        public string PostalName { get; set; }
    }

}
