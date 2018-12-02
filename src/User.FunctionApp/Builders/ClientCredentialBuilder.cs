//using System;

//using Kda.User.FunctionApp.Configurations;
//using Microsoft.Identity.Client;

//namespace Kda.User.FunctionApp.Builders
//{

//    public class ClientCredentialBuilder : IBuilder<ClientCredential>
//    {
//        private readonly AppSettings _settings;

//        private bool _disposed;

//        public ClientCredentialBuilder(AppSettings settings)
//        {
//            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
//        }

//        public ClientCredential Build()
//        {
//            var cc = new ClientCredential(this._settings.Auth.ClientSecret);

//            return cc;
//        }

//        /// <summary>
//        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
//        /// </summary>
//        public void Dispose()
//        {
//            this.Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        /// <summary>
//        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
//        /// </summary>
//        /// <param name="disposing">Value indicating whether to dispose managed and/or unmanaged resources or not.</param>
//        protected void Dispose(bool disposing)
//        {
//            if (this._disposed)
//            {
//                return;
//            }

//            if (!disposing)
//            {
//                return;
//            }

//            this._disposed = true;
//        }
//    }
//}