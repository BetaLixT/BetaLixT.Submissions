using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Common.Entities.Unstructured.PropertyConstraints
{
    public class MaxLengthConstraint : IPropertyConstraint
    {
        public string ErrorText { get; set; }
        public int MaxLength { get; set; }

        public bool ValidateConstraint(object value)
        {
            return value.ToString().Length <= MaxLength;
        }
    }
}
