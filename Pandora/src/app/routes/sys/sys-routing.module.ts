import { AccountListComponent } from './account/account-list/account-list.component';
import { PermissionListComponent } from './permission/permission-list/permission-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SysRoleRoleListComponent } from './role/role-list/role-list.component';
import { RolePermissionComponent } from './role/role-permission/role-permission.component';
import { MenuRootComponent } from './menu/menu-root/menu-root.component';

const routes: Routes = [
  {
    path: 'role-list',
    component: SysRoleRoleListComponent,
    data: { title: '角色管理列表' },
  },
  {
    path: 'permission-list',
    component: PermissionListComponent,
    data: { title: '权限管理列表' },
  },
  {
    path: 'role-permission-list/:id',
    component: RolePermissionComponent,
    data: { title: '角色权限管理列表' },
  },
  {
    path: 'menu-list',
    component: MenuRootComponent,
    data: { title: '菜单管理列表' },
  },
  {
    path: 'account-list',
    component: AccountListComponent,
    data: { title: '账号管理列表' },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SysRoutingModule {}
