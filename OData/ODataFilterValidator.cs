using Electrolux.Api.ODataApi.Enum;
using System.Text.RegularExpressions;

namespace Electrolux.Api.ODataApi.OData
{
    public class ODataFilterValidator
    {
        public static bool IsValidId(string id)
        {
            return int.TryParse(id, out var intId) && intId > 0;
        }

        public static bool IsValidPhone(string phone)
        {
            var phonePattern = @"^\+\d{10,15}$"; 
            return Regex.IsMatch(phone, phonePattern);
        }

        public static bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        public static bool ValidateFilter(FilterType? filterType, string value)
        {
            return filterType switch
            {
                FilterType.Id => IsValidId(value),
                FilterType.Phone => IsValidPhone(value),
                FilterType.Email => IsValidEmail(value),
                _ => false 
            };
        }
    }
}
