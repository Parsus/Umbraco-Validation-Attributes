using System.ComponentModel.DataAnnotations;

namespace UmbracoValidationAttributes {
    public static class ValidationAttributeExtensions {
        static public void TrySetErrorMessage(this ValidationAttribute attr, string dictionaryKey) {
            if(string.IsNullOrEmpty(dictionaryKey)) { return; }

            var item = UmbracoValidationHelper.GetDictionaryItem(dictionaryKey);

            if (item != dictionaryKey) {
                // dictionaryKey has entry in dictionary, use entry value as error message
                attr.ErrorMessage = item;
            } else {
                // dictionaryKey does not have entry in dictionary, assume it is error message
                attr.ErrorMessage = dictionaryKey;
            }
        }
    }
}
 