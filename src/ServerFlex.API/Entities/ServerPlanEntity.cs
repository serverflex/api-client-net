﻿using Newtonsoft.Json;
using System;

namespace ServerFlex.API.Entities
{
    public class ServerPlanEntity
    {
        #region Properties
        /// <summary>
        /// Gets or sets the Plan's display name.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets whether the Plan is free trial eligible.
        /// </summary>
        [JsonProperty("isFreeTrialEligible")]
        public bool IsFreeTrialEligible { get; set; }

        /// <summary>
        /// Gets or sets the pricing for the Plan.
        /// </summary>
        [JsonProperty("pricing")]
        public PricingEntity Pricing { get; set; }

        /// <summary>
        /// Gets or sets the resources available to this server Plan.
        /// </summary>
        [JsonProperty("resources")]
        public ServerPlanResourcesEntity Resources { get; set; }

        /// <summary>
        /// Gets or sets the plan's UUID.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid UUID { get; set; }
        #endregion
    }
}
