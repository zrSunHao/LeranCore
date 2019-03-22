using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sun.DatingApp.Api.Extensions.Authorization
{
    public class Permissions
    {
        #region 菜单管理页

        //加载菜单数据
        public const string GetMenus = "Menu.GetMenus";
        //添加菜单
        public const string CreateMenu = "Menu.CreateMenu";
        //删除菜单
        public const string DeleteMenu = "Menu.DeleteMenu";
        //删除页面
        public const string DeletePage = "Menu.DeletePage";

        #endregion


        #region 权限管理

        //加载页面数据
        public const string GetAllPages = "Menu.GetAllPages";
        //删除权限
        public const string DeletePermission = "Permission.DeletePermission";

        #endregion


        #region 角色管理

        //加载角色列表数据
        public const string GetRoles = "Role.GetRoles";
        //角色权限配置
        public const string GetRolePermissions = "Role.GetRolePermissions";
        //删除角色
        public const string DeleteRole = "Role.DeleteRole";

        #endregion


        #region 账号管理

        //账号列表数据加载
        public const string Accounts = "Auth.Accounts";
        //添加账号
        public const string CreateAccount = "Auth.CreateAccount";
        //批量删除账号
        public const string BatchDeleteAccount = "Auth.BatchDeleteAccount";
        //批量修改账号状态
        public const string BatchEditAccount = "Auth.BatchEditAccount";
        //删除单条帐号
        public const string DeleteAccount = "Auth.DeleteAccount";
        #endregion


        #region 起始页1

        //数据加载
        public const string LoadData = "Dashboard1.LoadData";

        #endregion
    }
}
