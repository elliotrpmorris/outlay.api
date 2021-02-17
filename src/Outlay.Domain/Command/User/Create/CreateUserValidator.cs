// <copyright file="CreateUserValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Command.User.Create
{
    using Chest.Core.Command;
    using FluentValidation;

    /// <summary>
    /// Create user validator.
    /// </summary>
    public class CreateUserValidator : CommandValidator<CreateUser>
    {
        /// <inheritdoc/>
        public override void ConfigureRules()
        {
            this.RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("A valid user ID must be provided");
        }
    }
}
