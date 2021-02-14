// <copyright file="CreateUser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Command.User.Create
{
    using System;
    using Chest.Core.Command;

    /// <summary>
    /// Create User Command.
    /// </summary>
    [CommandName("USER/CREATE")]
    public class CreateUser : ICommand
    {
        public CreateUser(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }
    }
}
