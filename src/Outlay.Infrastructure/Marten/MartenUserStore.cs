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
    }
}
