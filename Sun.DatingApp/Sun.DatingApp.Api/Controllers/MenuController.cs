using Microsoft.AspNetCore.Mvc;
using Sun.DatingApp.Services.Services.MenuServices;

namespace Sun.DatingApp.Api.Controllers
{
    public class MenuController : BaseController
    {
        private readonly IMenuService _service;

        public MenuController(IMenuService service)
        {
            _service = service;
        }
    }
}