// <copyright file="IUserWriter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Domain.Data.User
{
    using System.Threading.Tasks;

    /// <summary>
    /// User Writer.
    /// </summary>
    public interface IUserWriter
    {
        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The User.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task AddAsync(User user);

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The User.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task DeleteAsync(User user);
    }
}
