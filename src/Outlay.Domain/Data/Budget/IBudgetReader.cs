// <copyright file="IBudgetReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Data.Budget
{
    using System;
    using System.Threading.Tasks;

    public interface IBudgetReader<T>
        where T : Budget
    {
        public Task<T?> GetBudgetByUserIdAsync(Guid id);
    }
}
