using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Api.Extensions.SeedData
{
    public static class RoleSeed
    {
        public static void Initialize(DataContext context)
        {
            //系统超级管理员
            SystemSuperAdministrator(context);

            //业务超级管理员
            BusinessSuperAdministrator(context);

            context.SaveChanges();
        }

        /// <summary>
        /// 系统超级管理员
        /// </summary>
        /// <param name="context"></param>
        private static void SystemSuperAdministrator(DataContext context)
        {
            var role = new SystemRole
            {
                Id = Guid.NewGuid(),
                Name = "系统超级管理员",
                Intro = "默认设置角色，拥有所有的权限",
                Active = true,
                Rank = 0,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            context.SystemRoles.Add(role);

            SetSystemSuperAdministratorPermission(context,role.Id);
        }

        /// <summary>
        /// 系统超级管理员赋有全部权限
        /// </summary>
        /// <param name="context"></param>
        /// <param name="roleId"></param>
        private static void SetSystemSuperAdministratorPermission(DataContext context, Guid roleId)
        {
            var perms = context.SystemPermissions.ToList();
            if (!perms.Any()) return;

            var rPerms = new List<SystemRolePermission>();
            foreach (var perm in perms)
            {
                var rPerm = new SystemRolePermission
                {
                    Id = Guid.NewGuid(),
                    RoleId = roleId,
                    PermissionId = perm.Id,
                    PageId = perm.PageId,
                    CreatedAt = DateTime.Now,
                    CreatedById = Guid.Empty,
                    Deleted = false
                };

                rPerms.Add(rPerm);
            }

            context.AddRange(rPerms);
        }

        /// <summary>
        /// 业务超级管理员
        /// </summary>
        /// <param name="context"></param>
        private static void BusinessSuperAdministrator(DataContext context)
        {
            var role = new SystemRole
            {
                Id = Guid.NewGuid(),
                Name = "业务超级管理员",
                Intro = "默认设置角色，拥有除菜单、权限、角色配置之外的所有权限",
                Active = true,
                Rank = 2,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            context.SystemRoles.Add(role);

            SetBusinessSuperAdministratorPermission(context, role.Id);
        }

        /// <summary>
        /// 业务超级管理员拥有除角色、菜单、权限配置之外的所有权限
        /// </summary>
        /// <param name="context"></param>
        /// <param name="roleId"></param>
        private static void SetBusinessSuperAdministratorPermission(DataContext context, Guid roleId)
        {
            var perms = context.SystemPermissions.ToList();
            if (!perms.Any()) return;

            var besidePages = new List<string>{"菜单管理","权限管理","角色管理"};
            var besidePageIds = context.SystemPages.Where(x => !besidePages.Contains(x.Name)).Select(x => x.Id).ToList();

            var rPerms = new List<SystemRolePermission>();
            foreach (var perm in perms)
            {
                if (!besidePageIds.Contains(perm.Id))
                {
                    var rPerm = new SystemRolePermission
                    {
                        Id = Guid.NewGuid(),
                        RoleId = roleId,
                        PermissionId = perm.Id,
                        PageId = perm.PageId,
                        CreatedAt = DateTime.Now,
                        CreatedById = Guid.Empty,
                        Deleted = false
                    };

                    rPerms.Add(rPerm);
                }
            }

            if (rPerms.Any())
            {
                context.AddRange(rPerms);
            }
        }
    }
}
