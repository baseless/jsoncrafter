using System;
using System.Net;
using System.Text.RegularExpressions;
using JsonCrafter.Shared.Exceptions;

namespace JsonCrafter.Shared.Helpers
{
    public static class PathHelper
    {
        public static void EnsurePathIsValid<T>(string url)
        {
            if (!Uri.IsWellFormedUriString(ReplaceParameterPlaceholders(url), UriKind.RelativeOrAbsolute))
            {
                throw new JsonCrafterException($"Template could not be created for type '{typeof(T).FullName}' (reason: '{url}' is not a valid url).");
            }
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
