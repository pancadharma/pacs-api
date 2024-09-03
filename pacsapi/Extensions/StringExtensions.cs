using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BpjsApiCore.Extensions
{
    public static class StringExtensions
    {
        public static bool IsPhoneNumber(this string number)
        {
            return Regex.Match(number, @"^\+\d{1,13}$").Success;
        }

        public static bool IsValidDate(this string value)
        {
            return DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out _);
        }

        public static bool IsNotBackDate(this string value)
        {
            var success = DateTime.TryParse(value, out DateTime date);

            if (!success) return true;

            return date >= DateTime.Today;
        }

        public static bool IsNotAfterDate(this string value)
        {
            var success = DateTime.TryParse(value, out DateTime date);

            if (!success) return true;

            return date < DateTime.Today;
        }
    }
}
