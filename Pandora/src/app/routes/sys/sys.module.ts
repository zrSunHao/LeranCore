import { NgModule } from '@angular/core';
import { SharedModule } from '@shared';

import { SysRoutingModule } from './sys-routing.module';

// 角色管理模块组件
import { SysRoleRoleListComponent } from './role/role-list/role-list.component';
import { SysRoleListRoleAddComponent } from './role/role-add/role-add.component';
import { RolePermissionComponent } from './role/role-permission/role-permission.component';

// 权限管理模块组件
import { PermissionAddComponent } from './permission/permission-add/permission-add.component';
import { PermissionListComponent } from './permission/permission-list/permission-list.component';
import { PermissionOperationComponent } from './permission/permission-operation/permission-operation.component';

// 菜单管理模块
import { MenuListComponent } from './menu/menu-list/menu-list.component';
import { MenuAddComponent } from './menu/menu-add/menu-add.component';
import { MenuRootComponent } from './menu/menu-root/menu-root.component';
import { MenuPageAddComponent } from './menu/menu-page-add/menu-page-add.component';

const COMPONENTS = [SysRoleRoleListComponent];

const COMPONENTS_NOROUNT = [
  SysRoleListRoleAddComponent,
  RolePermissionComponent,
  PermissionAddComponent,
  PermissionListComponent,
  PermissionOperationComponent,
  MenuListComponent,
  MenuAddComponent,
  MenuRootComponent,
  MenuPageAddComponent,
];

@NgModule({
  imports: [SharedModule, SysRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
  providers: [],
})
export class SysModule {}
