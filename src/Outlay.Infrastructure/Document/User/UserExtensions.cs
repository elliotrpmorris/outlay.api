// <copyright file="UserExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Infrastructure.Document.User
{
    using System;
    using System.Linq;

    using Outlay.Domain.Data.User;

    /// <summary>
    /// User extensions.
    /// </summary>
    internal static class UserExtensions
    {
        /// <summary>
        /// Convert From Document to Data Object.
        /// </summary>
        /// <param name="user">The User Document. </param>
        /// <returns>The User Data Object.</returns>
        public static User ToUser(this UserDocument user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return new User(
                user.Id,
                user.UserName);
        }

        /// <summary>
        /// Convert Document to Data Object to Document.
        /// </summary>
        /// <param name="user">The User.</param>
        /// <returns>The Data Object.</returns>
        public static UserDocument ToUserDocument(this User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return new UserDocument(
                    user.Id,
                    user.UserName);
        }

        /// <summary>
        /// Convert From IQueryable of Document to Data Object.
        /// </summary>
        /// <param name="source">The Document.</param>
        /// <returns>The Data Object.</returns>
        public static IQueryable<User> ToUser(this IQueryable<UserDocument> source)
        {
            return source.Select(u => new User(
                u.Id,
                u.UserName));
        }
    }
}