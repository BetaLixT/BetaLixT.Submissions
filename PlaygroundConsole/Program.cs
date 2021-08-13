using BetaLixT.Submissions.Common.Entities;
using BetaLixT.Submissions.Common.Entities.Unstructured;
using BetaLixT.Submissions.Common.Entities.Unstructured.FormProperties;
using BetaLixT.Submissions.Common.Entities.Unstructured.PropertyConstraints;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaygroundConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var form = new Form
            {
                Id = Guid.NewGuid(),
                NamespaceId = Guid.NewGuid(),
                Title = "Test",
                RequiresApproval = false,
                FormSchema = new FormSchema
                {
                    Title = "Test",
                    Properties = new List<IFormProperty> { 
                        new TextFieldProperty {
                            Title = "Name",
                            Description = "Your Name",
                            IsRequired = false,
                            Constraints = new List<IPropertyConstraint>
                            {
                                new MaxLengthConstraint
                                {
                                    ErrorText = "Message too long",
                                    MaxLength = 10
                                }
                            }
                        },
                        new TextFieldProperty {
                            Title = "Name",
                            Description = "Your Name",
                            IsRequired = false,
                            Constraints = new List<IPropertyConstraint>
                            {
                                new NumberConstraint
                                {
                                    ErrorText = "Not number"
                                }
                            }
                        },
                        new TextFieldProperty {
                            Title = "Name",
                            Description = "Your Name",
                            IsRequired = false,
                            Constraints = new List<IPropertyConstraint>
                            {
                                new MaxLengthConstraint
                                {
                                    ErrorText = "Message too long",
                                    MaxLength = 10
                                }
                            }
                        },
                        new TextFieldProperty {
                            Title = "Name",
                            Description = "Your Name",
                            IsRequired = false,
                            Constraints = new List<IPropertyConstraint>
                            {
                                new MaxLengthConstraint
                                {
                                    ErrorText = "Message too long",
                                    MaxLength = 10
                                }
                            }
                        }
                    },

                }
            };

            var submission = new Submission
            {
                Responses = new List<object>
                {
                    "This text",
                    "Another text",
                    "This is Long Message lol it's longer than allowed atleast",
                    23
                }
            };

            for (int i = 0; i < form.FormSchema.Properties.Count; i++)
            {
                var property = form.FormSchema.Properties.ElementAt(i);
                Console.WriteLine($"Property: {property.Title}");
                var constraintsValidation = property.ValidateConstraints();
                var passFailText = constraintsValidation.Item1 ? "passed" : "failed";
                Console.WriteLine($"\tConstraint validation: {passFailText}");
                if (!constraintsValidation.Item1)
                {
                    Console.WriteLine($"\t\t{constraintsValidation.Item2}");
                }
                else
                {
                    var element = submission.Responses.ElementAt(i);
                    if (element != null)
                    {
                        passFailText = property.ValidateField(element) ? "passed" : "failed";
                        Console.WriteLine($"\tConstraint validation: {passFailText}");

                        var constraintEvaluation = property.EvaluateConstraints(element);
                        passFailText = constraintEvaluation.Item1 ? "passed" : "failed";
                        Console.WriteLine($"\tConstraint evaluation: {passFailText}");
                        if (!constraintEvaluation.Item1)
                        {
                            Console.WriteLine($"\t\t{constraintEvaluation.Item2}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\tNo value");
                    }
                }
            }

            var constraintTest = form.FormSchema.Properties.First().ValidateConstraints();

            var json = JsonConvert.SerializeObject(form, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            var obj = JsonConvert.DeserializeObject<Form>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        }
    }
}
