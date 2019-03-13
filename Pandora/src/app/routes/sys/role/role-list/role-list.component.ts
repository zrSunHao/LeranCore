import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { _HttpClient, ModalHelper } from '@delon/theme';
import { STColumn, STComponent } from '@delon/abc';
import { SFSchema } from '@delon/form';
import { SysRoleListRoleAddComponent } from '../role-add/role-add.component';
import { Router } from '@angular/router';

const GetRolesUrl = 'Role/GetRoles';
const ActiveRoleUrl = 'Role/ActiveRole';
const DeleteRoleUrl = 'Role/DeleteRole';

@Component({
  selector: 'app-sys-role-role-list',
  templateUrl: './role-list.component.html',
})
export class SysRoleRoleListComponent implements OnInit {
  datas: Array<any> = [];
  searchSchema: SFSchema = {
    properties: {
      name: {
        type: 'string',
        title: '角色名称',
      },
    },
  };

  @ViewChild('st') st: STComponent;
  columns: STColumn[] = [
    { title: '角色名称', render: 'name', className: 'text-center' },
    { title: '访问页面', index: 'pageNames', className: 'text-center' },
    { title: '简介', index: 'intro', className: 'text-center' },
    {
      title: '开关',
      render: 'active',
      className: 'text-center',
      click: (item: any) => this.active(item),
    },
    {
      title: '操作',
      className: 'text-center',
      buttons: [
        {
          text: '编辑',
          icon: 'anticon anticon-edit',
          click: (item: any) => this.edit(item),
        },
        {
          text: '权限',
          icon: 'anticon anticon-warning',
          click: (item: any) =>
            this.injector
              .get(Router)
              .navigateByUrl(`/sys/role-permission-list/${item.id}`),
        },
        {
          text: '删除',
          icon: 'anticon anticon-delete',
          click: (item: any) => this.delete(item),
        },
      ],
    },
  ];

  constructor(
    private http: _HttpClient,
    private modal: ModalHelper,
    private injector: Injector,
  ) {}

  ngOnInit() {
    this.loadRoles();
  }

  loadRoles() {
    this.http.post(GetRolesUrl, { name: '' }).subscribe((res: any) => {
      if (!res.success) {
        console.log(res);
        return;
      } else {
        this.datas = res.data;
      }
    });
  }

  search(event) {
    console.log(event);
  }

  reset(event) {
    console.log(event);
  }

  add() {
    const isEdit = false;
    const title = '添加角色';
    const entity = { id: null, name: null, intro: null };

    this.modal
      .createStatic(
        SysRoleListRoleAddComponent,
        { entity, isEdit, title },
        { size: 'md' },
      )
      .subscribe(() => this.loadRoles());
  }

  edit(item: any) {
    const isEdit = false;
    const title = '修改角色';
    const entity = { id: item.id, name: item.name, intro: item.intro };

    this.modal
      .createStatic(
        SysRoleListRoleAddComponent,
        { entity, isEdit, title },
        { size: 'md' },
      )
      .subscribe(() => this.loadRoles());
  }

  delete(item: any) {}

  active(item: any) {}

  perssion(item: any) {}
}
