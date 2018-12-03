using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Kda.User.FunctionApp.Models
{
    /// <summary>
    /// This represents the user from Azure AD B2C Graph API.
    /// </summary>
    public class AdalUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdalUser"/> class.
        /// </summary>
        public AdalUser()
        {
            this.OtherMails = new List<string>();
            this.SignInNames = new List<TypeValuePair>();
        }

        /// <summary>
        /// Gets or sets the OData type.
        /// </summary>
        [JsonProperty("odata.type", Order = 1)]
        public virtual string OdataType { get; set; }

        /// <summary>
        /// Gets or sets the object Id.
        /// </summary>
        [JsonProperty(Order = 2)]
        public virtual string ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the user principal name.
        /// </summary>
        [JsonProperty(Order = 3)]
        public virtual string UserPrincipalName { get; set; }

        /// <summary>
        /// Gets or sets the date/time when the record was created.
        /// </summary>
        [JsonProperty(Order = 4)]
        public virtual DateTimeOffset CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        [JsonProperty(Order = 5)]
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the given name.
        /// </summary>
        [JsonProperty(Order = 6)]
        public virtual string GivenName { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        [JsonProperty(Order = 7)]
        public virtual string Surname { get; set; }

        /// <summary>
        /// Gets or sets the list of other emails.
        /// </summary>
        [JsonProperty(Order = 8)]
        public virtual List<string> OtherMails { get; set; }

        /// <summary>
        /// Gets or sets the list of sign-in names.
        /// </summary>
        [JsonProperty(Order = 9)]
        public virtual List<TypeValuePair> SignInNames { get; set; }
    }
}