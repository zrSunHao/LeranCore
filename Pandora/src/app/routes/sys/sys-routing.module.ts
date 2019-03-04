import { PermissionListComponent } from './permission/permission-list/permission-list.component';
import { PermissionTreeComponent } from './permission/permission-tree/permission-tree.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SysRoleRoleListComponent } from './role/role-list/role-list.component';

const routes: Routes = [
  { path: 'role-list', component: SysRoleRoleListComponent , data: { title: '角色管理列表' }},
  { path: 'permission-tree', component: PermissionTreeComponent , data: { title: '角色管理列表' }},
  { path: 'permission-list', component: PermissionListComponent , data: { title: '角色管理列表' }}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SysRoutingModule { }
