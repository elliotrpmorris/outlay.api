// <copyright file="MartenConceptBudgetStore.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Infrastructure.Marten
{
    using System;
    using System.Threading.Tasks;
    using global::Marten;
    using Outlay.Domain.Data.Budget;
    using Outlay.Infrastructure.Document.ConceptBudget;
    using Outlay.Infrastructure.Document.ConceptConceptBudget;

    /// <summary>
    /// Marten Budget Store.
    /// </summary>
    internal sealed class MartenConceptBudgetStore :
        IConceptBudgetReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MartenConceptBudgetStore"/> class.
        /// </summary>
        /// <param name="documentStore">The Document Store Factory.</param>
        public MartenConceptBudgetStore(
            IDocumentStore documentStore)
        {
            this.DocumentStore = documentStore
                ?? throw new ArgumentNullException(nameof(documentStore));
        }

        private IDocumentStore DocumentStore { get; }

        public async Task<ConceptBudget> GetBudgetByIdAsync(Guid budgetId)
        {
            using var session = this.DocumentStore.LightweightSession();

            var budget = await
                session
                    .Query<ConceptBudgetDocument>()
                    .FirstOrDefaultAsync(b => b.Id == budgetId);

            if (budget == null)
            {
                return null;
            }

            return budget.ToConceptBudget();
        }

        public Task<bool> GetBudgetExistsAsync(Guid budgetId)
        {
            throw new NotImplementedException();
        }
    }
}
