using System;

namespace Kda.User.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for <c>string</c>.
    /// </summary>
    public static class StringExtensions
    {
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