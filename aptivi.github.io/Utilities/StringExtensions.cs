using System;

namespace aptivi.github.io.Utilities
{
    public static class StringExtensions
    {
        /// <summary>
        /// Makes a string array with new line as delimiter
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <returns></returns>
        internal static string[] SplitNewLines(this string Str)
        {
            return Str.Replace(Convert.ToChar(13), default).Split(Convert.ToChar(10));
        }
    }
}
