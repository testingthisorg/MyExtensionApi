using Assassins.DataAccess.Repositories.AppUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Assassins.Api.Controllers
{
    [Authorize]
    [Route("api/v1/app-values")]
    [ApiController]
    public class AppValueController : Controller
    {
        private IAppUserRepository _appValRepo;

        public AppValueController(IAppUserRepository appValRepo)
        {
            _appValRepo = appValRepo;
        }

        [HttpGet("roles")]
        public JsonResult GetUserRoles()
        {
            var models = _appValRepo.GetUserRoles();
            var vm = models.Select(k => k.ToViewModel());
            return Json(vm);
        }

        //[HttpGet("data-types")]
        //public JsonResult GetDataTypes()
        //{
        //    var items = _appValRepo.GetDataTypes();
        //    var vm = items.Select(k => k.ToViewModel());
        //    return Json(vm);
        //}
    }

}
