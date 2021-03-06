import { SettingListComponent } from './setting/setting-list/setting-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ACLGuard, ACLType, ACLCanType } from '@delon/acl';

import { SysRoleRoleListComponent } from './role/role-list/role-list.component';
import { RolePermissionComponent } from './role/role-permission/role-permission.component';
import { MenuRootComponent } from './menu/menu-root/menu-root.component';
import { UserComponent } from './user/user.component';
import { UserInfoComponent } from './user/user-info/user-info.component';
import { UserSecurityComponent } from './user/user-security/user-security.component';
import { UserNotificationComponent } from './user/user-notification/user-notification.component';
import { UserBindingComponent } from './user/user-binding/user-binding.component';
import { AccountListComponent } from './account/account-list/account-list.component';
import { PermissionListComponent } from './permission/permission-list/permission-list.component';

const routes: Routes = [
  {
    path: 'role-list',
    component: SysRoleRoleListComponent,
    canActivate: [ACLGuard],
    data: {
      title: '角色管理列表',
      guard: { ability: [10, 'Role.GetRoles'], mode: 'oneOf' } as ACLType,
    },
  },
  {
    path: 'permission-list',
    component: PermissionListComponent,
    canActivate: [ACLGuard],
    data: {
      title: '权限管理列表',
      guard: { ability: [10, 'Menu.GetAllPages'], mode: 'oneOf' } as ACLType,
    },
  },
  {
    path: 'role-permission-list/:id',
    component: RolePermissionComponent,
    data: {
      title: '角色权限管理列表',
      guard: {
        ability: [10, 'Role.GetRolePermissions'],
        mode: 'oneOf',
      } as ACLType,
    },
  },
  {
    path: 'menu-list',
    component: MenuRootComponent,
    canActivate: [ACLGuard],
    data: {
      title: '菜单管理列表',
      guard: { ability: [10, 'Menu.GetMenus'], mode: 'oneOf' } as ACLType,
    },
  },
  {
    path: 'account-list',
    component: AccountListComponent,
    canActivate: [ACLGuard],
    data: {
      title: '账号管理列表',
      guard: { ability: [10, 'Auth.Accounts'], mode: 'oneOf' } as ACLType,
    },
  },
  {
    path: 'setting-list',
    component: SettingListComponent,
    canActivate: [ACLGuard],
    data: {
      title: '系统设置管理',
      guard: { ability: [10, 'Setting.GetSettings'], mode: 'oneOf' } as ACLType,
    },
  },
  {
    path: 'user',
    component: UserComponent,
    children: [
      { path: '', redirectTo: 'info', pathMatch: 'full' },
      {
        path: 'info',
        component: UserInfoComponent,
        data: { titleI18n: '用户信息' },
      },
      {
        path: 'security',
        component: UserSecurityComponent,
        data: { titleI18n: '安全设置' },
      },
      {
        path: 'notification',
        component: UserNotificationComponent,
        data: { titleI18n: '账号绑定' },
      },
      {
        path: 'binding',
        component: UserBindingComponent,
        data: { titleI18n: '消息通知' },
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SysRoutingModule {}
