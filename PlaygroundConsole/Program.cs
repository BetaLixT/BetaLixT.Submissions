using BetaLixT.Submissions.Common.Entities;
using BetaLixT.Submissions.Common.Entities.Unstructured;
using BetaLixT.Submissions.Common.Entities.Unstructured.ExportSchemas;
using BetaLixT.Submissions.Common.Entities.Unstructured.FormProperties;
using BetaLixT.Submissions.Common.Entities.Unstructured.PropertyConstraints;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlaygroundConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var form = GetSampleForm();

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

            var csvExport = new CsvExportSchema
            {
                PropertyMapping = new Dictionary<int, string>()
                {
                    { 0, "First Property" }
                }
            };
            var stream = new FileStream("test.csv", FileMode.OpenOrCreate);

            var submissions = new List<Submission>
            {
                GetSampleSubmission(),
                GetSampleSubmission(),
                GetSampleSubmission(),
                GetSampleSubmission(),
                GetSampleSubmission(),
                GetSampleSubmission()
            };

            var getDelegate = new IExportSchema.GetChunkDelegate(async (iter, chunk) =>
            {
                return submissions.Skip(iter * chunk).Take(chunk).ToList();
            });

            await csvExport.Export(stream, form.FormSchema, getDelegate);
            stream.Close();

            var constraintTest = form.FormSchema.Properties.First().ValidateConstraints();

            var json = JsonConvert.SerializeObject(form, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            var obj = JsonConvert.DeserializeObject<Form>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        }

        public static Form GetSampleForm()
        {
            return new Form
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
        }
        public static Submission GetSampleSubmission()
        {
            return new Submission
            {
                Responses = new List<object>
                {
                    "This text",
                    "Another text",
                    "This is Long Message lol it's longer than allowed atleast",
                    "sdfsadfsdfsf"
                }
            };
        }
    }
}
