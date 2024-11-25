using Electrolux.Api.ODataApi.OData;
using System.Text.Json;

namespace Electrolux.Api.ODataApi.Mock
{
    public class MockApiFactory
    {
        public static object BuildMockQuery(string filterType, ODataFilter oDataFilter)
        {
            var query = new
            {
                query = new
                {
                    or = new object[]
                    {
                    new {
                        field = filterType switch
                        {
                            "Email" => "contactDetails.email",
                            "Id" => "externalSystemIds.C4C.ID",
                            "Phone" => "contactDetails.phone.mobile.number",
                            _ => throw new ArgumentException("Invalid filter type", nameof(filterType))
                        },
                        @operator = oDataFilter.Operator,
                        value = oDataFilter.Value
                    }
                    },
                    and = new object[]
                    {
                    new { field = "roleCode", @operator = "eq", value = "Customer" },
                    new { field = "status", @operator = "eq", value = "Active" }
                    }
                },
                fields = new[]
                {
                "externalSystemIds.C4C.ID",
                "personalInfo.title.value",
                "firstName",
                "lastName",
                "addresses",
                "contactDetails.phone.main.number",
                "contactDetails.phone.mobile.number",
                "contactDetails.email",
                "personalInfo.preferredLanguage.code"
            },
                sort = new[]
                {
                new { field = "ETag", order = "desc" }
            },
                pagination = new[]
                {
                new { cursorId = "659fd17b2e040abd09b2d774", size = "20" }
            }
            };

            return query;
            //return JsonSerializer.Serialize(query, new JsonSerializerOptions
            //{
            //    WriteIndented = true
            //});
        }
    }

}
