// <copyright file="ConceptBudgetQueryContext.cs" company="Outlay">
// Copyright (c) Outlay. All rights reserved.
// </copyright>

namespace Outlay.API.Controllers.Query.UserRoot.ConceptBudgetRoot
{
    using System;

    public class ConceptBudgetQueryContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConceptBudgetQueryContext"/> class.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="budgetId">The budget identifier.</param>
        public ConceptBudgetQueryContext(
            Guid userId,
            Guid budgetId)
        {
            if (userId == default)
            {
                throw new ArgumentException(nameof(userId));
            }

            if (budgetId == default)
            {
                throw new ArgumentException(nameof(userId));
            }

            this.UserId = userId;
            this.BudgetId = budgetId;
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Gets the budget identifier.
        /// </summary>
        public Guid BudgetId { get; }
    }
}
