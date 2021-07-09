using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Functionality.Interface.Entities.Unstructured.FormProperties
{
    public class TextFieldProperty: FormProperty
    {
        public override bool ValidateField(object value)
        {

            if (value.GetType() != typeof(string))
            {
                return false;
            }
            return true;
        }
    }
}
