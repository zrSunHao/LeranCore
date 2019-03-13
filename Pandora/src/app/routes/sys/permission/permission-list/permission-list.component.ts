import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { SFSchema } from '@delon/form';
import { STComponent, STColumn, STColumnTag } from '@delon/abc';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { PermissionAddComponent } from '../permission-add/permission-add.component';
import { PermissionOperationComponent } from '../permission-operation/permission-operation.component';
import { NzNotificationService } from 'ng-zorro-antd';

const GetAllPagesUrl = 'Menu/GetAllPages';

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
  schema: SFSchema = {
    properties: {
      name: { type: 'string', title: '页面名称' },
    },
  };

  // 列表行列格式
  columns: STColumn[] = [
    { title: '页面名称', render: 'name', className: 'text-center' },
    { title: '所属模块', render: 'menu', className: 'text-center' },
    { title: '备注', index: 'intro', className: 'text-center' },
    {
      title: '操作',
      className: 'text-center',
      buttons: [
        {
          text: '添加权限',
          icon: 'anticon anticon-plus',
          click: (item: any) => this.addOperation(item),
        },
      ],
    },
  ];

  constructor(
    private modal: ModalHelper,
    private http: _HttpClient,
    private notification: NzNotificationService,
  ) {}

  ngOnInit() {
    this.loadDatas('');
  }

  loadDatas(name: string) {
    this.http.get(GetAllPagesUrl, { name }).subscribe((res: any) => {
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

  addOperation(item: any) {
    const isEdit = false;
    const title = `[${item.name}]添加操作权限`;
    const entity = {
      name: null,
      code: null,
      icon: null,
      tagColor: item.tagColor,
      intro: null,
      pageId: item.id,
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
