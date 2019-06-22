using Assassins.DataAccess.Repositories;
using Assassins.DataAccess.Repositories.AppUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assassins.Api.Controllers
{
    [Authorize]
    [Route("api/v1/aa-creatives")]
    [ApiController]
    public class LeadFormController : Controller
    {
        private readonly ILeadFormRepository _repo;
        private readonly IAppUserRepository _userRepo;

        public LeadFormController(ILeadFormRepository repo, IAppUserRepository userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }

    }

}
