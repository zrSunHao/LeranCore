using Microsoft.AspNetCore.Mvc;
using Sun.DatingApp.Services.Services.Permissions;

namespace Sun.DatingApp.Api.Controllers
{
    public class PermissionController : BaseController
    {
        public IPermissionService _service;

        public PermissionController(IPermissionService service)
        {
            _service = service;
        }
    }
}