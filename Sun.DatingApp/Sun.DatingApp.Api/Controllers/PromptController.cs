using Microsoft.AspNetCore.Mvc;

namespace Sun.DatingApp.Api.Controllers
{
    public class PromptController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}