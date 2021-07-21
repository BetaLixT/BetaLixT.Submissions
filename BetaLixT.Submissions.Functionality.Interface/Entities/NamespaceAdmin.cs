using System;
using System.Collections.Generic;

namespace BetaLixT.Submissions.Functionality.Interface.Entities
{
    public class NamespaceAdmin
    {
        public string UserId { get; set; }
        public Guid NamespaceId { get; set; }

        public virtual Namespace Namespace { get; set; }
        public virtual User Admin { get; set; }
        public virtual ICollection<Submission> SubmissionsValidated { get; set; }

    }
}
