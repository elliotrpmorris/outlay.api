// <copyright file="InvalidHandlerItemTypeException.cs" company="Outlay">
// Copyright (c) Outlay. All rights reserved.
// </copyright>

namespace Chest.Core.Exceptions
{
    using System;

    /// <summary>
    /// Thrown when trying to resolve a command handler that does not implement
    /// the correct interface.
    /// </summary>
    [Serializable]
    public class InvalidHandlerItemTypeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidHandlerItemTypeException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public InvalidHandlerItemTypeException(string message)
            : base(message)
        {
        }
    }
}
