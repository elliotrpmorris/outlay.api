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
