import { Component, OnInit, ViewChild } from '@angular/core';
import { STComponent, STColumn } from '@delon/abc';
import { SFSchema } from '@delon/form';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { NzNotificationService, isTemplateRef } from 'ng-zorro-antd';

@Component({
  selector: 'app-menu-list',
  templateUrl: './menu-list.component.html',
  styles: [],
})
export class MenuListComponent implements OnInit {
  @ViewChild('st') st: STComponent;

  menu: any;

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
    { title: '页面名称', render: 'name', className: 'text-center' },
    { title: '备注', index: 'intro', className: 'text-center' },
    {
      title: '是否启用',
      render: 'custom',
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
          text: '删除',
          icon: 'anticon anticon-delete',
          click: (item: any) => this.delete(item),
        },
      ],
    },
  ];

  constructor(
    private modal: ModalHelper,
    private http: _HttpClient,
    private notification: NzNotificationService,
  ) {}

  ngOnInit() {}

  loadData(menu: any) {
    console.log(menu);
    this.menu = menu;
    const url = 'menu/getpages';
    this.http.get(url, { id: menu.id }).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create(
          'error',
          menu.name + '下的页面列表数据加载失败',
          res.allMessages,
        );
        return;
      }
      this.datas = res.data;
    });
  }

  active(item) {}

  edit(item) {}

  delete(item) {}
}
