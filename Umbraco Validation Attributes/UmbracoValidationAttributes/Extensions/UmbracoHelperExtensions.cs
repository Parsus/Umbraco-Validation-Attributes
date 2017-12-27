using System.Collections.Generic;
using Umbraco.Core;
using Umbraco.Web;

namespace UmbracoValidationAttributes.Extensions {

    public static class UmbracoHelperExtensions {

        /// <summary>
        /// This method is terribly overloaded:
        /// </summary>
        /// <param name="umbraco"></param>
        /// <param name="keyOrFallback"></param>
        /// <param name="fallbackOrFirstFormatArg"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string GetCachedDictionaryValueOrFallback(this UmbracoHelper umbraco, 
           
           string key,
           string altText,
           params object[] args) {

            var cacheKey = string.Concat("PinkDictionary_",
                key, 
                "_",
                altText);

            var result = ApplicationContext.Current.ApplicationCache.RuntimeCache
                .GetCacheItem(cacheKey,
                () => umbraco.GetDictionaryValue(key, altText))
                .ToString();

            if(args != null && args.Length > 0) { 
                result = string.Format(result, args);
            }

            return result;
        }
    }
}
