import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { SFSchema } from '@delon/form';
import { STComponent, STColumn, STColumnTag } from '@delon/abc';
import { ModalHelper } from '@delon/theme';
import { PermissionAddComponent } from '../permission-add/permission-add.component';
import { PermissionOperationComponent } from '../permission-operation/permission-operation.component';

const TAG: STColumnTag = {
  1: { text: '开启', color: 'green' },
  2: { text: '关闭', color: 'red' },
};

@Component({
  selector: 'app-permission-list',
  templateUrl: './permission-list.component.html',
  styles: [],
})
export class PermissionListComponent implements OnInit {
  @ViewChild('pmsopt') pmsopt: PermissionOperationComponent;
  @ViewChild('st') st: STComponent;
  // 列表数据
  datas: Array<any> = [{
    name: 123,
    code: 1212,
    incon: 34535,
    intro: 'sdfsgfsgs',
    active: 1,
    check: true
  }];
  // 列表搜索条件
  searchSchema: SFSchema = {
    properties: {
      name: { type: 'string', title: '模块名称', },
    },
  };
  // template: TemplateRef<'<nz-switch [ngModel]="true" nzCheckedChildren="开" nzUnCheckedChildren="关"></nz-switch>'>;
  template = '<nz-switch [ngModel]="true" nzCheckedChildren="开" nzUnCheckedChildren="关"></nz-switch>';
  // 列表行列格式
  columns: STColumn[] = [
    { title: '模块名称', index: 'name' },
    { title: '备注', index: 'intro' },
    {
      title: '自定义',
      render: 'custom',
      click: (item: any) => this.forbidModule(item),
    },
    { title: '状态', index: 'active', type: 'tag', tag: TAG },
    {
      title: '操作', buttons: [
        { text: '编辑', icon: 'anticon anticon-edit', click: (item: any) => this.editModule(item), },
        { text: '添加权限', icon: 'anticon anticon-plus', click: (item: any) => this.forbidModule(item), },
        { text: '禁用', icon: 'anticon anticon-stop', click: (item: any) => this.forbidModule(item), },
        { text: '删除', icon: 'anticon anticon-delete', click: (item: any) => this.deleteModule(item), },
      ],
    },
  ];

  constructor(
    private modal: ModalHelper
  ) { }

  ngOnInit() { }

  loadDatas() { }

  search(event) {
    console.log(event);
  }

  reset(event) {
    console.log(event);
  }

  rowClick(event) {
    // console.log(event);
    this.pmsopt.test(event);
  }

  addModule() {
    const entity = {
      name: null,
      code: null,
      icon: null,
      intro: null
    };

    this.modal
      .createStatic(PermissionAddComponent, { entity })
      .subscribe((res) => {
        this.datas.push(res);
        this.st.reload();
        console.log(res);
      });
  }



  editModule(item: any) {
    const entity = {
      name: item.name,
      code: item.code,
      icon: item.icon,
      intro: item.intro
    };

    this.modal
      .createStatic(PermissionAddComponent, { entity })
      .subscribe((res) => {
        this.st.reload();
        console.log(res);
      });
  }

  deleteModule(item: any) { }

  forbidModule(item: any) {
    item.active = 2;
    this.st.reload();
    console.log(item);
  }

  addOperation(item: any) {
    const entity = {
      name: null,
      code: null,
      icon: null,
      intro: null,
      parentId: null
    };

    this.modal
      .createStatic(PermissionAddComponent, { entity })
      .subscribe((res) => {
        this.datas.push(res);
        console.log(res);
      });
  }



  apiSearchModule(data: any) {
    const url = '';
  }

  apiAddModule(data: any) {
    const url = '';
  }

  apiEditModule(data: any) {
    const url = '';
  }

  apiDeleteModule(id: any) {
    const url = '';
  }

  apiAddhModuleOperation(data: any) {
    const url = '';
  }
}
