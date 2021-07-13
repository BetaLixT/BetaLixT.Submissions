using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetaLixT.Submissions.Api.Models.ApiRequests;
using BetaLixT.Submissions.Api.Models.ApiResponses;
using BetaLixT.Submissions.Functionality.Interface.Entities;
using BetaLixT.Submissions.Functionality.Interface.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BetaLixT.Submissions.Api.Controllers
{
    [Route("api/namespaces")]
    [ApiController]
    public class NamespaceController : ControllerBase
    {
        private readonly INamespaceRepository _namespaceReporisory;

        public NamespaceController(INamespaceRepository namespaceReporisory)
        {
            this._namespaceReporisory = namespaceReporisory;
        }


        /// <summary>
        /// Creates a new namespace
        /// </summary>
        /// <param name="body">Create namespace request body</param>
        /// <returns>Created namespace</returns>
        [HttpPost]
        public async Task CreateNamespaceAsync([FromBody]CreateNamespaceBody body)
        {
            var ns = await this._namespaceReporisory.CreateNamespaceAsync(body.DisplayName);

            var response = new SuccessResponseContent<Namespace>()
            {
                ResultData = ns
            };

            this.Response.StatusCode = 200;
            this.Response.ContentType = "application/json";
            await this.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)));
        }

        [HttpGet]
        public async Task ListNamespacesAsync()
        {
            throw new NotImplementedException();
        }

        [HttpPost("{namespaceId}")]
        public async Task GetNamespaceAsync(Guid namespaceId)
        {
            throw new NotImplementedException();
        }
    }
}