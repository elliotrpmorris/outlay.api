// <copyright file="CreateBudgetHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Command.Budget.Create
{
    using System;
    using System.Threading.Tasks;
    using Chest.Core.Command;
    using Chest.Core.Exceptions;
    using Outlay.Domain.Data.Budget;

    public class CreateBudgetHandler : ICommandHandler<CreateBudget>
    {
        public CreateBudgetHandler(
           IBudgetReader budgetReader,
           IBudgetWriter budgetWriter)
        {
            this.BudgetReader = budgetReader
                ?? throw new System.ArgumentNullException(nameof(budgetReader));

            this.BudgetWriter = budgetWriter
                ?? throw new System.ArgumentNullException(nameof(budgetWriter));
        }

        private IBudgetReader BudgetReader { get; }

        private IBudgetWriter BudgetWriter { get; }

        /// <inheritdoc/>
        public async Task Handle(CreateBudget command, CommandMetadata metadata)
        {
            if (command.UserId == default)
            {
                throw new InvalidCommandException(
                    metadata.CommandName,
                    typeof(CreateBudget).Name,
                    $"User ID must be set on the command.");
            }

            var exists = await
               this.BudgetReader.GetBudgetForUserExistsAsync(command.UserId);

            if (exists)
            {
                throw new InvalidCommandException(
                  metadata.CommandName,
                  typeof(CommandMetadata).Name,
                  $"A budget for user {command.UserId} already exists.");
            }

            await this.BudgetWriter.UpdateAsync(new Budget(
                Guid.NewGuid(),
                command.UserId,
                command.Items));
        }
    }
}
