// <copyright file="IUserReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Data.User
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// User Reader.
    /// </summary>
    public interface IUserReader
    {
        public Task<User> GetUserByIdAsync(Guid userId);
    }
}
