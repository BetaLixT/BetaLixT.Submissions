using System;
using System.Threading.Tasks;
using BetaLixT.Submissions.Functionality.Interface.Entities;

namespace BetaLixT.Submissions.Functionality.Interface.CoreServices
{
    public interface INamespaceService
    {
        Task<Namespace> CreateNamespaceAsync(string displayName);
        Task<Namespace> EditNamespaceAsync(Guid namespaceId, string displayName);
    }
}
