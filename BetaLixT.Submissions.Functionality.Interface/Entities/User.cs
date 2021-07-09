using System.Collections.Generic;
using BetaLixT.Submissions.Functionality.Interface.Entities.Unstructured;

namespace BetaLixT.Submissions.Functionality.Interface.Entities
{
    public class User
    {
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public UserConfiguration Configuration { get; set; }

        public virtual ICollection<NamespaceAdmin> NamespacesAdministered { get; set; }
    }
}
