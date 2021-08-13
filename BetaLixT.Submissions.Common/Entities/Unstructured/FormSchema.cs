using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Common.Entities.Unstructured
{
    public class FormSchema
    {
        public string Title { get; set; }
        public ICollection<IFormProperty> Properties { get; set; }
    }
}
