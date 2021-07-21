using BetaLixT.Submissions.Functionality.Implementation.Context;
using BetaLixT.Submissions.Functionality.Interface;
using BetaLixT.Submissions.Functionality.Interface.CoreServices;
using BetaLixT.Submissions.Functionality.Interface.CustomModels;
using BetaLixT.Submissions.Functionality.Interface.Entities;
using BetaLixT.Submissions.Functionality.Interface.Exceptions;
using Microsoft.EntityFrameworkCore;
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
        public async Task<NamespaceDetailed> CreateNamespaceAsync(string displayName)
        {
            var dateTimeCreated = DateTimeOffset.UtcNow;
            var entity =  (await this._databaseContext.Namespaces.AddAsync(new Namespace 
            { 
                DisplayName = displayName,
                DateTimeCreated = dateTimeCreated,
                DateTimeModified = dateTimeCreated
            })).Entity;
            await this._databaseContext.SaveChangesAsync();
            return new NamespaceDetailed
            {
                NamespaceId = entity.Id,
                DisplayName = entity.DisplayName,
                Configuration = entity.Configuration
            };
        }

        /// <summary>
        /// Edits the namespace display name
        /// </summary>
        /// <param name="namespaceId"></param>
        /// <param name="displayName">Updated display name</param>
        /// <returns></returns>
        public async Task<NamespaceDetailed> EditNamespaceAsync(Guid namespaceId, string displayName)
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

            this._databaseContext.Update(ns);
            await this._databaseContext.SaveChangesAsync();
            return new NamespaceDetailed
            {
                NamespaceId = ns.Id,
                DisplayName = ns.DisplayName,
                Configuration = ns.Configuration
            };
        }

        /// <summary>
        /// Lists the namespaces in the database
        /// </summary>
        /// <param name="namespaceIdQuery">Filters the listing by Id</param>
        /// <param name="displayNameQuery">Filters the listing by display name</param>
        /// <param name="countPerPage">Number of records to be returned</param>
        /// <param name="pageNumber">Page number of records (starts from 0)</param>
        /// <returns>Listing of namespaces</returns>
        public async Task<List<NamespaceListing>> ListNamespacesAsync(
            string namespaceIdQuery,
            string displayNameQuery,
            int countPerPage,
            int pageNumber)
        {
            return await BuildListNamespacesCountQuery(namespaceIdQuery, displayNameQuery)
                .Skip(countPerPage * pageNumber)
                .Take(countPerPage)
                .ToListAsync();
        }

        /// <summary>
        /// Gets the count of namespaces in the database
        /// </summary>
        /// <param name="namespaceIdQuery">Filters the listing by Id</param>
        /// <param name="displayNameQuery">Filters the listing by display name</param>
        /// <returns>Count of namespaces</returns>
        public async Task<int> GetListNamespacesCountAsync(string namespaceIdQuery, string displayNameQuery)
        {
            return await BuildListNamespacesCountQuery(namespaceIdQuery, displayNameQuery)
                .CountAsync();
        }

        /// <summary>
        /// Gets the namespace
        /// </summary>
        /// <param name="namespaceId">Id of the namespace to be fetched</param>
        /// <returns>The requested namespace</returns>
        public async Task<NamespaceDetailed> GetNamespaceAsync(Guid namespaceId)
        {
            var ns = await this._databaseContext.Namespaces.Where(x => x.Id == namespaceId)
                .Select(x => new NamespaceDetailed
                {
                    NamespaceId = x.Id,
                    DisplayName = x.DisplayName,
                    Configuration = x.Configuration
                })
                .FirstOrDefaultAsync();
            if (ns == null)
            {
                throw new EntityMissingException((int)ErrorCodes.InvalidNamespaceId, ErrorCodes.InvalidNamespaceId.ToString());
            }

            return ns;
        }

        /// <summary>
        /// Builds the query for getting namespaces from database
        /// </summary>
        /// <param name="namespaceIdQuery"></param>
        /// <param name="displayNameQuery"></param>
        /// <returns></returns>
        private IQueryable<NamespaceListing> BuildListNamespacesCountQuery(string namespaceIdQuery, string displayNameQuery)
        {
            IQueryable<NamespaceListing> query = this._databaseContext.Namespaces.Select(ns => new NamespaceListing { 
                NamespaceId = ns.Id,
                DisplayName = ns.DisplayName
            });

            if(!string.IsNullOrWhiteSpace(namespaceIdQuery))
            {
                query = query.Where(x => x.NamespaceId.ToString().Contains(namespaceIdQuery));
            }
            if (!string.IsNullOrWhiteSpace(displayNameQuery))
            {
                query = query.Where(x => x.DisplayName.Contains(displayNameQuery));
            }

            return query;
        }
    }
}
