using Microsoft.AspNetCore.Mvc;

namespace Sun.DatingApp.Api.Controllers
{
    public class RoleController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}