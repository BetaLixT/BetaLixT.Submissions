using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetaLixT.Submissions.Api.CoreServices;
using Microsoft.AspNetCore.Mvc;

namespace BetaLixT.Submissions.Api.Controllers.Namespaces.Forms
{
    [Route("api/namespaces/{namespaceId}/forms/{formId}/submissions")]
    [ApiController]
    public class NamespaceFormSubmissionController : ControllerBase
    {
        private readonly SubmissionService _submissionService;

        public NamespaceFormSubmissionController(SubmissionService submissionService)
        {
            this._submissionService = submissionService;
        }

        [HttpGet]
        public async Task ListSubmissionsAsync(
            Guid namespaceId,
            Guid formId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task CreateSubmissionAsync(
            Guid namespaceId,
            Guid formId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("anon")]
        public async Task CreateSubmissionAnonAsync(
            Guid namespaceId,
            Guid formId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{submissionId}/approve")]
        public async Task ApproveSubmissionAsync(
            Guid namespaceId,
            Guid formId,
            Guid submissionId)
        {
            throw new NotImplementedException();
        }
    }
}
