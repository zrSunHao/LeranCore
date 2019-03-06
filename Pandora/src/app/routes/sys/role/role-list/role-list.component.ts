import { Component, OnInit, ViewChild } from '@angular/core';
import { _HttpClient, ModalHelper } from '@delon/theme';
import { STColumn, STComponent } from '@delon/abc';
import { SFSchema } from '@delon/form';

import { SysRoleListRoleViewComponent } from '../role-view/role-view.component';
import { SysRoleListRoleAddComponent } from '../role-add/role-add.component';

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
    { title: '模块', render: 'modules', className: 'text-center' },
    { title: '简介', render: 'intro', className: 'text-center' },
    {
      title: '是否启用',
      render: 'custom',
      className: 'text-center',
      click: (item: any) => this.active(item),
    },
    {
      title: '操作',
      // buttons: [
      //   // { text: '查看', click: (item: any) => `/form/${item.id}` },
      // ]
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
          click: (item: any) => this.perssion(item),
        },
      ],
    },
  ];

  constructor(private http: _HttpClient, private modal: ModalHelper) {}

  ngOnInit() {
    this.loadRoles();
  }

  loadRoles() {
    this.http
      .post('role/getroles', {
        name: '',
      })
      .subscribe((res: any) => {
        if (!res.success) {
          console.log(res);
          return;
        }
        this.datas = res.data;
        console.log(this.datas);
      });
  }

  search(event) {
    console.log(event);
  }

  reset(event) {
    console.log(event);
  }

  add() {
    const entity = {
      name: null,
      code: null,
      icon: null,
      intro: null,
    };

    this.modal
      .createStatic(SysRoleListRoleAddComponent, { entity })
      .subscribe(() => this.st.reload());
  }

  edit(item: any) {
    const entity = item;
    this.modal
      .createStatic(SysRoleListRoleAddComponent, { entity })
      .subscribe(() => this.st.reload());
  }

  active(item: any) {}

  perssion(item: any) {
    const entity = item;
    this.modal
      .createStatic(SysRoleListRoleViewComponent, { entity })
      .subscribe(() => this.st.reload());
  }
}
