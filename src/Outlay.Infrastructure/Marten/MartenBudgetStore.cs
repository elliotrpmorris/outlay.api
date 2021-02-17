// <copyright file="MartenBudgetStore.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Infrastructure.Marten
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Chest.Core.Logging;
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

        /// <inheritdoc/>
        public async Task AddAsync(Budget budget)
        {
            using var session = this.DocumentStore.LightweightSession();

            session.Store(budget.ToBudgetDocument());

            await session.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Budget budget)
        {
            using var session = this.DocumentStore.LightweightSession();

            session.Delete(budget.ToBudgetDocument());

            await session.SaveChangesAsync();
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public async Task<bool> GetBudgetExistsAsync(Guid budgetId)
        {
            using var session = this.DocumentStore.LightweightSession();

            var exists = await
                session
                    .Query<BudgetDocument>()
                    .AnyAsync(b => b.Id == budgetId);

            return exists;
        }

        /// <inheritdoc/>
        public async Task<bool> GetBudgetForUserExistsAsync(Guid userId)
        {
            using var session = this.DocumentStore.LightweightSession();

            var exists = await
                session
                    .Query<BudgetDocument>()
                    .AnyAsync(b => b.UserId == userId);

            return exists;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(Budget budget)
        {
            using var session = this.DocumentStore.LightweightSession();

            var budgetToUpdate = await
                session
                    .Query<BudgetDocument>()
                    .FirstOrDefaultAsync(s => s.Id == budget.Id);

            if (budget == null)
            {
                Logger.LogInformation($"Budget with Identifer: {budget.Id} doesn't exist");

                return;
            }

            // TODO: Extract me into a helper plz.
            foreach (var item in budgetToUpdate.Items)
            {
                var existingItems =
                    budgetToUpdate.Items
                        .FirstOrDefault(c =>
                            c.Key.ToLower() == item.Key.ToLower());

                // Item exists but has updated value.
                if (existingItems.Key != null)
                {
                    // Update item's value.
                    budgetToUpdate.Items[existingItems.Key] = item.Value;
                }
                else
                {
                    // New contact detail so add to items.
                    budgetToUpdate.Items.TryAdd(item.Key.ToLower(), item.Value);
                }
            }

            session.Update(budgetToUpdate);

            await session.SaveChangesAsync();
        }
    }
}
