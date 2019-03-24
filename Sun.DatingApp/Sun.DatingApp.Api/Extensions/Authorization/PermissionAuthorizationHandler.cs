using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Model.System.Auth.Login.Model;
using Sun.DatingApp.Utility.CacheUtility;

namespace Sun.DatingApp.Api.Extensions.Authorization
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        private readonly ICacheHandler _catchHandler;

        public PermissionAuthorizationHandler(ICacheHandler catchHandler)
        {
            _catchHandler = catchHandler;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
        {
            if (context.User != null)
            {
                var roleId = Guid.Parse("1426DE8F-D0F4-428A-BC1E-91F36BE1EFE4");

                if (context.User.IsInRole("admin"))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    var userIdClaim = context.User.FindFirst(_ => _.Type == ClaimTypes.NameIdentifier);
                    if (userIdClaim != null)
                    {
                        var account = _catchHandler.Get<AccessDataModel>(userIdClaim.Value.ToString());
                        if (account != null && account.Permissions.Any())
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
