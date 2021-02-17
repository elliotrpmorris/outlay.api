// <copyright file="IBudgetBaseReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Data.Budget
{
    using System;
    using System.Threading.Tasks;

    public interface IBudgetBaseReader<T>
        where T : Budget
    {
        /// <summary>
        /// Gets the concept budget by identifier.
        /// </summary>
        /// <param name="budgetId">The budget identifier.</param>
        /// <returns>The Concept Budget.</returns>
        public Task<T?> GetBudgetByIdAsync(Guid budgetId);

        /// <summary>
        /// Checks if a budget exists or not.
        /// </summary>
        /// <param name="budgetId">The budget identifier.</param>
        /// <returns>Whether the budget exists or not.</returns>
        public Task<bool> GetBudgetExistsAsync(Guid budgetId);
    }
}
