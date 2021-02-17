// <copyright file="IBudgetReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Data.Budget
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Budget Reader.
    /// </summary>
    public interface IBudgetReader : IBudgetBaseReader<Budget>
    {
        public Task<Budget?> GetBudgetByUserIdAsync(Guid id);

        /// <summary>
        /// Checks if a budget exists or not by a user id.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Whether the budget exists or not.</returns>
        /// <remarks>
        /// A user can only have one normal budget this is used to enforce that.
        /// </remarks>
        public Task<bool> GetBudgetForUserExistsAsync(Guid userId);
    }
}
