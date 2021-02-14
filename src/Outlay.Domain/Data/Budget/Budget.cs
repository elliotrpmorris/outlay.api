// <copyright file="Budget.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Data.Budget
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Budget.
    /// </summary>
    public class Budget
    {
        public Budget(
            Guid id,
            IDictionary<string, decimal> items,
            BudgetVarient budgetVarient)
        {
            this.Id = id;
            this.Items = items;
            this.BudgetVarient = budgetVarient;
        }

        public Guid Id { get; }

        public IDictionary<string, decimal> Items { get; }

        public BudgetVarient BudgetVarient { get; }
    }
}
