using System;
using System.Net;
using System.Text.RegularExpressions;
using JsonCrafter.Core;

namespace JsonCrafter.Helpers
{
    internal static class PathHelper
    {
        internal static void EnsurePathIsValid<T>(string url)
        {
            if (!Uri.IsWellFormedUriString(ReplaceParameterPlaceholders(url), UriKind.RelativeOrAbsolute))
            {
                throw new JsonCrafterException($"Template could not be created for type '{typeof(T).FullName}' (reason: '{url}' is not a valid url).");
            }
        }

        internal static string ReplaceParameterPlaceholders(string url)
        {
            return Regex.Replace(url, "{.*?}", "a");
        }

        internal static string EncodeUrl(string url)
        {
            return WebUtility.UrlEncode(url);
        }

        internal static string DecodeUrl(string encodedUrl)
        {
            return WebUtility.UrlDecode(encodedUrl);
        }
        }
    }
