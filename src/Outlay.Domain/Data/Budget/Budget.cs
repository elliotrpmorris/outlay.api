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
