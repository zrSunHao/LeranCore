import { PermissionTreeComponent } from './permission-tree/permission-tree.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SysRoleRoleListComponent } from './role/role-list/role-list.component';

const routes: Routes = [
  { path: 'role-list', component: SysRoleRoleListComponent , data: { title: '角色管理列表' }},
  { path: 'permission-tree', component: PermissionTreeComponent , data: { title: '角色管理列表' }}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SysRoutingModule { }
