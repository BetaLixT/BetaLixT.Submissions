using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetaLixT.Submissions.Api.Models.ApiRequests;
using BetaLixT.Submissions.Api.Models.ApiResponses;
using BetaLixT.Submissions.Functionality.Interface.Entities;
using BetaLixT.Submissions.Functionality.Interface.CoreServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace BetaLixT.Submissions.Api.Controllers.Namespaces
{
    [Route("api/namespaces/{namespaceId}/forms")]
    [ApiController]
    public class NamespaceFormController : ControllerBase
    {
        private readonly IFormService _formReporisory;

        public NamespaceFormController(IFormService formReporisory)
        {
            this._formReporisory = formReporisory;
        }

        [HttpPost]
        public async Task CreateFormAsync(
            Guid namespaceId)
        {
            throw new NotImplementedException();
        }
    }
}
