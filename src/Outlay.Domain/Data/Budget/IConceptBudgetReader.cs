// <copyright file="IConceptBudgetReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Data.Budget
{
    using System;
    using System.Threading.Tasks;

    public interface IConceptBudgetReader<T>
        where T : Budget
    {
        public Task<T?> GetConceptBudgetByIdAsync(Guid id);
    }
}
