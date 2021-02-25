// <copyright file="MartenUserStore.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Outlay.Infrastructure.Marten
{
    using System;
    using System.Threading.Tasks;
    using global::Marten;
    using Outlay.Domain.Data.User;
    using Outlay.Infrastructure.Document.User;

    /// <summary>
    /// Marten user store.
    /// </summary>
    internal sealed class MartenUserStore :
        IUserReader,
        IUserWriter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MartenUserStore"/> class.
        /// </summary>
        /// <param name="documentStore">The Document Store Factory.</param>
        public MartenUserStore(
            IDocumentStore documentStore)
        {
            this.DocumentStore = documentStore
                ?? throw new ArgumentNullException(nameof(documentStore));
        }

        private IDocumentStore DocumentStore { get; }

        /// <inheritdoc/>
        public async Task AddAsync(User user)
        {
            using var session = this.DocumentStore.LightweightSession();

            session.Store(user.ToUserDocument());

            await session.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(User user)
        {
            using var session = this.DocumentStore.LightweightSession();

            session.Delete(user.ToUserDocument());

            await session.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            using var session = this.DocumentStore.LightweightSession();

            var user = await
                session
                    .Query<UserDocument>()
                    .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            return user.ToUser();
        }

        /// <inheritdoc/>
        public async Task<bool> GetUserExistsAsync(Guid userId)
        {
            using var session = this.DocumentStore.LightweightSession();

            var exists = await
                session
                    .Query<UserDocument>()
                    .AnyAsync(s => s.Id == userId);

            return exists;
        }

        /// <inheritdoc/>
        public async Task<bool> GetUserExistsAsync(string userName)
        {
            using var session = this.DocumentStore.LightweightSession();

            // We want user names to be fully unqiue :D.
            var exists = await
                session
                    .Query<UserDocument>()
                    .AnyAsync(s => s.UserName.ToLower() == userName.ToLower());

            return exists;
        }
    }
}
