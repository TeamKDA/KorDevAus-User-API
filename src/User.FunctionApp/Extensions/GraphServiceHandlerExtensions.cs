using System;

using Kda.User.FunctionApp.Handlers;
using Kda.User.FunctionApp.Providers;

using Microsoft.Identity.Client;

namespace Kda.User.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the <see cref="GraphServiceHandler"/> class.
    /// </summary>
    public static class GraphServiceHandlerExtensions
    {
        /// <summary>
        /// Add <see cref="ClientCredential"/> instance.
        /// </summary>
        /// <typeparam name="T">Type of credential.</typeparam>
        /// <param name="handler"><see cref="IGraphServiceHandler"/> instance.</param>
        /// <returns><see cref="IGraphServiceHandler"/> instance.</returns>
        public static IGraphServiceHandler WithCredential<T>(this IGraphServiceHandler handler)
        {
            if (!typeof(T).Equals(typeof(ClientCredential)))
            {
                throw new InvalidOperationException("Type mismatch");
            }

            handler.AddCredential();

            return handler;
        }

        /// <summary>
        /// Add <see cref="ConfidentialClientApplication"/> instance.
        /// </summary>
        /// <typeparam name="T">Type of client application.</typeparam>
        /// <param name="handler"><see cref="IGraphServiceHandler"/> instance.</param>
        /// <returns><see cref="IGraphServiceHandler"/> instance.</returns>
        public static IGraphServiceHandler WithClientApplication<T>(this IGraphServiceHandler handler)
        {
            if (!typeof(T).Equals(typeof(ConfidentialClientApplication)))
            {
                throw new InvalidOperationException("Type mismatch");
            }

            handler.AddClientApplication();

            return handler;
        }

        /// <summary>
        /// Add <see cref="MsalAuthenticationProvider"/> instance.
        /// </summary>
        /// <typeparam name="T">Type of authentication provider.</typeparam>
        /// <param name="handler"><see cref="IGraphServiceHandler"/> instance.</param>
        /// <returns><see cref="IGraphServiceHandler"/> instance.</returns>
        public static IGraphServiceHandler WithProvider<T>(this IGraphServiceHandler handler)
        {
            if (!typeof(T).Equals(typeof(MsalAuthenticationProvider)))
            {
                throw new InvalidOperationException("Type mismatch");
            }

            handler.AddAuthenticationProvider();

            return handler;
        }
    }
}