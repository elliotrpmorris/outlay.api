// <copyright file="UpdateBudgetHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Command.Budget.Update
{
    using System.Threading.Tasks;
    using Chest.Core.Command;
    using Chest.Core.Exceptions;
    using Outlay.Domain.Data.Budget;

    public class UpdateBudgetHandler : ICommandHandler<UpdateBudget>
    {
        public UpdateBudgetHandler(
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
        public async Task Handle(UpdateBudget command, CommandMetadata metadata)
        {
            if (command.Id == default)
            {
                throw new InvalidCommandException(
                    metadata.CommandName,
                    typeof(UpdateBudget).Name,
                    $"ID must be set on the command.");
            }

            var exists = await
               this.BudgetReader.GetBudgetExistsAsync(command.Id);

            if (exists)
            {
                throw new InvalidCommandException(
                  metadata.CommandName,
                  typeof(CommandMetadata).Name,
                  $"User already exists.");
            }

            await this.BudgetWriter.UpdateAsync(new Budget(
                command.Id,
                command.UserId,
                command.Items));
        }
    }
}
