// <copyright file="UserBudget.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Data.UserBudget
{
    using System;

    /// <summary>
    /// User Budget.
    /// </summary>
    public class UserBudget
    {
        public UserBudget(
            Guid userId,
            Guid budgetId)
        {
            this.UserId = userId;
            this.BudgetId = budgetId;
        }

        public Guid UserId { get; }

        public Guid BudgetId { get; }
    }
}
