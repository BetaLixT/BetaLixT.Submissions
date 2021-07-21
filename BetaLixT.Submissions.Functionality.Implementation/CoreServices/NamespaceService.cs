using BetaLixT.Submissions.Functionality.Implementation.Context;
using BetaLixT.Submissions.Functionality.Interface;
using BetaLixT.Submissions.Functionality.Interface.CoreServices;
using BetaLixT.Submissions.Functionality.Interface.Entities;
using BetaLixT.Submissions.Functionality.Interface.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaLixT.Submissions.Functionality.Implementation.CoreServices
{
    class NamespaceService : INamespaceService
    {
        private readonly DatabaseContext _databaseContext;
        public NamespaceService (DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        /// <summary>
        /// Creates a namespace with given display name
        /// </summary>
        /// <param name="displayName">The display name of the new namespace</param>
        /// <returns>The namespace that was created</returns>
        public async Task<Namespace> CreateNamespaceAsync(string displayName)
        {
            var dateTimeCreated = DateTimeOffset.UtcNow;
            var entity =  (await this._databaseContext.Namespaces.AddAsync(new Namespace 
            { 
                DisplayName = displayName,
                DateTimeCreated = dateTimeCreated,
                DateTimeModified = dateTimeCreated
            })).Entity;
            await this._databaseContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Edits the namespace display name
        /// </summary>
        /// <param name="namespaceId"></param>
        /// <param name="displayName">Updated display name</param>
        /// <returns></returns>
        public async Task<Namespace> EditNamespaceAsync(Guid namespaceId, string displayName)
        {
            var ns = this._databaseContext.Namespaces
                .Where(x => x.Id == namespaceId)
                .FirstOrDefault();

            if (ns == null)
            {
                throw new EntityMissingException((int)ErrorCodes.InvalidNamespaceId, ErrorCodes.InvalidNamespaceId.ToString());
            }

            ns.DisplayName = displayName;
            ns.DateTimeModified = DateTimeOffset.UtcNow;

            this._databaseContext.Namespaces.Attach(ns);
            this._databaseContext.Entry(ns).Property(x => x.DisplayName).IsModified = true;
            this._databaseContext.Entry(ns).Property(x => x.DateTimeModified).IsModified = true;
            await this._databaseContext.SaveChangesAsync();
            return ns;
        }
    }
}
