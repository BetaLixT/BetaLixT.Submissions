using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Functionality.Interface.Entities
{
    public class Namespace
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeModified { get; set; }

        public virtual ICollection<NamespaceAdmin> Admins { get; set; }
        public virtual ICollection<Form> Forms { get; set; }
    }
}
