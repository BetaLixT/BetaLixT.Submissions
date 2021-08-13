using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Common.Entities.Unstructured.FormProperties
{
    public class TextFieldProperty: IFormProperty
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public ICollection<IPropertyConstraint> Constraints { get; set; }

        Tuple<bool, IPropertyConstraint> IFormProperty.ValidateConstraints(object value)
        {
            throw new NotImplementedException();
        }

        public bool ValidateField(object value)
        {

            if (value.GetType() != typeof(string))
            {
                return false;
            }
            return true;
        }

        public Tuple<bool, string> EvaluateConstraints(object value)
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
