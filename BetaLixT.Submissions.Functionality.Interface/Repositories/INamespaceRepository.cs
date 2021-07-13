using System;
using System.Threading.Tasks;
using BetaLixT.Submissions.Functionality.Interface.Entities;

namespace BetaLixT.Submissions.Functionality.Interface.Repositories
{
    public interface INamespaceRepository
    {
        Task<Namespace> CreateNamespaceAsync(string displayName);
    }
}
