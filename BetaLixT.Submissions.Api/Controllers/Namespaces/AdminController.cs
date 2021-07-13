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


namespace BetaLixT.Submissions.Api.Controllers.Namespaces
{
    [Route("api/namespaces/{namespaceId}/admins")]
    [ApiController]
    public class AdminController
    {
        private readonly IAdminRepository _adminReporisory;

        public AdminController(IAdminRepository adminReporisory)
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
