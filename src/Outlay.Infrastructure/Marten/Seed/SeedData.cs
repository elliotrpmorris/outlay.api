// <copyright file="SeedData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Infrastructure.Marten.Seed
{
    using System;
    using System.Collections.Generic;
    using Outlay.Infrastructure.Document.Budget;
    using Outlay.Infrastructure.Document.ConceptBudget;
    using Outlay.Infrastructure.Document.User;

    /// <summary>
    /// Seed Data for Marten.
    /// </summary>
    internal static class SeedData
    {
        /// <summary>
        /// Seed data for user documents.
        /// </summary>
        public static readonly UserDocument[]
            UserDocuments =
        {
            new UserDocument(
                Guid.Parse("3f169b60-3d10-4beb-b6f9-3bfe2e4e5526"),
                "elliot"),
        };

        /// <summary>
        /// Seed data for budget documents.
        /// </summary>
        public static readonly BudgetDocument[]
            BudgetDocument =
        {
            new BudgetDocument(
                Guid.Parse("583d1bc5-57f4-4d0e-b88e-c882261887dd"),
                Guid.Parse("3f169b60-3d10-4beb-b6f9-3bfe2e4e5526"),
                new Dictionary<string, double>()
                {
                    { "Fuel", 80 },
                    { "Food", 25 },
                    { "Netflix", 8.99 },
                }),
        };

        /// <summary>
        /// Seed data for concept budget documents.
        /// </summary>
        public static readonly ConceptBudgetDocument[]
            ConceptBudgetDocument =
        {
            new ConceptBudgetDocument(
                Guid.Parse("c5272b61-5692-4a8a-b99c-ad4e631c337c"),
                Guid.Parse("3f169b60-3d10-4beb-b6f9-3bfe2e4e5526"),
                new Dictionary<string, double>()
                {
                    { "Fuel", 40 },
                    { "Food", 25 },
                    { "Netflix", 8.99 },
                },
                "My concept"),
        };
    }
}
