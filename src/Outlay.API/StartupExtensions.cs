// <copyright file="StartupExtensions.cs" company="Outlay">
// Copyright (c) Outlay. All rights reserved.
// </copyright>

namespace Outlay.API
{
    using Chest.Core.Command;
    using GraphQL;
    using GraphQL.DataLoader;
    using GraphQL.Http;
    using GraphQL.Types;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Outlay.Api.Controllers.Query;
    using Outlay.Api.Controllers.Query.DataLoaders;
    using Outlay.API.Controllers.Query.UserRoot;
    using Outlay.API.Controllers.Query.UserRoot.ConceptBudgetRoot;
    using Outlay.API.Controllers.Query.UserRoot.Types;

    /// <summary>
    /// Extensions for startup.
    /// </summary>
    internal static class StartupExtensions
    {
        /// <summary>
        /// Register Command pipeline.
        /// </summary>
        /// <param name="services">The container builder.</param>
        /// <returns>A Container builder.</returns>
        public static IServiceCollection RegisterCommandPipeline(this IServiceCollection services)
        {
            services.AddCommandBus(
                typeof(Outlay.Domain.Command.ICommandHandlerAssembly).Assembly);

            return services;
        }

        /// <summary>
        /// Registers GraphQL.
        /// </summary>
        /// <param name="services">The container builder.</param>
        /// <returns>A Container builder.</returns>
        public static IServiceCollection RegisterGraphQL(this IServiceCollection services)
        {
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services
                .AddSingleton<IDocumentWriter, DocumentWriter>();

            services
                .AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddScoped<RootQuery>();

            services
                .AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();

            services
                .AddSingleton<DataLoaderDocumentListener>();

            services
                .AddScoped<ISchema, RootSchema>();

            services
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Register Queries, Data loaders and Types
            // (Can this be done better im sure it can!)
            services.AddScoped<UserQuery>();
            services.AddScoped<ConceptBudgetQuery>();

            services.AddScoped<UserDataLoader>();

            services.AddScoped<UserType>();
            services.AddScoped<BudgetType>();
            services.AddScoped<ConceptBudgetType>();

            return services;
        }
    }
}
