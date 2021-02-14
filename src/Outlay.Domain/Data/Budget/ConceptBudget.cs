// <copyright file="ConceptBudget.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Data.Budget
{
    using System;
    using System.Collections.Generic;

    public class ConceptBudget : Budget
    {
        public ConceptBudget(
            Guid id,
            Guid userId,
            IDictionary<string, double> items)
            : base(id, userId, items)
        {
        }
    }
}
