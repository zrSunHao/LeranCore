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
                Power = 0,
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
        private static void SetSystemSuperAdministratorPermission(DataContext context, Guid roleId)
        {
            var perms = context.SystemPermissions.ToList();
            if (perms.Any()) return;

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

    }
}
