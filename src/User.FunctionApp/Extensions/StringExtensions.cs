using System;
using System.Collections.Generic;
using System.Linq;

namespace Kda.User.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for <c>string</c>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks whether the source contains the value or not, regardless of casing.
        /// </summary>
        /// <param name="source">List of string values.</param>
        /// <param name="value">Value to check.</param>
        /// <returns><c>True</c>, if the source contains the value; otherwise returns <c>False</c>.</returns>
        public static bool ContainsEquivalentTo(this IEnumerable<string> source, string value)
        {
            var contains = source.Contains(value, StringComparer.CurrentCultureIgnoreCase);

            return contains;
        }

        /// <summary>
        /// Checks whether the source string is equivalent to the value or not, regardless of casing.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <param name="value">Value to check.</param>
        /// <returns><c>True</c>, if the source string is equivalent to the value; otherwise returns <c>False</c>.</returns>
        public static bool IsEquivalentTo(this string source, string value)
        {
            var equals = source.Equals(value, StringComparison.CurrentCultureIgnoreCase);

            return equals;
        }

        /// <summary>
        /// Formats the given string with arguments.
        /// </summary>
        /// <param name="value">String contains placeholders.</param>
        /// <param name="args">List of arguments to replace placeholders.</param>
        /// <returns>Formatted string.</returns>
        public static string WithFormat(this string value, params object[] args)
        {
            var formatted = string.Format(value, args);

            return formatted;
        }

        /// <summary>
        /// Converts the string into <see cref="DateTimeOffset"/> value.
        /// </summary>
        /// <param name="value">Date/time value in string format.</param>
        /// <returns><see cref="DateTimeOffset"/> value converted.</returns>
        public static DateTimeOffset ToDateTimeOffset(this string value)
        {
            if (DateTimeOffset.TryParse(value, out DateTimeOffset result))
            {
                return result;
            }

            throw new InvalidCastException("Invalid DateTimeOffset string value");
        }
    }
}