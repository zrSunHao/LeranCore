using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace Sun.DatingApp.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        public Guid? CurrentUserId
        {
            get
            {
                if (User != null && User.Claims.Any())
                {
                    var idClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                    if (idClaim != null)
                    {
                        var id = Guid.Parse(idClaim.Value.ToString());
                        if (id != Guid.Empty)
                        {
                            return id;
                        }
                    }
                }
                return null;
            }
        }
    }
}
