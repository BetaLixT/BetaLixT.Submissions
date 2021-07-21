﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BetaLixT.Submissions.Functionality.Interface.CoreServices;

namespace BetaLixT.Submissions.Api.Controllers.Namespaces.Forms
{
    [Route("api/namespaces/{namespaceId}/forms/{formId}/submissions")]
    [ApiController]
    public class NamespaceFormSubmissionController : Controller
    {
        private readonly ISubmissionService _submissionService;

        public NamespaceFormSubmissionController(ISubmissionService submissionService)
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

        [HttpGet("export")]
        public async Task ExportSubmissionsAsync(
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