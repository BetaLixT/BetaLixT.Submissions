using BetaLixT.Submissions.Common.Entities.Unstructured;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Common.Entities
{
    public class Form
    {
        public Guid Id { get; set; }
        public Guid NamespaceId { get; set; }
        public string Title { get; set; }
        public bool RequiresApproval { get; set; }
        public FormSchema FormSchema { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeModified { get; set; }

        public virtual Namespace Namespace { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
        public virtual ICollection<Export> Exports { get; set; }
    }
}
