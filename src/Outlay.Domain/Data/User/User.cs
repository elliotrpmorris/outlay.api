// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Data.User
{
    using System;

    /// <summary>
    /// User.
    /// </summary>
    public class User
    {
        public User(
            Guid id)
        {
            if (id == default)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            this.Id = id;
        }

        public Guid Id { get; }
    }
}
