using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

namespace Kda.User.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the mappers.
    /// </summary>
    public static class MapperExtensions
    {
        /// <summary>
        /// Maps one type to another.
        /// </summary>
        /// <typeparam name="TFrom">Type of source instance.</typeparam>
        /// <typeparam name="TTo">Type of target instance.</typeparam>
        /// <param name="item">Item for mapping.</param>
        /// <param name="mapper"><see cref="IMapper"/> instance.</param>
        /// <returns>List of transformed instances.</returns>
        public static async Task<TTo> MapAsync<TFrom, TTo>(this Task<TFrom> item, IMapper mapper)
        {
            var instance = await item.ConfigureAwait(false);

            var mapped = mapper.Map<TTo>(instance);

            return mapped;
        }

        /// <summary>
        /// Maps one type to another.
        /// </summary>
        /// <typeparam name="TFrom">Type of source instance.</typeparam>
        /// <typeparam name="TTo">Type of target instance.</typeparam>
        /// <param name="items">List of items.</param>
        /// <param name="mapper"><see cref="IMapper"/> instance.</param>
        /// <returns>List of transformed instances.</returns>
        public static async Task<List<TTo>> MapAsync<TFrom, TTo>(this Task<List<TFrom>> items, IMapper mapper)
        {
            var instances = await items.ConfigureAwait(false);

            var mapped = mapper.Map<List<TTo>>(instances);

            return mapped;
        }
    }
}