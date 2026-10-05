using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Collections.src
{
    public static class StringValidationExtensions
    {
        private static readonly Regex PhoneRegex = new Regex(@"^(?:0|\+20)(?:10|11|12|15)\d{8}$", RegexOptions.Compiled);
        private static readonly Regex NationalIdRegex = new Regex(@"^[23]\d{13}$", RegexOptions.Compiled);

        
        public static bool IsValidEgyptianPhone(this string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }

            return PhoneRegex.IsMatch(phone);
        }

        public static bool IsValidEgyptianNationalId(this string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            return NationalIdRegex.IsMatch(id);
        }
    }
}
