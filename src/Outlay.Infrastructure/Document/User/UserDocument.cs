// <copyright file="UserDocument.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Infrastructure.Document.User
{
    using System;

    /// <summary>
    /// User document.
    /// </summary>
    public class UserDocument
    {
        public UserDocument(
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
