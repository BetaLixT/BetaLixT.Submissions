using BetaLixT.Submissions.Common.Entities.Unstructured;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Common.Entities
{
    public class Namespace
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public NamespaceConfiguration Configuration { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeModified { get; set; }

        public virtual ICollection<NamespaceAdmin> Admins { get; set; }
        public virtual ICollection<Form> Forms { get; set; }
    }
}
