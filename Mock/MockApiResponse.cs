using Electrolux.Api.ODataApi.Dto;
using Electrolux.Api.ODataApi.OData;

namespace Electrolux.Api.ODataApi.Mock
{
    public class MockApiResponse
    {
        public static BackEndApiResponseDto<BackEndApiDto> GenerateMockResponse(string filterType, ODataFilter oDataFilter, int numberOfRecords)
        {
            var records = new List<BackEndApiDto>();

            for (int i = 0; i < numberOfRecords; i++)
            {
                records.Add(new BackEndApiDto
                {
                    Id = new Random().Next(1, 1000000),
                    FirstName = $"FirstName{i + 1}",
                    MiddleName = null,
                    LastName = $"LastName{i + 1}",
                    NickName = $"Nick{i + 1}",
                    Birthdate = $"198{i + 1}-06-15",
                    Status = "Active",
                    RoleCode = "Customer",
                    ContactDetails = new ContactDetails
                    {
                        Email = $"user{i + 1}@test.com",
                        Phone = new Phone
                        {
                            Main = new Main
                            {
                                Number = $"+1 123-456-78{i:D2}90",
                                Normalized = $"+112345678{i:D2}90"
                            },
                            Mobile = new Mobile
                            {
                                Number = $"+1 987-654-32{i:D2}10",
                                Normalized =  $"+198765432{i:D2}10"
                            }
                        }
                    },
                    PersonalInfo = new Personalinfo
                    {
                        Title = new Title { Code = "Mr", Value = "Mister" },
                        Gender = new Gender { Code = i % 2 == 0 ? "M" : "F", Value = i % 2 == 0 ? "Male" : "Female" },
                        PreferredLanguage = new Preferredlanguage { Code = "EN", Value = "English" },
                        Nationality = null,
                        RelationalStatus = new Relationalstatus { Code = "Single", Value = "Single" }
                    },
                    Addresses = new[]
                    {
                new Address
                {
                    Type = "Billing",
                    Street = $"{i + 1} Mockingbird Lane",
                    City = "Springfield",
                    State = "Illinois",
                    District = null,
                    County = "Mock County",
                    PostalCode = $"6270{i:D2}",
                    Country = "United States",
                    Building = $"Apt {101 + i}",
                    Floor = null,
                    Room = null,
                    PostalName = $"FirstName{i + 1} LastName{i + 1}"
                }
            },
                    ExternalSystemIds = new Externalsystemids
                    {
                        C4C = new C4C
                        {
                            ID =  Guid.NewGuid().ToString(),
                            ObjectID = $"Object{456789 + i}"
                        }
                    },
                    SystemSettings = null,
                    Metadata = new Metadata
                    {
                        Source = new Source
                        {
                            CreatedBy = "Admin",
                            CreatedAt = DateTime.UtcNow.AddDays(-10).ToString("o"),
                            LastUpdatedBy = $"User{i + 1}",
                            LastUpdatedAt = DateTime.UtcNow.AddDays(-i).ToString("o")
                        }
                    },
                    CreatedAt = DateTime.UtcNow.AddDays(-10).ToString("o"),
                    LastUpdatedDate = DateTime.UtcNow.AddDays(-i).ToString("o")
                });
            }

            return new BackEndApiResponseDto<BackEndApiDto>
            {
                Success = true,
                Records = new Records<BackEndApiDto>
                {
                    Data = records,
                    PageInfo = new PageInfo { HasNextPage = false }
                }
            };
        }

    }
}
