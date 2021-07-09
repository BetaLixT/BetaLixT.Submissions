using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Functionality.Interface.Entities.Unstructured
{
    public abstract class FormProperty
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public ICollection<PropertyConstraint> Constraints { get; set; }

        public abstract bool ValidateField(object value);

        public Tuple<bool, string> ValidateConstraints(object value)
        {
            if (Constraints != null)
            {
                foreach (var constraint in Constraints)
                {
                    if (!constraint.ValidateConstraint(value))
                    {
                        new Tuple<bool, string>(false, constraint.ErrorText);
                    }
                }
            }

            return new Tuple<bool, string>(true, "");
        }
    }
}
