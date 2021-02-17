// <copyright file="IUserReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Data.User
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// User Reader.
    /// </summary>
    public interface IUserReader
    {
        /// <summary>
        /// Gets a user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The user.</returns>
        public Task<User> GetUserByIdAsync(Guid userId);

        /// <summary>
        /// Checks if a user exists or not.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Whether the user exists or not.</returns>
        public Task<bool> GetUserExistsAsync(Guid userId);
    }
}
