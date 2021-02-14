// <copyright file="CreateUserHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Command.User.Create
{
    using System.Threading.Tasks;
    using Chest.Core.Command;

    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        public CreateUserHandler()
        {
        }

        public Task Handle(CreateUser command, CommandMetadata metadata)
        {
            throw new System.NotImplementedException();
        }
    }
}
