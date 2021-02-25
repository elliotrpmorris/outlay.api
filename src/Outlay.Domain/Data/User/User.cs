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
            Guid id,
            string userName)
        {
            if (id == default)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Invalid user name.");
            }

            this.Id = id;
            this.UserName = userName;
        }

        public Guid Id { get; }

        public string UserName { get; }
    }
}
