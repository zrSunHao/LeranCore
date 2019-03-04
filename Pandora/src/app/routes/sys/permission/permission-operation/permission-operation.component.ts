import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NzMessageService } from 'ng-zorro-antd';
import { SFSchema } from '@delon/form';
import { STComponent, STColumn } from '@delon/abc';

@Component({
  selector: 'app-permission-operation',
  templateUrl: './permission-operation.component.html',
  styles: []
})
export class PermissionOperationComponent implements OnInit {

  initLoading = false; // bug
  loadingMore = false;
  data = [];
  list = [
    {
      name: 111
    },
    {
      name: 111
    },
    {
      name: 111
    },
  ];

  datas: Array<any> = [];
  searchSchema: SFSchema = {
    properties: {
      name: {
        type: 'string',
        title: '角色名称'
      }
    }
  };

  @ViewChild('st') st: STComponent;
  columns: STColumn[] = [
    { title: '角色名称', index: 'name' },
    { title: '编码', index: 'code' },
    { title: '简介', index: 'intro' },
    // { title: '调用次数', type: 'number', index: 'callNo' },
    // { title: '头像', type: 'img', width: '50px', index: 'avatar' },
    { title: '时间', type: 'date', index: 'createdAt' },
    {
      title: '操作',
      // buttons: [
      //   // { text: '查看', click: (item: any) => `/form/${item.id}` },
      //   { text: '查看', type: 'static', component: SysRoleListRoleViewComponent, click: 'reload' },
      //   { text: '编辑', type: 'static', component: SysRoleListRoleAddComponent, click: 'reload' },
      // ]
      buttons: [
        {
          text: '编辑',
          click: (item: any) => this.edit(item),
        },
        {
          text: '权限',
          click: (item: any) => this.forbid(item),
        },
      ],


    }
  ];


  constructor(private http: HttpClient, private msg: NzMessageService) { }

  ngOnInit() {
  }

  getData(callback: (res: any) => void): void {

  }

  onLoadMore(): void {
    this.loadingMore = true;

  }

  edit(item: any): void {
    this.msg.success(item.email);
  }

  forbid(item: any) {

  }

}
