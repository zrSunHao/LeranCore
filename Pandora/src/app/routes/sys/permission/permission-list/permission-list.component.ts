import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { SFSchema } from '@delon/form';
import { STComponent, STColumn, STColumnTag } from '@delon/abc';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { PermissionAddComponent } from '../permission-add/permission-add.component';
import { PermissionOperationComponent } from '../permission-operation/permission-operation.component';
import { NzNotificationService } from 'ng-zorro-antd';

const GetPermissionUrl = 'Permission/GetPermission';
const DeletePermissionUrl = 'Permission/DeletePermission';
const ActivePermissionUrl = 'Permission/ActivePermission';

@Component({
  selector: 'app-permission-list',
  templateUrl: './permission-list.component.html',
  styles: [],
})
export class PermissionListComponent implements OnInit {
  @ViewChild('pmsopt') pmsopt: PermissionOperationComponent;
  @ViewChild('st') st: STComponent;
  // 列表数据
  datas: Array<any> = [];
  // 列表搜索条件
  searchSchema: SFSchema = {
    properties: {
      name: { type: 'string', title: '模块名称' },
    },
  };

  // 列表行列格式
  columns: STColumn[] = [
    { title: '模块名称', render: 'name', className: 'text-center' },
    { title: '备注', index: 'intro', className: 'text-center' },
    {
      title: '是否启用',
      render: 'custom',
      className: 'text-center',
      click: (item: any) => this.activeModule(item),
    },
    {
      title: '操作',
      className: 'text-center',
      buttons: [
        {
          text: '编辑',
          icon: 'anticon anticon-edit',
          click: (item: any) => this.editModule(item),
        },
        {
          text: '添加权限',
          icon: 'anticon anticon-plus',
          click: (item: any) => this.addOperation(item),
        },
        {
          text: '删除',
          icon: 'anticon anticon-delete',
          click: (item: any) => this.deleteModule(item),
        },
      ],
    },
  ];

  constructor(private modal: ModalHelper, private http: _HttpClient, private notification: NzNotificationService) { }

  ngOnInit() {
    this.loadDatas('');
  }

  loadDatas(name: string) {
    const url = 'permission/getmodulepermission';
    this.http.post(url, { name: '', }).subscribe((res: any) => {
      if (!res.success) {
        return;
      }
      this.datas = res.data;
    });
  }

  search(event) {
    this.loadDatas(event.name);
  }

  reset(event) {
    this.loadDatas('');
  }

  rowClick(event) {
    this.pmsopt.loadData(event.click.item);
  }

  addModule() {
    const isEdit = false;
    const title = '添加模块';
    const entity = {
      name: null,
      code: null,
      icon: null,
      tagColor: null,
      intro: null,
      isModule: true,
    };

    this.modal
      .createStatic(PermissionAddComponent, { entity, isEdit, title })
      .subscribe(res => {
        // this.datas.push(res);
        this.loadDatas('');
      });
  }

  editModule(item: any) {
    const isEdit = true;
    const title = '编辑模块';
    const entity = {
      id: item.id,
      name: item.name,
      code: item.code,
      icon: item.icon,
      tagColor: item.tagColor,
      intro: item.intro,
    };

    this.modal
      .createStatic(PermissionAddComponent, { entity, isEdit, title })
      .subscribe(res => {
        this.loadDatas('');
      });
  }

  deleteModule(item: any) {
    const url = 'permission/delete';

    this.http.get(url, { id: item.id }).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '删除失败', res.allMessages);
        return;
      }
      this.notification.create('success', '删除成功', res.allMessages);
      this.loadDatas('');
    });
  }

  activeModule(item: any) {
    const url = 'permission/active';
    const active = item.active;
    let msg = '';
    if (active) {
      msg = '关闭';
    } else {
      msg = '开启';
    }

    this.http.post(url, { id: item.id, active: !active }).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', msg + '失败', res.allMessages);
        item.active = active;
        return;
      }
      this.notification.create('success', msg + '成功', res.allMessages);
      item.active = !active;
    });
  }

  addOperation(item: any) {
    const isEdit = false;
    const title = '修改操作权限';
    const entity = {
      name: null,
      code: null,
      icon: null,
      tagColor: item.tagColor,
      intro: null,
      parentId: item.id,
    };

    this.modal
      .createStatic(PermissionAddComponent, { entity, isEdit, title })
      .subscribe(res => {
        // this.datas.push(res);
        this.pmsopt.loadData(item);
        console.log(res);
      });
  }
}
