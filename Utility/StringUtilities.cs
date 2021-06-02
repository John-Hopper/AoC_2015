using System;

namespace Utility_Library
{
    public static class StringUtilities
    {
        public static bool IsNumeric(this string text)
        {
            int val;
            return Int32.TryParse(text, out val);
        }

        public static bool IsUpper(this string text)
        {
            return (text == text.ToUpper()) ? true : false;
        }
    }
}
