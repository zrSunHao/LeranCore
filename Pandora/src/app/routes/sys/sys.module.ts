import { NgModule } from '@angular/core';
import { SharedModule } from '@shared';
import { SysRoutingModule } from './sys-routing.module';
import { SysRoleRoleListComponent } from './role/role-list/role-list.component';

const COMPONENTS = [
  SysRoleRoleListComponent
];

const COMPONENTS_NOROUNT = [

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
