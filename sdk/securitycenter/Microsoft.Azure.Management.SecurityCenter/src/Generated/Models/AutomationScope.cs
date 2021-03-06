// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Security.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// A single automation scope.
    /// </summary>
    public partial class AutomationScope
    {
        /// <summary>
        /// Initializes a new instance of the AutomationScope class.
        /// </summary>
        public AutomationScope()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AutomationScope class.
        /// </summary>
        /// <param name="description">The resources scope description.</param>
        /// <param name="scopePath">The resources scope path. Can be the
        /// subscription on which the automation is defined on or a resource
        /// group under that subscription (fully qualified Azure resource
        /// IDs).</param>
        public AutomationScope(string description = default(string), string scopePath = default(string))
        {
            Description = description;
            ScopePath = scopePath;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the resources scope description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the resources scope path. Can be the subscription on
        /// which the automation is defined on or a resource group under that
        /// subscription (fully qualified Azure resource IDs).
        /// </summary>
        [JsonProperty(PropertyName = "scopePath")]
        public string ScopePath { get; set; }

    }
}
