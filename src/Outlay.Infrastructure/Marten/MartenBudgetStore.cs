// <copyright file="MartenBudgetStore.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Infrastructure.Marten
{
    using System;
    using System.Threading.Tasks;
    using global::Marten;
    using Outlay.Domain.Data.Budget;
    using Outlay.Infrastructure.Document.Budget;

    /// <summary>
    /// Marten Budget Store.
    /// </summary>
    internal sealed class MartenBudgetStore :
        IBudgetReader,
        IBudgetWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MartenBudgetStore"/> class.
        /// </summary>
        /// <param name="documentStore">The Document Store Factory.</param>
        public MartenBudgetStore(
            IDocumentStore documentStore)
        {
            this.DocumentStore = documentStore
                ?? throw new ArgumentNullException(nameof(documentStore));
        }

        private IDocumentStore DocumentStore { get; }

        public Task AddAsync(Budget user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Budget budget)
        {
            throw new NotImplementedException();
        }

        public Task<Budget> GetBudgetByIdAsync(Guid budgetId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<Budget?> GetBudgetByUserIdAsync(Guid userId)
        {
            using var session = this.DocumentStore.LightweightSession();

            var budget = await
                session
                    .Query<BudgetDocument>()
                    .FirstOrDefaultAsync(b => b.UserId == userId);

            if (budget == null)
            {
                return null;
            }

            return budget.ToBudget();
        }

        public Task<bool> GetBudgetExistsAsync(Guid budgetId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetBudgetForUserExistsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Budget budget)
        {
            throw new NotImplementedException();
        }
    }
}
