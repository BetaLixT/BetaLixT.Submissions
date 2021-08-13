using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetaLixT.Submissions.Api.CoreServices;
using BetaLixT.Submissions.Api.Models.ApiRequests;
using BetaLixT.Submissions.Api.Models.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace BetaLixT.Submissions.Api.Controllers.Namespaces
{
    [Route("api/namespaces/{namespaceId}/admins")]
    [ApiController]
    public class NamespaceAdminController : ControllerBase
    {
        private readonly AdminService _adminReporisory;

        public NamespaceAdminController(AdminService adminReporisory)
        {
            this._adminReporisory = adminReporisory;
        }

        [HttpPost]
        public async Task AddAdminAsync(Guid namespaceId)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task ListAdminsAsync(Guid namespaceId)
        {
            throw new NotImplementedException();
        }
    }
}
