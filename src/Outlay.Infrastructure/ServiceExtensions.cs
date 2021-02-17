// <copyright file="ServiceExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Infrastructure
{
    using Chest.Core.Logging;
    using global::Marten;
    using Microsoft.Extensions.DependencyInjection;
    using Outlay.Domain.Data.Budget;
    using Outlay.Domain.Data.User;
    using Outlay.Infrastructure.Document.Budget;
    using Outlay.Infrastructure.Document.ConceptBudget;
    using Outlay.Infrastructure.Document.User;
    using Outlay.Infrastructure.Marten;
    using Outlay.Infrastructure.Marten.Seed;

    /// <summary>
    /// Service Extensions.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Registers Marten Data Access.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>The service collections.</returns>
        public static IServiceCollection AddMartenDataAccess(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddSingleton<IDocumentStore>(
                DocumentStore
                   .For(_ =>
                   {
                       _.Connection(connectionString);

                       _.CreateDatabasesForTenants(c =>
                       {
                           // This will create the DB if not there.
                           c.ForTenant()
                               .CheckAgainstPgDatabase()
                               .WithOwner("postgres")
                               .WithEncoding("UTF-8")
                               .ConnectionLimit(-1)
                               .OnDatabaseCreated(_ =>
                               {
                                   Logger.LogInformation("Database created");
                               });
                       });

                       _.DdlRules.TableCreation = CreationStyle.CreateIfNotExists;

                       // Schema setup.
                       _.Schema.For<UserDocument>()
                            .Identity(i => i.Id)
                            .DocumentAlias("user");

                       _.Schema.For<BudgetDocument>()
                            .Identity(i => i.Id)
                            .DocumentAlias("budget")
                            .AddSubClass(typeof(ConceptBudgetDocument));

                       // Seed data, TODO: Remove me after init build.
                       _.InitialData.Add(new SeedDataSetup(SeedData.UserDocuments));
                       _.InitialData.Add(new SeedDataSetup(SeedData.BudgetDocument));
                       _.InitialData.Add(new SeedDataSetup(SeedData.ConceptBudgetDocument));
                   }));

            services
                .AddTransient<IUserReader, MartenUserStore>()
                .AddTransient<IUserWriter, MartenUserStore>();

            services
               .AddTransient<IBudgetReader, MartenBudgetStore>()
               .AddTransient<IBudgetWriter, MartenBudgetStore>();

            services
               .AddTransient<IConceptBudgetReader, MartenConceptBudgetStore>();

            return services;
        }
    }
}
