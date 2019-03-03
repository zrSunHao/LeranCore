import { NgModule } from '@angular/core';
import { SharedModule } from '@shared';

import { SysRoutingModule } from './sys-routing.module';

// 角色管理模块组件
import { SysRoleRoleListComponent } from './role/role-list/role-list.component';
import { SysRoleListRoleViewComponent } from './role/role-view/role-view.component';
import { SysRoleListRoleAddComponent } from './role/role-add/role-add.component';
import { RolePermissionComponent } from './role/role-permission/role-permission.component';

// 权限管理模块组件
import { PermissionTreeComponent } from './permission/permission-tree/permission-tree.component';
import { PermissionAddComponent } from './permission/permission-add/permission-add.component';

const COMPONENTS = [
  SysRoleRoleListComponent
];

const COMPONENTS_NOROUNT = [
  SysRoleListRoleViewComponent,
  SysRoleListRoleAddComponent,
  RolePermissionComponent,
  PermissionTreeComponent,
  PermissionAddComponent
];

@NgModule({
  imports: [
    SharedModule,
    SysRoutingModule
  ],
  declarations: [
    ...COMPONENTS,
    ...COMPONENTS_NOROUNT
  ],
  entryComponents: COMPONENTS_NOROUNT,
  providers: []
})
export class SysModule { }
