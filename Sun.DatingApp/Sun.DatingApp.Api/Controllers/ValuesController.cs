using Microsoft.AspNetCore.Mvc;

namespace Sun.DatingApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController: ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is datingApp Api!");
        }


    }
}
