// <copyright file="BudgetDocument.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Infrastructure.Document.Budget
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Budget Document.
    /// </summary>
    public class BudgetDocument
    {
        public BudgetDocument(
           Guid id,
           Guid userId,
           IDictionary<string, double> items)
        {
            this.Id = id;
            this.UserId = userId;
            this.Items = items;
        }

        public Guid Id { get; }

        public Guid UserId { get; }

        public IDictionary<string, double> Items { get; }
    }
}
