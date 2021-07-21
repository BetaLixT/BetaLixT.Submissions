using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetaLixT.Submissions.Api.Controllers.Namespaces.Forms
{
    [Route("api/namespaces/{namespaceId}/forms/{formId}/exports")]
    [ApiController]
    public class NamespaceFormExportController : ControllerBase
    {
        [HttpGet]
        public async Task ListExportsAsync(
            Guid namespaceId,
            Guid formId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("default")]
        public async Task DefaultExportSubmissionsAsync(
            Guid namespaceId,
            Guid formId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{exportId}")]
        public async Task ExportSubmissionsAsync(
            Guid namespaceId,
            Guid formId,
            int exportId)
        {
            throw new NotImplementedException();
        }
    }
}