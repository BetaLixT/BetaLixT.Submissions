using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Functionality.Interface.Entities.Unstructured.PropertyValidators
{
    public class NumberConstraint : PropertyConstraint
    {

        public override bool ValidateConstraint(object value)
        {
            return true;
        }
    }
}
