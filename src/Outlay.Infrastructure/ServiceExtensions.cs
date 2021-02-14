// <copyright file="ServiceExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Chest.Core.Logging;
using Marten;
using Microsoft.Extensions.DependencyInjection;
using Outlay.Domain.Data.User;
using Outlay.Infrastructure.Document;
using Outlay.Infrastructure.Document.User;
using Outlay.Infrastructure.Marten;

namespace Outlay.Infrastructure
{
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
                            .DocumentAlias("users");

                           // Budget Varients.
                           //.AddSubClass(typeof(BioSectionDocument))
                           //.AddSubClass(typeof(ContactSectionDocument))        
                   }));

            services
                .AddTransient<IUserReader, MartenUserStore>()
                .AddTransient<IUserWriter, MartenUserStore>();

            return services;
        }
    }
}
