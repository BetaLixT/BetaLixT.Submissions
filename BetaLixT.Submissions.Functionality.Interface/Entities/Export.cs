using BetaLixT.Submissions.Functionality.Interface.Entities.Unstructured;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Functionality.Interface.Entities
{
    public class Export
    {
        public Guid NamespaceId { get; set; }
        public Guid FormId { get; set; }
        public int Id { get; set; }
        public ExportSchema ExportSchema { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeModified { get; set; }

        public virtual Form Form { get; set; }
    }
}
