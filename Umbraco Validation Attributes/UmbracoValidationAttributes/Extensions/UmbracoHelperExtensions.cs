using Umbraco.Core;
using Umbraco.Web;

namespace UmbracoValidationAttributes.Extensions {

    public static class UmbracoHelperExtensions {

        public static string GetCachedDictionaryValueOrFallback(this UmbracoHelper umbraco, string key,
           string fallback,
           params object[] args) {

            var value = ApplicationContext.Current.ApplicationCache.RuntimeCache
                .GetCacheItem("PinkDictionary_" + key,
                () => {
                    var result = umbraco.GetDictionaryValue(key, fallback ?? key);
                    if (args != null && args.Length > 0) {
                        result = string.Format(result, args);
                    }

                    return result;
                });

            return value.ToString();
        }
    }
}
