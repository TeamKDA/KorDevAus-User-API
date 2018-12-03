using System.Collections.Generic;

using Newtonsoft.Json;

namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the list of users from Azure AD B2C Graph API.
    /// </summary>
    public class AdalUserCollection
    {
        /// <summary>
        /// Gets or sets the OData metadata.
        /// </summary>
        [JsonProperty("odata.metadata", Order = 1)]
        public virtual string OdataMetadata { get; set; }

        /// <summary>
        /// Gets or sets the list of users from ADAL REST API.
        /// </summary>
        [JsonProperty(Order = 2)]
        public virtual List<AdalUser> Value { get; set; }
    }
}