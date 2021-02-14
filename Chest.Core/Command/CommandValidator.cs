// <copyright file="CommandValidator.cs" company="Outlay">
// Copyright (c) Outlay. All rights reserved.
// </copyright>

namespace Chest.Core.Command
{
    using FluentValidation;

    /// <inheritdoc />
    public abstract class CommandValidator<T> : AbstractValidator<T>
        where T : ICommand
    {
        /// <summary>
        /// Configure the validation rules for this command.
        /// </summary>
        public abstract void ConfigureRules();
    }
}
