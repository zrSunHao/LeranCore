using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Sun.DatingApp.Data.Entities.System;
using Sun.DatingApp.Data.View.System;
using Sun.DatingApp.Model.System.Auth.Login.Model;
using Sun.DatingApp.Utility.CacheUtility;
using Sun.DatingApp.Utility.Dapper;

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
                var roleClaim = context.User.FindFirst(_ => _.Type == ClaimTypes.Role);
                if (roleClaim == null)
                {
                    return Task.CompletedTask;
                }

                var roleIdStr = roleClaim.Value.ToString();
                if (string.IsNullOrEmpty(roleIdStr))
                {
                    return Task.CompletedTask;
                }

                var roleId = Guid.Parse(roleIdStr);
                if (roleId == Guid.Empty)
                {
                    return Task.CompletedTask;
                }

                try
                {
                    using (var dapperContext = new DapperSqlServerContext())
                    {
                        var sql = @"SELECT TOP 1000 * FROM [ViewAuthorizationRolePermission] WHERE [RoleId] = @Id";
                        var pems = dapperContext.Conn.Query<ViewAuthorizationRolePermission>(sql, new { Id = roleId }).ToList();
                        if (!pems.Any())
                        {
                            return Task.CompletedTask;
                        }

                        var permissionName = requirement.Name;
                        var exist = pems.Any(x => x.PermissionCode == permissionName);
                        if (exist)
                        {
                            context.Succeed(requirement);
                        }
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    throw new Exception("权限认证出现异常，请联系管理员！");
                }
            }
            return Task.CompletedTask;
        }

        
    }
}
