import { map } from 'rxjs/operators';
import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { _HttpClient, ModalHelper } from '@delon/theme';
import { STColumn, STComponent, STPage, STChange } from '@delon/abc';
import { SFSchema } from '@delon/form';
import { SysRoleListRoleAddComponent } from '../role-add/role-add.component';
import { Router } from '@angular/router';
import { NzNotificationService } from 'ng-zorro-antd';
import { ACLType } from '@delon/acl';
import { PagingOptions, PagingSort } from '@shared/model/query-params.model';

const GetRolesUrl = 'Role/GetRoles';
const ActiveRoleUrl = 'Role/ActiveRole';
const DeleteRoleUrl = 'Role/DeleteRole';

@Component({
  selector: 'app-sys-role-role-list',
  templateUrl: './role-list.component.html',
})
export class SysRoleRoleListComponent implements OnInit {
  datas: Array<any> = [];
  data: any = {
    list: [],
    total: 0,
  };
  loading = false;
  params = { name: '', pageName: '' };
  dto = new PagingOptions(null, 1, 10);;

  page: STChange = { type: 'pi', pi: 1, ps: 10, total: 0 };
  searchSchema: SFSchema = {
    properties: {
      name: {
        type: 'string',
        title: '角色名称',
      },
      pageName: {
        type: 'string',
        title: '访问页面',
      },
    },
  };

  @ViewChild('st') st: STComponent;
  columns: STColumn[] = [
    { title: '角色名称', render: 'name', className: 'text-center', sort: true },
    { title: '访问页面', render: 'pageNames', className: 'text-center' },
    { title: '简介', render: 'intro', className: 'text-center' },
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
          acl: {
            ability: [10, 'Role.GetRolePermissions'],
            mode: 'oneOf',
          } as ACLType,
          click: (item: any) =>
            this.injector
              .get(Router)
              .navigateByUrl(`/sys/role-permission-list/${item.id}`),
        },
        {
          text: '删除',
          icon: 'anticon anticon-delete',
          acl: { ability: [10, 'Role.DeleteRole'], mode: 'oneOf' } as ACLType,
          click: (item: any) => this.delete(item),
        },
      ],
    },
  ];

  stPage: STPage = {
    front: false,
    showQuickJumper: true,
    total: true,
    showSize: true,
    pageSizes: [1, 10, 20, 30, 40, 50],
  };

  constructor(
    private http: _HttpClient,
    private modal: ModalHelper,
    private injector: Injector,
    private notification: NzNotificationService,
  ) {}

  ngOnInit() {
    this.loadRoles();
  }

  loadRoles() {
    this.loading = true;
    this.http.post(GetRolesUrl, { name: '' }).subscribe(
      (res: any) => {
        if (!res.success) {
        } else {
          this.data.list = res.data;
          this.data.total = this.data.list.length;
        }
        this.loading = false;
      },
      (err: any) => {
        this.loading = false;
      },
    );
  }

  search(event) {
    this.params.name = event.name;
    this.params.pageName = event.pageName;
    this.dto.filters = this.params;
    console.log(this.dto);
  }

  reset(event) {
    this.params.name = null;
    this.params.pageName = null;
    this.dto.filters = this.params;
    console.log(this.dto);
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
      .subscribe(res => {
        if (res != null) {
          this.loadRoles();
        }
      });
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
      .subscribe(res => {
        if (res != null) {
          this.loadRoles();
        }
      });
  }

  delete(item: any) {
    this.loading = true;
    this.http.get(DeleteRoleUrl, { roleId: item.id }).subscribe(
      (res: any) => {
        this.loading = false;
        if (!res.success) {
          this.notification.create('error', '删除失败', res.allMessages);
        } else {
          this.notification.create('success', '删除成功', res.allMessages);
          this.loadRoles();
        }
      },
      (err: any) => {
        this.loading = false;
      },
    );
  }

  active(item: any) {
    const active = item.active;
    let msg = '';
    if (active) {
      msg = '关闭';
    } else {
      msg = '开启';
    }

    this.loading = true;
    this.http.post(ActiveRoleUrl, { id: item.id, active: !active }).subscribe(
      (res: any) => {
        this.loading = false;
        if (!res.success) {
          this.notification.create('error', msg + '失败', res.allMessages);
          item.active = active;
          return;
        }
        this.notification.create('success', msg + '成功', res.allMessages);
        item.active = !active;
      },
      (err: any) => {
        this.loading = false;
      },
    );
  }

  _click(event: STChange) {
    console.log(event); // PagingOptions
    if (event.type === 'pi' || event.type === 'ps' || event.type === 'sort') {
      this.dto.pageIndex = event.pi;
      this.dto.pageSize = event.ps;
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
        this.dto.sort = sorts;
      }
      console.log(this.dto);
    }
  }
}
