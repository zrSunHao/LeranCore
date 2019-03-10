import { Component, OnInit, ViewChild } from '@angular/core';
import { STComponent, STColumn } from '@delon/abc';
import { SFSchema } from '@delon/form';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { NzNotificationService } from 'ng-zorro-antd';
import { PagingOptions } from '@shared/model/query-params.model';

@Component({
  selector: 'app-account-list',
  templateUrl: './account-list.component.html',
  styles: []
})
export class AccountListComponent implements OnInit {

  @ViewChild('st') st: STComponent;
  // 列表数据
  datas: Array<any> = [];
  // 列表搜索条件
  searchSchema: SFSchema = {
    properties: {
      userName: { type: 'string', title: '用户名', ui: { autosize: true, grid: { span: 6 } } },
      email: { type: 'string', title: '邮箱', ui: { autosize: true, grid: { span: 6 } } },
      role: { type: 'string', title: '角色', ui: { autosize: true, grid: { span: 6 } } },
      accessFailedCount: { type: 'boolean', title: '是否启用', ui: { autosize: true, grid: { span: 6 } } },
      CreatedAtStart: { type: 'string', title: '创建时间-开始', format: 'date', ui: { autosize: true, grid: { span: 6 } } },
      CreatedAtEnd: { type: 'string', title: '创建时间-结束', format: 'date', ui: { autosize: true, grid: { span: 6 } } },
      LatestLoginAtStart: { type: 'string', title: '最近登录时间-开始', format: 'date', ui: { autosize: true, grid: { span: 6 } } },
      LatestLoginAtEnd: { type: 'string', title: '最近登录时间-结束', format: 'date', ui: { autosize: true, grid: { span: 6 } } },
    }
  };

  // 列表行列格式
  columns: STColumn[] = [
    { title: '用户名', index: 'userName', className: 'text-center' },
    { title: '邮箱', index: 'email', className: 'text-center' },
    { title: '角色', index: 'role', className: 'text-center' },
    { title: '创建时间', index: 'createdAt', type: 'date', className: 'text-center' },
    { title: '最近登录时间', index: 'latestLoginAt', type: 'date', className: 'text-center' },
    { title: '登陆失败次数', index: 'accessFailedCount', className: 'text-center' },
    {
      title: '是否启用',
      render: 'custom',
      className: 'text-center',
      click: (item: any) => this.activeAccount(item),
    },
    {
      title: '操作',
      className: 'text-center',
      buttons: [
        {
          text: '编辑',
          icon: 'anticon anticon-edit',
          click: (item: any) => this.editAccount(item),
        },
        {
          text: '锁定',
          icon: 'anticon anticon-plus',
          click: (item: any) => this.lockoutAccount(item),
        },
        {
          text: '删除',
          icon: 'anticon anticon-delete',
          click: (item: any) => this.deleteAccount(item),
        },
      ],
    },
  ];


  constructor(private modal: ModalHelper, private http: _HttpClient, private notification: NzNotificationService) { }

  ngOnInit() {
    this.loadData({});
  }

  loadData(dto: any) {
    const entity = {
      email: dto.email,
      userName: dto.userName,
      role: dto.role,
      active: dto.active,
      latestLoginAtStart: dto.latestLoginAtStart,
      latestLoginAtEnd: dto.latestLoginAtEnd,
      createdAtStart: dto.createdAtStart,
      createdAtEnd: dto.createdAtEnd,
    };

    const queryParams = new PagingOptions<any>(
      entity
    );

    const url = 'auth/accounts';
    this.http.post(url, queryParams).subscribe((res: any) => {
      if (!res.success) {
        return;
      }
      this.datas = res.data;
    });
  }

  search(event) {
    console.log(event);
    this.loadData(event);
  }

  reset(event) {
    this.loadData(event);
  }

  addAccount() {

  }

  activeAccount(item) {

  }

  editAccount(item) {

  }

  lockoutAccount(item) {

  }

  deleteAccount(item) {

  }

  rowClick(event) {

  }

}
