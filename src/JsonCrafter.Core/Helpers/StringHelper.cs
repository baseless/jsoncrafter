using System.Text.RegularExpressions;

namespace JsonCrafter.Core.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// Validates that the string does not contain anything but alphanumeric characters.
        /// </summary>
        /// <param name="str">The string to be validated.</param>
        /// <returns>True / false whether or not the string is plain alpahumerical.</returns>
        public static bool IsPlainText(this string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z0-9]+$");
        }
    }
}
