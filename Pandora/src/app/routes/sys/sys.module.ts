import { NgModule } from '@angular/core';
import { SharedModule } from '@shared';
import { SysRoutingModule } from './sys-routing.module';
import { SysRoleRoleListComponent } from './role/role-list/role-list.component';
import { SysRoleListRoleViewComponent } from './role/role-view/role-view.component';
import { SysRoleListRoleAddComponent } from './role/role-add/role-add.component';

const COMPONENTS = [
  SysRoleRoleListComponent
];

const COMPONENTS_NOROUNT = [
  SysRoleListRoleViewComponent,
  SysRoleListRoleAddComponent
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
