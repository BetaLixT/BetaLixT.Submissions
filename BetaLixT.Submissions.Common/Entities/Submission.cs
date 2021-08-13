using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Common.Entities
{
    public class Submission
    {
        public Guid NamespaceId { get; set; }
        public Guid FormId { get; set; }
        public int Id { get; set; }
        public bool IsValidated { get; set; }
        public string ValidatedByUserId { get; set; }
        public ICollection<object> Responses { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeModified { get; set; }

        public virtual Form Form { get; set; }
        public virtual NamespaceAdmin ValidatedBy { get; set; }
    }
}
