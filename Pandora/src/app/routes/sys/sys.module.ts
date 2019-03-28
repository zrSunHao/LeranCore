import { NgModule } from '@angular/core';
import { SharedModule } from '@shared';
import { ScrollingModule } from '@angular/cdk/scrolling';

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

// 服务
import { BasicOperateService } from './_core/basic-services/basic-operate.service';

// 账号管理模块
import { AccountLockoutComponent } from './account/account-lockout/account-lockout.component';
import { AccountAddComponent } from './account/account-add/account-add.component';
import { AccountListComponent } from './account/account-list/account-list.component';
import { AccountStatusComponent } from './account/account-status/account-status.component';

// 用户信息管理模块
import { UserInfoComponent } from './user/user-info/user-info.component';
import { UserBindingComponent } from './user/user-binding/user-binding.component';
import { UserNotificationComponent } from './user/user-notification/user-notification.component';
import { UserSecurityComponent } from './user/user-security/user-security.component';
import { UserComponent } from './user/user.component';

const COMPONENTS = [];

const COMPONENTS_NOROUNT = [
  SysRoleListRoleAddComponent,
  SysRoleRoleListComponent,
  RolePermissionComponent,
  PermissionAddComponent,
  PermissionListComponent,
  PermissionOperationComponent,
  MenuListComponent,
  MenuAddComponent,
  MenuRootComponent,
  MenuPageAddComponent,
  AccountListComponent,
  AccountAddComponent,
  AccountLockoutComponent,
  AccountStatusComponent,
  UserComponent,
  UserInfoComponent,
  UserBindingComponent,
  UserNotificationComponent,
  UserSecurityComponent,
];

@NgModule({
  imports: [SharedModule, ScrollingModule, SysRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
  providers: [
    // { provide: NZ_NOTIFICATION_CONFIG, useValue: { nzDuration: 3000 } },
    BasicOperateService,
  ],
})
export class SysModule {}
