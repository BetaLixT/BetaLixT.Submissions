using BetaLixT.Submissions.Common.Entities.Unstructured;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Common.Entities
{
    public class Export
    {
        public Guid NamespaceId { get; set; }
        public Guid FormId { get; set; }
        public int Id { get; set; }
        public IExportSchema ExportSchema { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeModified { get; set; }

        public virtual Form Form { get; set; }
    }
}
