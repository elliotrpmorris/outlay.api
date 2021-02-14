// <copyright file="RootSchema.cs" company="Outlay">
// Copyright (c) Outlay. All rights reserved.
// </copyright>

namespace Outlay.Api.Controllers.Query
{
    using GraphQL;
    using GraphQL.Types;

    public class RootSchema : Schema
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RootSchema"/> class.
        /// </summary>
        /// <param name="resolver">The dependency resolver.</param>
        public RootSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            this.Query = resolver.Resolve<RootQuery>();
        }
    }
}
