using System;

namespace scg.Utils
{
    public static class StringExtensions
    {
        public static string ReplaceFirst(this string text, string oldValue, string newValue)
        {
            var pos = text.IndexOf(oldValue, StringComparison.InvariantCulture);
            return pos < 0 
                ? text 
                : text.Substring(0, pos) + newValue + text.Substring(pos + oldValue.Length);
        }

        public static string ReplaceLeading(this string text, string oldValue, string newValue)
        {
            if (oldValue.Equals(newValue)) return text;
            while (text.StartsWith(oldValue)) text = text.ReplaceFirst(oldValue, newValue);
            return text;
        }
    }
}
