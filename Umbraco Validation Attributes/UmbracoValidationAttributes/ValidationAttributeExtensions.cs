using System.ComponentModel.DataAnnotations;

namespace UmbracoValidationAttributes {
    public static class ValidationAttributeExtensions {
        static public void TrySetErrorMessage(this ValidationAttribute attr, string dictionaryKey) {
            var item = UmbracoValidationHelper.GetDictionaryItem(dictionaryKey);
            if (item != dictionaryKey) {
                attr.ErrorMessage = item;
            }
        }
    }
}
