// <copyright file="UserType.cs" company="Outlay">
// Copyright (c) Outlay. All rights reserved.
// </copyright>

namespace Outlay.API.Controllers.Query.UserRoot.Types
{
    using System;
    using GraphQL.Types;
    using Outlay.Domain.Data.User;

    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            this.Field<IdGraphType, Guid>("id")
                .Description("The user identifier.")
                .Resolve(context => context.Source.Id);
        }
    }
}
