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
                Name = "起始页",
                TagColor = "blue",
                Icon = "dashboard",
                Active = true,
                Intro = "展示和分析数据趋势的模块；",
                Order = 0,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
                Deleted = false,
            };

            //dashboard1页
            var dashboardPage1 = new SystemPage
            {
                Id = Guid.NewGuid(),
                Name = "数据分析",
                Url = "/Dashboard",
                MenuId = module.Id,
                Order = 1,
                Active = true,
                Intro = "数据分析，趋势，百分比，图表显示；",
                TagColor = "geekblue",
                Icon = "dashboard",
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
                TagColor = "geekblue",
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
                Name = "系统设置",
                TagColor = "cyan",
                Icon = "setting",
                Active = true,
                Intro = "系统设置模块，包括菜单管理、权限管理、角色管理、账号管理四个页面；",
                Order = 10,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
                Deleted = false,
            };

            //菜单管理页
            var menuPage = new SystemPage
            {
                Id = Guid.NewGuid(),
                Name = "菜单管理",
                Url = "/sys/menu-list",
                MenuId = module.Id,
                Order = 0,
                Active = true,
                Intro = "菜单的配置，以及菜单下页面信息的配置；只有【系统超级管理员】才有此页面权限",
                TagColor = "#108ee9",
                Icon = "menu-unfold",
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
                Deleted = false,
            };
            MenuPagePerms(context, menuPage.Id);//添加权限

            //权限管理页
            var permissionPage = new SystemPage
            {
                Id = Guid.NewGuid(),
                Name = "权限管理",
                Url = "/sys/permission-list",
                MenuId = module.Id,
                Order = 1,
                Active = true,
                Intro = "页面权限的管理及配置；只有【系统超级管理员】才有此页面权限；",
                TagColor = "#f50",
                Icon = "warning",
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
                Deleted = false,
            };
            PermissionPagePerms(context,permissionPage.Id);//添加权限

            //角色管理页
            var rolePage = new SystemPage
            {
                Id = Guid.NewGuid(),
                Name = "角色管理",
                Url = "/sys/role-list",
                MenuId = module.Id,
                Order = 2,
                Active = true,
                Intro = "角色的管理，以及角色权限的配置，只有系统超级管理员才有此页面的权限；",
                TagColor = "#87d068",
                Icon = "key",
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
                Deleted = false,
            };
            AccountPagePerms(context, rolePage.Id);//添加权限

            //账号管理页
            var accountPage = new SystemPage
            {
                Id = Guid.NewGuid(),
                Name = "账号管理",
                Url = "/sys/account-list",
                MenuId = module.Id,
                Order = 3,
                Active = true,
                Intro = "账号的管理、角色配置，当前账号只能查看低于所属角色等级下的账号；只有【系统超级管理员】和【业务超级管理员】才有此页面的权限；",
                TagColor = "#2db7f5",
                Icon = "usergroup-add",
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
                Name = "加载菜单列表数据",
                Code = "Menu.GetMenus",
                Intro = "最重要的权限，api获取菜单数据，用于列表显示，若不选择，则不能加载数据；",
                Icon = "eye",
                TagColor = "#f50",
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
                Intro = "添加菜单，并配置相关信息；",
                Icon = "plus",
                TagColor = "green",
                Active = true,
                PageId = pageId,
                Rank = 1,
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
                Intro = "删除菜单，若该菜单下存在页面则将不能删除；",
                Icon = "delete",
                TagColor = "red",
                Active = true,
                PageId = pageId,
                Rank = 2,
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
                Intro = "删除页面，同时删除该页面下的所有权限；",
                Icon = "delete",
                TagColor = "red",
                Active = true,
                PageId = pageId,
                Rank = 3,
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
            //加载页面数据
            var getAllPages = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "加载页面列表数据",
                Code = "Menu.GetAllPages",
                Intro = "最重要的，从api端获取页面数据之后才能配置相关的页面权限；",
                Icon = "eye",
                TagColor = "#f50",
                Active = true,
                PageId = pageId,
                Rank = 0,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            //删除权限
            var deletePermission = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "删除权限",
                Code = "Permission.DeletePermission",
                Intro = "删除权限，若该权限有角色选中则将不能删除；",
                Icon = "delete",
                TagColor = "red",
                Active = true,
                PageId = pageId,
                Rank = 1,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            context.SystemPermissions.Add(getAllPages);
            context.SystemPermissions.Add(deletePermission);
        }

        /// <summary>
        /// 账号管理页添加权限
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pageId"></param>
        private static void AccountPagePerms(DataContext context, Guid pageId)
        {
            //账号列表数据加载
            var accounts = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "账号列表数据加载",
                Code = "Auth.Accounts",
                Intro = "最重要的，从api获取账号列表数据之后才能进行下一步的操作；",
                Icon = "eye",
                TagColor = "#f50",
                Active = true,
                PageId = pageId,
                Rank = 0,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            //添加账号
            var createAccount = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "添加账号",
                Code = "Auth.CreateAccount",
                Intro = "这是非常危险的行为，用户注册才是账号添加的正确方式，只有【系统超级管理员】才有权限添加；",
                Icon = "plus",
                TagColor = "cyan",
                Active = true,
                PageId = pageId,
                Rank = 1,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            //批量删除账号
            var batchDeleteAccount = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "批量删除账号",
                Code = "Auth.BatchDeleteAccount",
                Intro = "这是非常危险的行为，正常情况下是不能删除用户的，特别是批量删除，只有【系统超级管理员】才有权限添加；",
                Icon = "delete",
                TagColor = "red",
                Active = true,
                PageId = pageId,
                Rank = 2,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            //批量修改账号状态
            var batchEditAccount = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "批量修改账号状态",
                Code = "Auth.BatchEditAccount",
                Intro = "可以禁用或锁定账号，只有【系统超级管理员】才有此权限；",
                Icon = "edit",
                TagColor = "magenta",
                Active = true,
                PageId = pageId,
                Rank = 3,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            //删除单条帐号
            var deleteAccount = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "删除单条帐号",
                Code = "Auth.DeleteAccount",
                Intro = "这是非常危险的行为，正常情况下是不能删除用户的；",
                Icon = "delete",
                TagColor = "orange",
                Active = true,
                PageId = pageId,
                Rank = 4,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            context.SystemPermissions.Add(accounts);
            context.SystemPermissions.Add(createAccount);
            context.SystemPermissions.Add(batchDeleteAccount);
            context.SystemPermissions.Add(batchEditAccount);
            context.SystemPermissions.Add(deleteAccount);
        }

        /// <summary>
        /// 角色页添加权限
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pageId"></param>
        private static void RolePagePerms(DataContext context, Guid pageId)
        {
            //加载角色列表数据
            var getRoles = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "加载角色列表数据",
                Code = "Role.GetRoles",
                Intro = "最重要的，从api获取角色列表数据之后才能进行之后的操作；",
                Icon = "eye",
                TagColor = "#f50",
                Active = true,
                PageId = pageId,
                Rank = 0,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            //角色权限配置
            var getRolePermissions = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "角色权限配置",
                Code = "Role.GetRolePermissions",
                Intro = "配置角色权限；",
                Icon = "warning",
                TagColor = "red",
                Active = true,
                PageId = pageId,
                Rank = 1,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            //删除角色
            var deleteRole = new SystemPermission
            {
                Id = Guid.NewGuid(),
                Name = "删除角色",
                Code = "Role.DeleteRole",
                Intro = "删除角色，若该角色下存在用户则不能删除；",
                Icon = "eye",
                TagColor = "volcano",
                Active = true,
                PageId = pageId,
                Rank = 2,
                Deleted = false,
                CreatedAt = DateTime.Now,
                CreatedById = Guid.Empty,
            };

            context.SystemPermissions.Add(getRoles);
            context.SystemPermissions.Add(getRolePermissions);
            context.SystemPermissions.Add(deleteRole);
        }
    }
}
