// <copyright file="UpdateBudget.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Command.Budget.Update
{
    using System;
    using System.Collections.Generic;
    using Chest.Core.Command;

    /// <summary>
    /// Update Budget Command.
    /// </summary>
    [CommandName("BUDGET/UPDATE")]
    public class UpdateBudget : ICommand
    {
        public UpdateBudget(
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
