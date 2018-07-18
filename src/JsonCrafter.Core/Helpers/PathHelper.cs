using System;
using System.Net;
using System.Text.RegularExpressions;

namespace JsonCrafter.Core.Helpers
{
    public static class PathHelper
    {
        public static bool IsValidTemplateUrl(this string url)
        {
            var escaped = ReplaceParameterPlaceholders(url);
            return Uri.IsWellFormedUriString(escaped, UriKind.RelativeOrAbsolute);
        }

        public static string ReplaceParameterPlaceholders(string url)
        {
            return Regex.Replace(url, "{.*?}", "a");
        }

        public static string EncodeUrl(string url)
        {
            return WebUtility.UrlEncode(url);
        }

        public static string DecodeUrl(string encodedUrl)
        {
            return WebUtility.UrlDecode(encodedUrl);
        }
        }
    }
