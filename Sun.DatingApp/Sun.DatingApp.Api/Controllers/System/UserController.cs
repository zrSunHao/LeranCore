using Sun.DatingApp.Services.Services.UserServices;

namespace Sun.DatingApp.Api.Controllers.System
{
    public class UserController : BaseController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
            _service.SetCurrentUserId(CurrentUserId);
        }

        
    }
}