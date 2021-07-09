using BetaLixT.Submissions.Functionality.Interface.Entities;
using BetaLixT.Submissions.Functionality.Interface.Entities.Unstructured;
using BetaLixT.Submissions.Functionality.Interface.Entities.Unstructured.FormProperties;
using BetaLixT.Submissions.Functionality.Interface.Entities.Unstructured.PropertyValidators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
                    Properties = new List<FormProperty> { 
                        new TextFieldProperty {
                            Title = "Name",
                            Description = "Your Name",
                            IsRequired = false,
                            Constraints = new List<PropertyConstraint>
                            {
                                new NumberConstraint
                                {

                                }
                            }
                        }}
                }
            };

            var json = JsonConvert.SerializeObject(form, Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            var obj = JsonConvert.DeserializeObject<Form>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
        }
    }
}
