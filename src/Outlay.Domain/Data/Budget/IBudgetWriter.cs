// <copyright file="IBudgetWriter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Data.Budget
{
    using System.Threading.Tasks;

    public interface IBudgetWriter
    {
        /// <summary>
        /// Adds the budget.
        /// </summary>
        /// <param name="budget">The budget.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task AddAsync(Budget user);

        /// <summary>
        /// Updates the budget.
        /// </summary>
        /// <param name="budget">The budget.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task UpdateAsync(Budget budget);

        /// <summary>
        /// Adds the budget.
        /// </summary>
        /// <param name="budget">The budget.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task DeleteAsync(Budget budget);
    }
}
