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


            //保存
            context.SaveChanges();
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

            context.SystemMenus.Add(module);
            context.SystemPages.Add(dashboardPage1);
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

            //角色页
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

            //菜单页
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

            //权限页
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

            context.SystemMenus.Add(module);
            context.SystemPages.Add(accountPage);
            context.SystemPages.Add(rolePage);
            context.SystemPages.Add(menuPage);
            context.SystemPages.Add(permissionPage);
        }
    }
}
