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
using BetaLixT.Submissions.Functionality.Interface.CustomModels;

namespace BetaLixT.Submissions.Api.Controllers
{
    [Route("api/namespaces")]
    [ApiController]
    public class NamespaceController : ControllerBase
    {
        private readonly INamespaceService _namespaceService;

        public NamespaceController(INamespaceService namespaceService)
        {
            this._namespaceService = namespaceService;
        }


        /// <summary>
        /// Creates a new namespace
        /// </summary>
        /// <param name="body">Create namespace request body</param>
        /// <returns>Created namespace</returns>
        [HttpPost]
        public async Task CreateNamespaceAsync([FromBody]CreateNamespaceBody body)
        {
            var ns = await this._namespaceService.CreateNamespaceAsync(body.DisplayName);

            var response = new SuccessResponseContent<NamespaceDetailed>()
            {
                ResultData = ns
            };

            this.Response.StatusCode = 200;
            this.Response.ContentType = "application/json";
            await this.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)));
        }

        /// <summary>
        /// Patches an existing namespace
        /// </summary>
        /// <param name="namespaceId">The Id of the namespace that is to be patched</param>
        /// <param name="body">Patch namespace request body</param>
        /// <returns></returns>
        [HttpPatch("{namespaceId}")]
        public async Task EditNamespaceAsync(Guid namespaceId, [FromBody]CreateNamespaceBody body)
        {
            var ns = await this._namespaceService.EditNamespaceAsync(namespaceId, body.DisplayName);

            var response = new SuccessResponseContent<NamespaceDetailed>()
            {
                ResultData = ns
            };

            this.Response.StatusCode = 200;
            this.Response.ContentType = "application/json";
            await this.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)));
        }

        /// <summary>
        /// Lists the namespaces in the database
        /// </summary>
        /// <param name="namespaceIdQuery">Filters the listing by Id</param>
        /// <param name="displayNameQuery">Filters the listing by display name</param>
        /// <param name="countPerPage">Number of records to be returned</param>
        /// <param name="pageNumber">Page number of records (starts from 0)</param>
        /// <returns>Listing of namespaces</returns>
        [HttpGet]
        public async Task ListNamespacesAsync(
            [FromQuery] string namespaceIdQuery,
            [FromQuery] string displayNameQuery,
            [FromQuery] int countPerPage = 1000,
            [FromQuery] int pageNumber = 0
            )
        {
            var namespaces = await this._namespaceService.ListNamespacesAsync(
                namespaceIdQuery,
                displayNameQuery,
                countPerPage,
                pageNumber);

            var response = new SuccessResponseContent<List<NamespaceListing>>()
            {
                ResultData = namespaces
            };

            this.Response.StatusCode = 200;
            this.Response.ContentType = "application/json";
            await this.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)));
        }

        /// <summary>
        /// Gets the count of namespaces in the database
        /// </summary>
        /// <param name="namespaceIdQuery">Filters the listing by Id</param>
        /// <param name="displayNameQuery">Filters the listing by display name</param>
        /// <returns>Count of namespaces</returns>
        [HttpGet("count")]
        public async Task GetListNamespacesCountAsync(
            [FromQuery] string namespaceIdQuery,
            [FromQuery] string displayNameQuery
            )
        {
            var namespaceCount = await this._namespaceService.GetListNamespacesCountAsync(
                namespaceIdQuery,
                displayNameQuery);

            var response = new SuccessResponseContent<int>()
            {
                ResultData = namespaceCount
            };

            this.Response.StatusCode = 200;
            this.Response.ContentType = "application/json";
            await this.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)));
        }

        /// <summary>
        /// Gets the namespace
        /// </summary>
        /// <param name="namespaceId">Id of the namespace to be fetched</param>
        /// <returns>The requested namespace</returns>
        [HttpPost("{namespaceId}")]
        public async Task GetNamespaceAsync(Guid namespaceId)
        {
            var ns = await this._namespaceService.GetNamespaceAsync(namespaceId);

            var response = new SuccessResponseContent<NamespaceDetailed>()
            {
                ResultData = ns
            };

            this.Response.StatusCode = 200;
            this.Response.ContentType = "application/json";
            await this.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)));
        }
    }
}