using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Functionality.Interface.Entities.Unstructured
{
    public class FormSchema
    {
        public string Title { get; set; }
        public ICollection<FormProperty> Properties { get; set; }
    }
}
