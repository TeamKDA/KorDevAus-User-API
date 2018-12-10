using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Kda.User.FunctionApp.Models;

namespace Kda.User.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for responses.
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// Build the response.
        /// </summary>
        /// <typeparam name="TResponse">Type of response.</typeparam>
        /// <typeparam name="TEntity">Type of entity.</typeparam>
        /// <param name="entity">Entity for the response.</param>
        /// <returns>The response.</returns>
        public static async Task<TResponse> BuildResponseAync<TResponse, TEntity>(this Task<TEntity> entity) where TResponse : UserResponse<TEntity>
        {
            var instance = await entity.ConfigureAwait(false);

            var response = Activator.CreateInstance<TResponse>();
            response.User = instance;

            return response;
        }

        /// <summary>
        /// Build the response.
        /// </summary>
        /// <typeparam name="TResponse">Type of response.</typeparam>
        /// <typeparam name="TEntity">Type of entity.</typeparam>
        /// <param name="entities">List of the entities for the response.</param>
        /// <returns>The response.</returns>
        public static async Task<TResponse> BuildResponseAync<TResponse, TEntity>(this Task<List<TEntity>> entities) where TResponse : UserCollectionResponse<TEntity>
        {
            var instances = await entities.ConfigureAwait(false);

            var response = Activator.CreateInstance<TResponse>();
            response.Users = instances;

            return response;
        }
    }
}