using BetaLixT.Submissions.Common.Entities.Unstructured.PropertyConstraints;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BetaLixT.Submissions.Common.Entities.Unstructured.FormProperties
{
    public class TextFieldProperty: IFormProperty
    {
        private static readonly ReadOnlyCollection<Type> AllowedConstraints = new ReadOnlyCollection<Type>(new List<Type> {
            typeof(MaxLengthConstraint)
        });

        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public ICollection<IPropertyConstraint> Constraints { get; set; }

        public ReadOnlyCollection<Type> GetAllowedConstraints()
        {
            return AllowedConstraints;
        }

        Tuple<bool, IPropertyConstraint> IFormProperty.ValidateConstraints()
        {
            foreach(var constraint in this.Constraints)
            {
                if (!AllowedConstraints.Contains(constraint.GetType()))
                {
                    return new Tuple<bool, IPropertyConstraint>(false, constraint);
                }
            }
            return new Tuple<bool, IPropertyConstraint>(true, null);
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
                        return new Tuple<bool, string>(false, constraint.ErrorText);
                    }
                }
            }

            return new Tuple<bool, string>(true, "");
        }
    }
}
