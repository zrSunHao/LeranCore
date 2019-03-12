import { AccountActiveComponent } from './../account-active/account-active.component';
import { AccountLockoutComponent } from './../account-lockout/account-lockout.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { STComponent, STColumn, STChange } from '@delon/abc';
import { SFSchema } from '@delon/form';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { NzNotificationService } from 'ng-zorro-antd';
import { PagingOptions } from '@shared/model/query-params.model';
import { AccountAddComponent } from '../account-add/account-add.component';

const activeItem = [
  { label: '请选择', value: 2 },
  { label: '开启', value: 1 },
  { label: '禁用', value: 0 },
];

@Component({
  selector: 'app-account-list',
  templateUrl: './account-list.component.html',
  styles: [],
})
export class AccountListComponent implements OnInit {
  @ViewChild('st') st: STComponent;
  // 列表数据
  datas: Array<any> = [];
  // 选中的列表行
  selectRows: Array<any> = [];
  // 列表搜索条件
  searchSchema: SFSchema = {
    properties: {
      userName: {
        type: 'string',
        title: '用户名',
        ui: { autosize: true, grid: { span: 6 } },
      },
      email: {
        type: 'string',
        title: '邮箱',
        ui: { autosize: true, grid: { span: 6 } },
      },
      role: {
        type: 'string',
        title: '角色',
        ui: { autosize: true, grid: { span: 6 } },
      },
      active: {
        type: 'string',
        title: '启用或禁用',
        enum: activeItem,
        default: 2,
        ui: { widget: 'select', grid: { span: 6 } },
      },
      CreatedAtStart: {
        type: 'string',
        title: '创建时间-开始',
        format: 'date',
        ui: { autosize: true, grid: { span: 6 } },
      },
      CreatedAtEnd: {
        type: 'string',
        title: '创建时间-结束',
        format: 'date',
        ui: { autosize: true, grid: { span: 6 } },
      },
      LatestLoginAtStart: {
        type: 'string',
        title: '最近登录时间-开始',
        format: 'date',
        ui: { autosize: true, grid: { span: 6 } },
      },
      LatestLoginAtEnd: {
        type: 'string',
        title: '最近登录时间-结束',
        format: 'date',
        ui: { autosize: true, grid: { span: 6 } },
      },
    },
  };

  roleItems = [];

