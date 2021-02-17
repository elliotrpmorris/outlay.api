// <copyright file="CreateBudgetValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Command.Budget.Create
{
    using Chest.Core.Command;
    using FluentValidation;

    public class CreateBudgetValidator : CommandValidator<CreateBudget>
    {
        /// <inheritdoc/>
        public override void ConfigureRules()
        {
            this.RuleFor(x => x.UserId)
               .NotEmpty()
               .WithMessage("A valid user identifier must be provided");

            this.RuleFor(x => x.Items)
                .NotEmpty()
                .NotNull()
                .WithMessage("A budget items must be provided");
        }
    }
}
