using BetaLixT.Submissions.Common.Entities.Unstructured;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Api.Models.ApiResponses
{
    public class NamespaceDetailed
    {
        public Guid NamespaceId { get; set; }
        public string DisplayName { get; set; }
        public NamespaceConfiguration Configuration { get; set; }
    }
}
