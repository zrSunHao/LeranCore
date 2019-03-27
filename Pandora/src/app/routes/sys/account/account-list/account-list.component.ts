import { AccountLockoutComponent } from './../account-lockout/account-lockout.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { STComponent, STColumn, STChange, STPage } from '@delon/abc';
import { SFSchema } from '@delon/form';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { NzNotificationService } from 'ng-zorro-antd';
import { PagingOptions, PagingSort } from '@shared/model/query-params.model';
import { AccountAddComponent } from '../account-add/account-add.component';
import { AccountStatusComponent } from '../account-status/account-status.component';
import { ACLType } from '@delon/acl';

const GetAccountsUrl = 'Auth/Accounts';
const ActiveAccountUrl = 'Auth/ActiveAccount';
const DeleteAccountUrl = 'Auth/DeleteAccount';
const BatchDeleteAccountUrl = 'Auth/BatchDeleteAccount';
const GetRoleItemsUrl = 'Role/GetRoleItems';

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
  list: Array<any> = [];
  total = 0;
  loading = false;
  params = {
    nickname: null,
    email: null,
    role: null,
    active: null,
  };
  paging = new PagingOptions(null, 0, 10);
  // 选中的列表行
  selectRows: Array<any> = [];
  // 列表搜索条件
  searchSchema: SFSchema = {
    properties: {
      nickname: {
        type: 'string',
        title: '昵称',
        ui: { autosize: true, grid: { span: 6 }, placeholder: '支持模糊搜索' },
      },
      email: {
        type: 'string',
        title: '邮箱',
        ui: { autosize: true, grid: { span: 6 }, placeholder: '支持模糊搜索' },
      },
      role: {
        type: 'string',
        title: '角色',
        ui: { autosize: true, grid: { span: 6 }, placeholder: '支持模糊搜索' },
      },
      active: {
        type: 'string',
        title: '状态',
        enum: activeItem,
        default: 2,
        ui: { widget: 'select', grid: { span: 6 } },
      },
    },
    ui: {
      spanLabelFixed: 130,
      grid: { span: 6 },
    },
  };

  roleItems = [];

  // 列表行列格式
  columns: STColumn[] = [
    { title: 'ID', index: 'id', type: 'checkbox', selections: [] },
    { title: '头像', type: 'img', width: '50px', index: 'avatarUrl' },
    { title: '用户名', index: 'userName', className: 'text-center' },
    { title: '邮箱', index: 'email', className: 'text-center' },
    { title: '角色', render: 'roleName', className: 'text-center' },
    {
      title: '创建时间',
      index: 'createdAt',
      type: 'date',
      className: 'text-center',
    },
    {
      title: '最近登录',
      index: 'latestLoginAt',
      type: 'date',
      className: 'text-center',
    },
    {
      title: '登陆失败',
      index: 'accessFailedCount',
      className: 'text-center',
    },
    {
      title: '启用',
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
          acl: {
            ability: [10, 'Auth.DeleteAccount'],
            mode: 'oneOf',
          } as ACLType,
          click: (item: any) => this.deleteAccount(item),
        },
      ],
    },
  ];

  stPage: STPage = {
    front: false,
    showQuickJumper: true,
    total: true,
    showSize: true,
    pageSizes: [5, 10, 20, 30, 40, 50],
  };

  constructor(
    private modal: ModalHelper,
    private http: _HttpClient,
    private notification: NzNotificationService,
  ) {}

  ngOnInit() {
    this.loadData();
    this.loadRoleItem();
  }

  addAccount() {
    const isEdit = false;
    const title = '添加账号';
    const warningMsg = '添加账号的正常途径是用户自行注册，请慎重考虑';
    const entity = { userName: null, email: null, roleId: null };

    this.modal
      .createStatic(
        AccountAddComponent,
        { entity, isEdit, title, warningMsg },
        { size: 'md' },
      )
      // tslint:disable-next-line:no-shadowed-variable
      .subscribe(res => {
        if (res != null) {
          this.loadData();
        }
      });
  }

  activeAccount(item) {
    const active = item.active;
    let msg = '';
    if (active) {
      msg = '关闭';
    } else {
      msg = '开启';
    }

    this.http
      .post(ActiveAccountUrl, { id: item.id, active: !active })
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
    const warningMsg = '添加账号的正常途径是用户自行修改，请慎重考虑';
    const entity = {
      id: item.id,
      userName: item.userName,
      email: item.email,
      roleId: item.roleId,
    };

    this.modal
      .createStatic(
        AccountAddComponent,
        { entity, isEdit, title, warningMsg },
        { size: 'md' },
      )
      // tslint:disable-next-line:no-shadowed-variable
      .subscribe(res => {
        // TODO 加载列表数据
      });
  }

  // 单条锁定
  lockoutAccount(item) {
    const isEdit = false;
    const title = '锁订账号';
    const warningMsg = '在锁订到期之前该账号不能登录，请慎重考虑';
    const warningMsgTitle = `锁订[${item.userName}]账号警告`;
    const entity = { id: item.id, lockoutEndAt: item.lockoutEndAt };

    localStorage.setItem('roleItems', JSON.stringify(this.roleItems));

    this.modal
      .createStatic(
        AccountLockoutComponent,
        { entity, isEdit, title, warningMsg, warningMsgTitle },
        { size: 'md' },
      )
      // tslint:disable-next-line:no-shadowed-variable
      .subscribe(res => {
        if (res != null) {
          this.loadData();
        }
      });
  }

  statusAccounts() {
    const rows = this.selectRows;
    const rowIds = [];
    rows.forEach(row => {
      rowIds.push(row.id);
    });

    if (rowIds.length < 1) {
      this.notification.create(
        'error',
        '账号状态错误提示',
        '请选择要操作的账号',
      );
    } else {
      const warningMsg = '共选择了' + rows.length + '个账号，请谨慎操作';
      const title = '批量锁定账号';
      const entity = { ids: rowIds, lockoutEndAt: null, active: null };

      this.modal
        .createStatic(
          AccountStatusComponent,
          { entity, title, warningMsg },
          { size: 'md' },
        )
        // tslint:disable-next-line:no-shadowed-variable
        .subscribe(res => {
          if (res != null) {
            this.loadData();
          }
        });
    }
  }

  deleteAccount(item) {
    this.http.get(DeleteAccountUrl, { id: item.id }).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '删除失败', res.allMessages);
        return;
      } else {
        this.notification.create('success', '删除成功', res.allMessages);
        this.loadData();
      }
    });
  }

  change(event: STChange) {
    // console.log('change', event);
    this.selectRows = event.checkbox;
  }

  deleteAccounts() {
    const rows = this.selectRows;
    console.log(rows);
    const rowIds = [];
    rows.forEach(row => {
      rowIds.push(row.id);
    });
    console.log(rowIds);
    if (rowIds.length < 1) {
      this.notification.create(
        'error',
        '批量删除错误提示',
        '请选择要删除的账号',
      );
    } else {
      this.http
        .post(BatchDeleteAccountUrl, { ids: rowIds })
        .subscribe((res: any) => {
          if (!res.success) {
            this.notification.create('error', '批量删除失败', res.allMessages);
          } else {
            this.notification.create(
              'success',
              '批量删除成功',
              res.allMessages,
            );
            this.loadData();
          }
        });
    }
  }

  loadRoleItem() {
    localStorage.setItem('roleItems', JSON.stringify([]));
    this.http.get(GetRoleItemsUrl).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create(
          'error',
          '角色下拉框数据加载失败',
          res.allMessages,
        );
      }
      if (res.data != null) {
        this.roleItems = res.data;
        localStorage.setItem('roleItems', JSON.stringify(this.roleItems));
      }
    });
  }

  // ------------------------列表信息----------------------------

  search(event) {
    this.initQueryParams(event);
  }

  reset(event) {
    this.initQueryParams(event);
  }

  loadData() {
    this.loading = true;
    this.selectRows = [];
    this.paging.filter = this.params;
    this.http
      .post(GetAccountsUrl, this.paging)
      .pipe((res: any) => {
        return res;
      })
      .subscribe((res: any) => {
        this.loading = false;
        if (!res.success) {
          this.list = [];
          this.notification.create('error', '列表数据加载失败', res.errMsg);
        } else {
          this.list = res.data;
          if (res.data == null) {
            this.list = [];
          }
          this.total = res.rowsCount;
          console.log(this.list);
          console.log(res.data);
        }
      });
  }

  initQueryParams(dto: any): any {
    this.params.email = dto.email;
    this.params.nickname = dto.nickname;
    this.params.role = dto.role;
    this.params.active = dto.active;
    this.loadData();
  }

  _click(event: STChange) {
    console.log(event); // PagingOptions
    if (event.type === 'pi' || event.type === 'ps' || event.type === 'sort') {
      this.pageUtil(event);
      this.loadData();
    }
    if (event.type === 'checkbox') {
      this.selectRows = event.checkbox;
    }
  }

  pageUtil(event: STChange) {
    this.paging.pageIndex = event.pi - 1;
    this.paging.pageSize = event.ps;
    if (event.sort) {
      const sorts = [];
      const sortStr = event.sort.value;
      let field = '';
      if (event.sort.column.index) {
        field = event.sort.column.index as string;
      } else if (event.sort.column.render) {
        field = event.sort.column.render;
      }
      const sort = new PagingSort(field, sortStr);
      sorts.push(sort);
      this.paging.sort = sorts;
    }
  }
}
