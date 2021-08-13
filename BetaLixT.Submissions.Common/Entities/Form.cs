using BetaLixT.Submissions.Common.Entities.Unstructured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetaLixT.Submissions.Common.Entities
{
    public class Form
    {
        public Guid Id { get; set; }
        public Guid NamespaceId { get; set; }
        public string Title { get; set; }
        public bool RequiresApproval { get; set; }
        public FormSchema FormSchema { get; set; }
        public DateTimeOffset DateTimeCreated { get; set; }
        public DateTimeOffset DateTimeModified { get; set; }
        public FormStatus FormStatus { get; set; }

        public virtual Namespace Namespace { get; set; }
        public virtual ICollection<Submission> Submissions { get; set; }
        public virtual ICollection<Export> Exports { get; set; }

        public Tuple<bool, string> ValidateProperties ()
        {
            var ids = this.FormSchema.Properties.Select(x => x.Id).ToList();

            // - Test for distinct ids
            if (ids.Count != ids.Distinct().Count())
            {
                return new Tuple<bool, string>(false, "Ids aren't distinct");
            }

            // - Testing each property
            for (int i = 0; i < this.FormSchema.Properties.Count; i++)
            {
                var property = this.FormSchema.Properties.ElementAt(i);

                // - Testing if constraints are valid
                var constraintsValidation = property.ValidateConstraints();
                if(!constraintsValidation.Item1)
                {
                    return new Tuple<bool, string>(false, $"Invalid constraint {constraintsValidation.Item2}");
                }
            }

            return new Tuple<bool, string>(false, null);
        }

        public Tuple<bool, string> ValidateSubmission(Submission submission)
        {
            var ids = this.FormSchema.Properties.Select(x => x.Id).ToList();

            foreach(var id in ids)
            {
                var property = this.FormSchema.Properties.Where(x => x.Id == id).FirstOrDefault();
                if (submission.Responses.ContainsKey(id))
                {
                    var response = submission.Responses[id];
                    if(response == null)
                    {
                        if(property.IsRequired)
                        {
                            return new Tuple<bool, string>(false, $"Missing required response property id: {property.Id}");
                        }
                    }
                    else
                    {
                        if(!property.ValidateField(response))
                        {
                            return new Tuple<bool, string>(false, $"Response invalid property id: {property.Id}");
                        }

                        var (isPassing, constraintErrorMessage) = property.EvaluateConstraints(response);

                        if(!isPassing)
                        {
                            return new Tuple<bool, string>(false, $"{constraintErrorMessage} property id: {property.Id}");
                        }
                    }
                }
                else if (property.IsRequired)
                {
                    return new Tuple<bool, string>(false, $"Missing required response property id: {property.Id}");
                }
            }

            return new Tuple<bool, string>(false, null);
        }
    }

    public enum FormStatus
    {
        Draft,
        Released,
        Closed
    }
}
