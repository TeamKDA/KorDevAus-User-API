//using System;

//using Kda.User.FunctionApp.Configurations;
//using Microsoft.Identity.Client;

//namespace Kda.User.FunctionApp.Builders
//{
//    public class ConfidentialClientApplicationBuilder : IBuilder<ConfidentialClientApplication>
//    {
//        private readonly AppSettings _settings;

//        private bool _disposed;

//        public ConfidentialClientApplicationBuilder(AppSettings settings)
//        {
//            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
//        }

//        public ConfidentialClientApplication Build()
//        {
//            var authority = $"{this._settings.Auth.BaseUri.TrimEnd('/')}/{this._settings.Auth.TenantId}/{this._settings.Auth.ApiVersion}";
//            var cc = new ClientCredentialBuilder(this._settings).Build();
//            var cca = new ConfidentialClientApplication(this._settings.Auth.ClientId, authority, this._settings.Auth.RedirectUri, cc, null, null);

//            return cca;
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