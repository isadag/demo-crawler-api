using System;
namespace demo_crawler_api.Utils
{
    public class UrlValidator
    {
        /// <summary>
        /// Validates that the string is a valid url.
        /// Expects a protocol to be set.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool ValidateUrl(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri) == false)
            {
                return false;
            }
            return uri.Scheme == Uri.UriSchemeHttp ||
                    uri.Scheme == Uri.UriSchemeHttps;
        }
    }
}
