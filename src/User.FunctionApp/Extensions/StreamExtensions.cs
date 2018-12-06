using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Kda.User.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the <see cref="Stream"/> class.
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Reads the stream and convert it into the designated typed instance
        /// </summary>
        /// <typeparam name="T">Type of instance to be deserialised.</typeparam>
        /// <param name="stream"><see cref="Stream"/> instance.</param>
        /// <returns>Deserialised instance.</returns>
        public static async Task<T> ReadAsAsync<T>(this Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var serialised = await reader.ReadToEndAsync().ConfigureAwait(false);
                var deserialised = JsonConvert.DeserializeObject<T>(serialised);

                return deserialised;
            }
        }
    }
}