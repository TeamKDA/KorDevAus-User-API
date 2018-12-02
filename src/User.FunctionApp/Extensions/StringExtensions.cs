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
    }
}