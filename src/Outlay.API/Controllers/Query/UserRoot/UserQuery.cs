// <copyright file="UserQuery.cs" company="Outlay">
// Copyright (c) Outlay. All rights reserved.
// </copyright>

namespace Outlay.API.Controllers.Query.UserRoot
{
    using GraphQL.Types;
    using Outlay.API.Controllers.Query.UserRoot.Types;
    using Outlay.Domain.Data.User;

    public class UserQuery : ObjectGraphType<UserQueryContext>
    {
        public UserQuery(IUserReader userReader)
        {
            this.Field<UserType, User?>()
                .Name("info")
                .Description("User information")
                .ResolveAsync(context => userReader.GetUserByIdAsync(
                    context.Source.UserId));
        }
    }
}
