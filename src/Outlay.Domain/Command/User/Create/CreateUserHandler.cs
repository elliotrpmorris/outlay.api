// <copyright file="CreateUserHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Command.User.Create
{
    using System.Threading.Tasks;
    using Chest.Core.Command;
    using Chest.Core.Exceptions;
    using Outlay.Domain.Data.User;

    /// <summary>
    /// Create User handler.
    /// </summary>
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        public CreateUserHandler(
            IUserReader userReader,
            IUserWriter userWriter)
        {
            this.UserReader = userReader
                ?? throw new System.ArgumentNullException(nameof(userReader));

            this.UserWriter = userWriter
                ?? throw new System.ArgumentNullException(nameof(userWriter));
        }

        private IUserReader UserReader { get; }

        private IUserWriter UserWriter { get; }

        /// <inheritdoc/>
        public async Task Handle(CreateUser command, CommandMetadata metadata)
        {
            if (command.Id == default)
            {
                throw new InvalidCommandException(
                    metadata.CommandName,
                    typeof(CreateUser).Name,
                    $"ID must be set on the command.");
            }

            var exists = await
               this.UserReader.GetUserExistsAsync(command.Id);

            if (exists)
            {
                throw new InvalidCommandException(
                  metadata.CommandName,
                  typeof(CommandMetadata).Name,
                  $"User already exists.");
            }

            await this.UserWriter.AddAsync(new User(command.Id));
        }
    }
}
