using System;

using Kda.User.FunctionApp.Handlers;
using Kda.User.FunctionApp.Providers;

using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Kda.User.FunctionApp.Extensions
{
    /// <summary>
    /// This represents the extension entity for the <see cref="MsalGraphServiceHandler"/> class.
    /// </summary>
    public static class GraphServiceHandlerExtensions
    {
        /// <summary>
        /// Add <see cref="ClientCredential"/> instance.
        /// </summary>
        /// <typeparam name="T">Type of credential.</typeparam>
        /// <param name="handler"><see cref="IGraphServiceHandler"/> instance.</param>
        /// <returns><see cref="IGraphServiceHandler"/> instance.</returns>
        public static IGraphServiceHandler WithMsalCredential<T>(this IGraphServiceHandler handler)
        {
            if (!typeof(T).Equals(typeof(Microsoft.Identity.Client.ClientCredential)))
            {
                throw new InvalidOperationException("Type mismatch");
            }

            handler.AddCredential();

            return handler;
        }

        /// <summary>
        /// Add <see cref="ClientCredential"/> instance.
        /// </summary>
        /// <typeparam name="T">Type of credential.</typeparam>
        /// <param name="handler"><see cref="IGraphServiceHandler"/> instance.</param>
        /// <returns><see cref="IGraphServiceHandler"/> instance.</returns>
        public static IGraphServiceHandler WithAdalCredential<T>(this IGraphServiceHandler handler)
        {
            if (!typeof(T).Equals(typeof(Microsoft.IdentityModel.Clients.ActiveDirectory.ClientCredential)))
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
        public static IGraphServiceHandler WithMsalClientApplication<T>(this IGraphServiceHandler handler)
        {
            if (!typeof(T).Equals(typeof(ConfidentialClientApplication)))
            {
                throw new InvalidOperationException("Type mismatch");
            }

            handler.AddClientApplication();

            return handler;
        }

        /// <summary>
        /// Add <see cref="AuthenticationContext"/> instance.
        /// </summary>
        /// <typeparam name="T">Type of client application.</typeparam>
        /// <param name="handler"><see cref="IGraphServiceHandler"/> instance.</param>
        /// <returns><see cref="IGraphServiceHandler"/> instance.</returns>
        public static IGraphServiceHandler WithAdalClientApplication<T>(this IGraphServiceHandler handler)
        {
            if (!typeof(T).Equals(typeof(AuthenticationContext)))
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
        public static IGraphServiceHandler WithMsalProvider<T>(this IGraphServiceHandler handler)
        {
            if (!typeof(T).Equals(typeof(MsalAuthenticationProvider)))
            {
                throw new InvalidOperationException("Type mismatch");
            }

            handler.AddAuthenticationProvider();

            return handler;
        }

        /// <summary>
        /// Add <see cref="AdalAuthenticationProvider"/> instance.
        /// </summary>
        /// <typeparam name="T">Type of authentication provider.</typeparam>
        /// <param name="handler"><see cref="IGraphServiceHandler"/> instance.</param>
        /// <returns><see cref="IGraphServiceHandler"/> instance.</returns>
        public static IGraphServiceHandler WithAdalProvider<T>(this IGraphServiceHandler handler)
        {
            if (!typeof(T).Equals(typeof(AdalAuthenticationProvider)))
            {
                throw new InvalidOperationException("Type mismatch");
            }

            handler.AddAuthenticationProvider();

            return handler;
        }
    }
}