  // 列表行列格式
  columns: STColumn[] = [
    { title: 'ID', index: 'id', type: 'checkbox', selections: [] },
    { title: '用户名', index: 'userName', className: 'text-center' },
    { title: '邮箱', index: 'email', className: 'text-center' },
    { title: '角色', index: 'role', className: 'text-center' },
    {
      title: '创建时间',
      index: 'createdAt',
      type: 'date',
      className: 'text-center',
    },
    {
      title: '最近登录时间',
      index: 'latestLoginAt',
      type: 'date',
      className: 'text-center',
    },
    {
      title: '登陆失败次数',
      index: 'accessFailedCount',
      className: 'text-center',
    },
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

  constructor(
    private modal: ModalHelper,
    private http: _HttpClient,
    private notification: NzNotificationService,
  ) {}

  ngOnInit() {
    this.loadData({});
  }

  loadData(dto: any) {
    const entity = this.getQueryParams(dto);
    const queryParams = new PagingOptions<any>(entity);

    const url = 'auth/accounts';
    this.http.post(url, queryParams).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '列表数据加载失败', res.errMsg);
      }
      this.datas = res.data;
    });
  }

  getQueryParams(dto: any): any {
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

    const queryParams = new PagingOptions<any>(entity);

    return queryParams;
  }

  search(event) {
    console.log(event);
    this.loadData(event);
  }

  reset(event) {
    this.loadData(event);
  }

  addAccount() {
    const isEdit = false;
    const title = '添加账号';
    const entity = {
      userName: null,
      email: null,
      roleId: null,
    };

    localStorage.setItem('roleItems', JSON.stringify(this.roleItems));

    this.modal
      .createStatic(AccountAddComponent, { entity, isEdit, title })
      // tslint:disable-next-line:no-shadowed-variable
      .subscribe(res => {
        // TODO 加载列表数据
      });
  }

  activeAccount(item) {
    const url = 'auth/activeAccount';
    const active = item.active;
    let msg = '';
    if (active) {
      msg = '关闭';
    } else {
      msg = '开启';
    }

    this.http
      .post(url, { id: item.id, active: !active })
      .subscribe((res: any) => {
        if (!res.success) {
          this.notification.create('error', msg + '失败', res.allMessages);
          item.active = active;
          return;
        }
        this.notification.create('success', msg + '成功', res.allMessages);
        item.active = !active;
      });
  }

  editAccount(item) {
    const isEdit = true;
    const title = '修改账号';
    const entity = {
      userName: item.userName,
      email: item.email,
      roleId: item.roleId,
    };

    this.modal
      .createStatic(AccountAddComponent, { entity, isEdit, title })
      // tslint:disable-next-line:no-shadowed-variable
      .subscribe(res => {
        // TODO 加载列表数据
      });
  }

  // TODO 单条锁定
  lockoutAccount(item) {}

  // TODO 批量锁定
  lockoutAccounts() {
    const rows = this.selectRows;
    const rowIds = [];
    rows.forEach(row => {
      rowIds.push(row.id);
    });

    if (rowIds.length < 1) {
      this.notification.create('error', '账号锁定错误提示', '请选择账号');
      return;
    } else {
      const warningMsg = '共选择了' + rows.length + '个账号，请谨慎操作';
      const title = '批量锁定账号';
      this.lockout(rowIds, title, warningMsg);
    }
  }

  // TODO 批量禁用
  activeAccounts() {
    const rows = this.selectRows;
    const rowIds = [];
    rows.forEach(row => {
      rowIds.push(row.id);
    });

    if (rowIds.length < 1) {
      this.notification.create('error', '账号启用、禁用错误提示', '请选择账号');
      return;
    } else {
      const warningMsg = '共选择了' + rows.length + '个账号，请谨慎操作';
      const title = '批量禁用账号';
      this.active(rowIds, title, warningMsg);
    }
  }

  // TODO 加载列表数据
  deleteAccount(item) {
    const url = 'auth/deleteAccount';

    this.http.get(url, { id: item.id }).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '删除失败', res.allMessages);
        return;
      }
      this.notification.create('success', '删除成功', res.allMessages);
      // TODO 加载列表数据
    });
  }

  rowClick(event) {}

  active(entity: any, title: string, warningMsg) {
    this.modal
      .createStatic(
        AccountActiveComponent,
        { entity, title, warningMsg },
        { size: 'md' },
      )
      // tslint:disable-next-line:no-shadowed-variable
      .subscribe(res => {
        // TODO 加载列表数据
      });
  }

  lockout(entity: any, title: string, warningMsg) {
    this.modal
      .createStatic(
        AccountLockoutComponent,
        { entity, title, warningMsg },
        { size: 'md' },
      )
      // tslint:disable-next-line:no-shadowed-variable
      .subscribe(res => {
        // TODO 加载列表数据
      });
  }

  change(event: STChange) {
    console.log('change', event);
    this.selectRows = event.checkbox;
  }

  getRowIds(): any[] {
    const rows = this.selectRows;
    const rowIds = [];
    rows.forEach(row => {
      rowIds.push(row.id);
    });
    console.log(rowIds);
    return rowIds;
  }

  loadRoleItem() {
    const url = 'permission/getRoleItems';
    this.http.get(url).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create(
          'error',
          '模块下拉框数据加载失败',
          res.allMessages,
        );
      }
      if (res.data != null) {
        this.roleItems = res.data;
      }
    });
  }
}
