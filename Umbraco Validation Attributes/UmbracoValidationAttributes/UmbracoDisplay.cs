using System;
using System.ComponentModel;

namespace UmbracoValidationAttributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class UmbracoDisplayName : DisplayNameAttribute
    {
        private readonly string _dictionaryKey;

        // This is a positional argument
        public UmbracoDisplayName(string dictionaryKey)
        {
            _dictionaryKey = dictionaryKey;
        }

        public override string DisplayName
        {
            get
            {
                // 20170907RBP - Use validation helper method which falls backs to 
                // key if there is no dictionary item
                return UmbracoValidationHelper.GetDictionaryItem(_dictionaryKey);
                //return UmbracoValidationHelper.UmbracoHelper.GetDictionaryValue(_dictionaryKey);
            }
        }
    }
}
