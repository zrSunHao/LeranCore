using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.Auth.Login.Model;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Api.Extensions.Authorization
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        private readonly ICacheService _catchService;

        public PermissionAuthorizationHandler(MemoryCacheService catchService)
        {
            _catchService = catchService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
        {
            if (context.User != null)
            {
                if (context.User.IsInRole("admin"))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    var userIdClaim = context.User.FindFirst(_ => _.Type == ClaimTypes.NameIdentifier);
                    if (userIdClaim != null)
                    {
                        var account = _catchService.Get<AccessDataModel>(userIdClaim.ToString());
                        if (account.Permissions.Any())
                        {
                            var permissionName = requirement.Name;
                            var exist = account.Permissions.Any(x =>
                                permissionName.StartsWith(x));
                            if (exist)
                            {
                                context.Succeed(requirement);
                            }
                        }
                    }
                }
            }
            return Task.CompletedTask;
        }

    }
}
