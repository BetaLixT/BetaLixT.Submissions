using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Functionality.Interface.Entities.Unstructured
{
    public abstract class PropertyConstraint
    {
        public string ErrorText { get; set; }

        public virtual bool ValidateConstraint(object value)
        {
            return true;
        }
    }
}
