using System;

namespace scg.Utils
{
    public static class StringExtensions
    {
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            var pos = text.IndexOf(search, StringComparison.InvariantCulture);
            return pos < 0 
                ? text 
                : text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}
