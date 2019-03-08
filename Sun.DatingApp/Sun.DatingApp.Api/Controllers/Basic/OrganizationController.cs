using Microsoft.AspNetCore.Mvc;

namespace Sun.DatingApp.Api.Controllers.Basic
{
    public class OrganizationController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}