import { Component, OnInit, Injector } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { _HttpClient } from '@delon/theme';

const GetRolePermissionsUrl = 'Role/GetRolePermissions';
const EditRolePermissionUrl = 'Role/EditRolePermission';

@Component({
  selector: 'app-role-permission',
  templateUrl: './role-permission.component.html',
  styles: [],
})
export class RolePermissionComponent implements OnInit {
  roleId: any;
  listOfData = [];

  constructor(
    private route: ActivatedRoute,
    private http: _HttpClient,
    private injector: Injector,
  ) {}

  ngOnInit() {
    this.roleId = this.route.snapshot.params[`id`];
    this.loadDatas();
    console.log(this.roleId);
  }

  loadDatas() {
    this.http
      .get(GetRolePermissionsUrl, { id: this.roleId })
      .subscribe((res: any) => {
        if (!res.success) {
          return;
        }
        this.listOfData = res.data;
      });
  }

  checkModule(item) {
    const checked = item.checked;
    // tslint:disable-next-line:prefer-for-of
    for (let i = 0; i < this.listOfData.length; i++) {
      if (this.listOfData[i].id === item.id) {
        // tslint:disable-next-line:prefer-for-of
        for (let j = 0; j < this.listOfData[i].permissions.length; j++) {
          this.listOfData[i].permissions[j].checked = checked;
        }
      }
    }
  }

  checkOperate(item) {
    // tslint:disable-next-line:prefer-for-of
    for (let i = 0; i < this.listOfData.length; i++) {
      if (this.listOfData[i].id === item.pageId) {
        let flag = false;
        // tslint:disable-next-line:prefer-for-of
        for (let j = 0; j < this.listOfData[i].permissions.length; j++) {
          if (this.listOfData[i].permissions[j].checked) {
            flag = true;
          }
        }
        this.listOfData[i].checked = flag;
      }
    }
  }

  save() {
    const pageIds = [];
    const permissionAndPageIds = [];
    const pages = this.listOfData;
    // tslint:disable-next-line:prefer-for-of
    for (let i = 0; i < pages.length; i++) {
      if (pages[i].checked) {
        pageIds.push(pages[i].id);
        const permissions = pages[i].permissions;
        // tslint:disable-next-line:prefer-for-of
        for (let j = 0; j < permissions.length; j++) {
          if (permissions[j].checked) {
            const dto = {
              pageId: pages[i].id,
              PermissionId: permissions[j].id,
            };
            permissionAndPageIds.push(dto);
          }
        }
      }
    }
    const dto = {
      roleId: this.roleId,
      permissionAndPageIds,
      pageIds,
    };
    console.log(dto);
  }

  back() {
    this.injector.get(Router).navigateByUrl(`/sys/role-list`);
  }
}
