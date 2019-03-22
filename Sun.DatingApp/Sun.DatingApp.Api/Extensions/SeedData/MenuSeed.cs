using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sun.DatingApp.Data.Database;
using Sun.DatingApp.Data.Entities.System;

namespace Sun.DatingApp.Api.Extensions.SeedData
{
    public static class MenuSeed
    {
        public static void Initialize(DataContext context)
        {
            //起始页模块
            DashboardModule(context);

            //菜单模块
            SettingModule(context);

        }



        /// <summary>
        /// 起始页模块
        /// </summary>
        /// <param name="context"></param>
        private static void DashboardModule(DataContext context)
        {
            var module = new SystemMenu
            {
                Id = Guid.NewGuid(),
                Name = "",
                TagColor = "",
                Icon = "",
                Active = true,
                Intro = "",
                Order = 0,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
                Deleted = false,
            };

            //dashboard1页
            var dashboardPage1 = new SystemPage
            {
                Id = Guid.NewGuid(),
                Name = "",
                Url = "",
                MenuId = module.Id,
                Order = 1,
                Active = true,
                Intro = "",
                TagColor = "",
                Icon = "",
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
                Deleted = false,
            };
            DashboardPage1Perms(context, dashboardPage1.Id);//添加权限

            context.SystemMenus.Add(module);
            context.SystemPages.Add(dashboardPage1);

            //保存
            context.SaveChanges();
        }

        /// <summary>
        /// Dashboard1页添加权限
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pageId"></param>
        private static void DashboardPage1Perms(DataContext context,Guid pageId)
        {
            var loadData = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "加载页面数据",
                Code = "Dashboard1.LoadData",
                Intro = "加载该起始页的数据",
                Icon = "eye",
                TagColor = "",
                Active = true,
                PageId = pageId,
                Rank = 0,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            context.SystemPermissions.Add(loadData);
        }



        /// <summary>
        /// 设置模块
        /// </summary>
        /// <param name="context"></param>
        private static void SettingModule(DataContext context)
        {
            var module = new SystemMenu
            {
                Id = Guid.NewGuid(),
                Name = "",
                TagColor = "",
                Icon = "",
                Active = true,
                Intro = "",
                Order = 0,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
                Deleted = false,
            };

            //菜单管理页
            var menuPage = new SystemPage
            {
                Id = Guid.NewGuid(),
                Name = "",
                Url = "",
                MenuId = module.Id,
                Order = 1,
                Active = true,
                Intro = "",
                TagColor = "",
                Icon = "",
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
                Deleted = false,
            };
            MenuPagePerms(context, menuPage.Id);//添加权限

            //权限管理页
            var permissionPage = new SystemPage
            {
                Id = Guid.NewGuid(),
                Name = "",
                Url = "",
                MenuId = module.Id,
                Order = 1,
                Active = true,
                Intro = "",
                TagColor = "",
                Icon = "",
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
                Deleted = false,
            };
            PermissionPagePerms(context,permissionPage.Id);//添加权限

            //角色管理页
            var rolePage = new SystemPage
            {
                Id = Guid.NewGuid(),
                Name = "",
                Url = "",
                MenuId = module.Id,
                Order = 1,
                Active = true,
                Intro = "",
                TagColor = "",
                Icon = "",
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
                Deleted = false,
            };
            AccountPagePerms(context, rolePage.Id);//添加权限

            //账号管理页
            var accountPage = new SystemPage
            {
                Id = Guid.NewGuid(),
                Name = "",
                Url = "",
                MenuId = module.Id,
                Order = 1,
                Active = true,
                Intro = "",
                TagColor = "",
                Icon = "",
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
                Deleted = false,
            };
            RolePagePerms(context,accountPage.Id);//添加权限

            context.SystemMenus.Add(module);
            context.SystemPages.Add(accountPage);
            context.SystemPages.Add(rolePage);
            context.SystemPages.Add(menuPage);
            context.SystemPages.Add(permissionPage);

            //保存
            context.SaveChanges();
        }

        /// <summary>
        /// 菜单页添加权限
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pageId"></param>
        private static void MenuPagePerms(DataContext context, Guid pageId)
        {
            //加载菜单数据
            var getMenus = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "加载菜单数据",
                Code = "Menu.GetMenus",
                Intro = "",
                Icon = "",
                TagColor = "",
                Active = true,
                PageId = pageId,
                Rank = 0,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            //添加菜单
            var createMenu = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "添加菜单",
                Code = "Menu.CreateMenu",
                Intro = "",
                Icon = "",
                TagColor = "",
                Active = true,
                PageId = pageId,
                Rank = 0,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            //删除菜单
            var deleteMenu = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "删除菜单",
                Code = "Menu.DeleteMenu",
                Intro = "",
                Icon = "",
                TagColor = "",
                Active = true,
                PageId = pageId,
                Rank = 0,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            //删除页面
            var deletePage = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "删除页面",
                Code = "Menu.DeletePage",
                Intro = "",
                Icon = "",
                TagColor = "",
                Active = true,
                PageId = pageId,
                Rank = 0,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            context.SystemPermissions.Add(getMenus);
            context.SystemPermissions.Add(createMenu);
            context.SystemPermissions.Add(deleteMenu);
            context.SystemPermissions.Add(deletePage);
        }

        /// <summary>
        /// 权限页添加权限
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pageId"></param>
        private static void PermissionPagePerms(DataContext context, Guid pageId)
        {
            var loadData = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "加载页面数据",
                Code = "",
                Intro = "",
                Icon = "eye",
                TagColor = "",
                Active = true,
                PageId = pageId,
                Rank = 0,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            context.SystemPermissions.Add(loadData);
        }

        /// <summary>
        /// 账号管理页添加权限
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pageId"></param>
        private static void AccountPagePerms(DataContext context, Guid pageId)
        {
            var loadData = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "加载页面数据",
                Code = "",
                Intro = "",
                Icon = "eye",
                TagColor = "",
                Active = true,
                PageId = pageId,
                Rank = 0,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            context.SystemPermissions.Add(loadData);
        }

        /// <summary>
        /// 角色页添加权限
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pageId"></param>
        private static void RolePagePerms(DataContext context, Guid pageId)
        {
            var loadData = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "加载页面数据",
                Code = "",
                Intro = "",
                Icon = "eye",
                TagColor = "",
                Active = true,
                PageId = pageId,
                Rank = 0,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            context.SystemPermissions.Add(loadData);
        }
    }
}
