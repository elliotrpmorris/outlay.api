// <copyright file="RootQuery.cs" company="Outlay">
// Copyright (c) Outlay. All rights reserved.
// </copyright>

namespace Outlay.Api.Controllers.Query
{
    using System;
    using System.Collections.Generic;

    using GraphQL.Types;
    using Outlay.API.Controllers.Query.UserRoot;

    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            this.Field<UserQuery>()
                .Name("user")
                .Description("Displays user information.")
                .Argument<NonNullGraphType<StringGraphType>>("userId", "The user identifier.")
                .Resolve(context =>
                {
                    return new UserQueryContext(context.GetArgument<Guid>("userId"));
                });
        }
    }
}
