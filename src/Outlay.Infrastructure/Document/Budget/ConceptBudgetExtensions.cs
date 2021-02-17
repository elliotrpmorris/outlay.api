// <copyright file="ConceptBudgetExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Infrastructure.Document.ConceptConceptBudget
{
    using Outlay.Infrastructure.Document.ConceptBudget;
    using Outlay.Domain.Data.Budget;
    using System;
    using System.Linq;

    /// <summary>
    /// Concept Budget Extensions.
    /// </summary>
    internal static class ConceptBudgetExtensions
    {
        /// <summary>
        /// Convert From Document to Data Object.
        /// </summary>
        /// <param name="conceptBudget">The Concept Budget Document. </param>
        /// <returns>The ConceptBudget Data Object.</returns>
        public static ConceptBudget ToConceptBudget(this ConceptBudgetDocument conceptBudget)
        {
            if (conceptBudget == null)
            {
                throw new ArgumentNullException(nameof(ConceptBudget));
            }

            return new ConceptBudget(
                conceptBudget.Id,
                conceptBudget.UserId,
                conceptBudget.Items,
                conceptBudget.ConceptName);
        }

        /// <summary>
        /// Convert Document to Data Object to Document.
        /// </summary>
        /// <param name="conceptBudget">The Concept Budget.</param>
        /// <returns>The Data Object.</returns>
        public static ConceptBudgetDocument ToConceptBudgetDocument(this ConceptBudget conceptBudget)
        {
            if (conceptBudget == null)
            {
                throw new ArgumentNullException(nameof(ConceptBudget));
            }

            return new ConceptBudgetDocument(
                    conceptBudget.Id,
                    conceptBudget.UserId,
                    conceptBudget.Items,
                    conceptBudget.ConceptName);
        }

        /// <summary>
        /// Convert From IQueryable of Document to Data Object.
        /// </summary>
        /// <param name="source">The Document.</param>
        /// <returns>The Data Object.</returns>
        public static IQueryable<ConceptBudget> ToConceptBudget(this IQueryable<ConceptBudgetDocument> source)
        {
            return source.Select(b => new ConceptBudget(
                b.Id,
                b.UserId,
                b.Items,
                b.ConceptName));
        }
    }
}
