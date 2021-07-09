using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Functionality.Interface.Entities
{
    public class Submission
    {
        public Guid NamespaceId { get; set; }
        public Guid FormId { get; set; }
        public int Id { get; set; }
        public bool IsValidated { get; set; }
        public ICollection<object> Responses { get; set; }

        public virtual Form Form { get; set; }
    }
}
