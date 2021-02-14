// <copyright file="BudgetExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Infrastructure.Document.Budget
{
    using System;
    using System.Linq;
    using Outlay.Domain.Data.Budget;

    /// <summary>
    /// Budget extensions.
    /// </summary>
    internal static class BudgetExtensions
    {
        /// <summary>
        /// Convert From Document to Data Object.
        /// </summary>
        /// <param name="budget">The Budget Document. </param>
        /// <returns>The Budget Data Object.</returns>
        public static Budget ToBudget(this BudgetDocument budget)
        {
            if (budget == null)
            {
                throw new ArgumentNullException(nameof(Budget));
            }

            return new Budget(
                budget.Id,
                budget.UserId,
                budget.Items);
        }

        /// <summary>
        /// Convert Document to Data Object to Document.
        /// </summary>
        /// <param name="budget">The Budget.</param>
        /// <returns>The Data Object.</returns>
        public static BudgetDocument ToBudgetDocument(this Budget budget)
        {
            if (budget == null)
            {
                throw new ArgumentNullException(nameof(Budget));
            }

            return new BudgetDocument(
                    budget.Id,
                    budget.UserId,
                    budget.Items);
        }

        /// <summary>
        /// Convert From IQueryable of Document to Data Object.
        /// </summary>
        /// <param name="source">The Document.</param>
        /// <returns>The Data Object.</returns>
        public static IQueryable<Budget> ToBudget(this IQueryable<BudgetDocument> source)
        {
            return source.Select(b => new Budget(
                b.Id,
                b.UserId,
                b.Items));
        }
    }
}