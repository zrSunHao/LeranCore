import { NgModule } from '@angular/core';
import { SharedModule } from '@shared';
import { SysRoutingModule } from './sys-routing.module';
import { SysRoleRoleListComponent } from './role/role-list/role-list.component';

import { SysService } from './_service/sys.service';

const COMPONENTS = [
  SysRoleRoleListComponent
];

const COMPONENTS_NOROUNT = [

];

const SERVICES = [
  SysService
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
  providers: SERVICES
})
export class SysModule { }
