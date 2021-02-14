// <copyright file="GraphQLRequest.cs" company="Outlay">
// Copyright (c) Outlay. All rights reserved.
// </copyright>

namespace Outlay.Api.Controllers.Query
{
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Represents a graphql query request.
    /// </summary>
    public class GraphQLRequest
    {
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        public string? Query { get; set; }

        /// <summary>
        /// Gets or sets the query variables.
        /// </summary>
        public JObject? Variables { get; set; }
    }
}
