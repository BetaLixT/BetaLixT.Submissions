﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace BetaLixT.Submissions.Common.Entities.Unstructured
{
    public interface IFormProperty
    {
        string Title { get; set; }
        string Description { get; set; }
        bool IsRequired { get; set; }
        ICollection<IPropertyConstraint> Constraints { get; set; }

        Tuple<bool, IPropertyConstraint> ValidateConstraints();
        bool ValidateField(object value);
        Tuple<bool, string> EvaluateConstraints(object value);
    }
}
