// <copyright file="CreateBudget.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Command.Budget.Create
{
    using System;
    using System.Collections.Generic;
    using Chest.Core.Command;

    /// <summary>
    /// Create Budget Command.
    /// </summary>
    [CommandName("CREATE/UPDATE")]
    public class CreateBudget : ICommand
    {
        public CreateBudget(
            Guid userId,
            IDictionary<string, double> items)
        {
            this.UserId = userId;
            this.Items = items;
        }

        public Guid UserId { get; }

        public IDictionary<string, double> Items { get; }
    }
}
