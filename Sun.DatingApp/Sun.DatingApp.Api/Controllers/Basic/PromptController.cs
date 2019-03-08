using Microsoft.AspNetCore.Mvc;

namespace Sun.DatingApp.Api.Controllers.Basic
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