using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Common.Entities.Unstructured.PropertyConstraints
{
    public class NumberConstraint : IPropertyConstraint
    {
        public string ErrorText { get; set; }

        public bool ValidateConstraint(object value)
        {
            return true;
        }
    }
}
