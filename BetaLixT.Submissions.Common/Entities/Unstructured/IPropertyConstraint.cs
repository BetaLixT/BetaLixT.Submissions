using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Common.Entities.Unstructured
{
    public interface IPropertyConstraint
    {
        string ErrorText { get; set; }

        bool ValidateConstraint(object value);
    }
}
