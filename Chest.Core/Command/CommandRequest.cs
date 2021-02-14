// <copyright file="CommandRequest.cs" company="Outlay">
// Copyright (c) Outlay. All rights reserved.
// </copyright>

namespace Chest.Core.Command
{
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Represents a command request object.
    /// </summary>
    public class CommandRequest
    {
        /// <summary>
        /// Gets or sets the command name.
        /// </summary>
        public string? Command { get; set; }

        /// <summary>
        /// Gets or sets the command body.
        /// </summary>
        public JObject? Body { get; set; }
    }
}
