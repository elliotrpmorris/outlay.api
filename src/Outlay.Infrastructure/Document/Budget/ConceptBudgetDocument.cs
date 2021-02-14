// <copyright file="ConceptBudgetDocument.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Infrastructure.Document.ConceptBudget
{
    using System;
    using System.Collections.Generic;
    using Outlay.Infrastructure.Document.Budget;

    /// <summary>
    /// Concept Budget Document.
    /// </summary>
    public class ConceptBudgetDocument : BudgetDocument
    {
        public ConceptBudgetDocument(
            Guid id,
            Guid userId,
            IDictionary<string, double> items,
            string conceptName)
            : base(id, userId, items)
        {
            this.ConceptName = conceptName;
        }

        public string ConceptName { get; }
    }
}
