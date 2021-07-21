using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BetaLixT.Submissions.Functionality.Interface.CustomModels;
using BetaLixT.Submissions.Functionality.Interface.Entities;

namespace BetaLixT.Submissions.Functionality.Interface.CoreServices
{
    public interface INamespaceService
    {
        /// <summary>
        /// Creates a namespace with given display name
        /// </summary>
        /// <param name="displayName">The display name of the new namespace</param>
        /// <returns>The namespace that was created</returns>
        Task<NamespaceDetailed> CreateNamespaceAsync(string displayName);

        /// <summary>
        /// Edits the namespace display name
        /// </summary>
        /// <param name="namespaceId"></param>
        /// <param name="displayName">Updated display name</param>
        /// <returns></returns>
        Task<NamespaceDetailed> EditNamespaceAsync(Guid namespaceId, string displayName);

        /// <summary>
        /// Lists the namespaces
        /// </summary>
        /// <param name="namespaceIdQuery">Filters the listing by ID</param>
        /// <param name="displayNameQuery">Filters the listing by display name</param>
        /// <param name="countPerPage">Number of records to be returned</param>
        /// <param name="pageNumber">Page number of records (starts from 0)</param>
        /// <returns>Listing of namespaces</returns>
        Task<List<NamespaceListing>> ListNamespacesAsync(
            string namespaceIdQuery,
            string displayNameQuery,
            int countPerPage,
            int pageNumber);


        /// <summary>
        /// Gets the count of namespaces
        /// </summary>
        /// <param name="namespaceIdQuery">Filters the listing by Id</param>
        /// <param name="displayNameQuery">Filters the listing by display name</param>
        /// <returns>Count of namespaces</returns>
        Task<int> GetListNamespacesCountAsync(string namespaceIdQuery, string displayNameQuery);

        /// <summary>
        /// Gets the namespace
        /// </summary>
        /// <param name="namespaceId">Id of the namespace to be fetched</param>
        /// <returns>The requested namespace</returns>
        Task<NamespaceDetailed> GetNamespaceAsync(Guid namespaceId);
    }
}
