import { Component, OnInit, ViewChild } from '@angular/core';
import { STComponent, STColumn, STChange, STPage } from '@delon/abc';
import { SFSchema } from '@delon/form';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { NzNotificationService, isTemplateRef } from 'ng-zorro-antd';
import { MenuPageAddComponent } from '../menu-page-add/menu-page-add.component';
import { ACLType } from '@delon/acl';
import { PagingOptions, PagingSort } from '@shared/model/query-params.model';

const GetPagesUrl = 'Menu/GetPages';
const ActivePageUrl = 'Menu/ActivePage';
const DeletePageUrl = 'Menu/DeletePage';

@Component({
  selector: 'app-menu-list',
  templateUrl: './menu-list.component.html',
  styles: [],
})
export class MenuListComponent implements OnInit {
  @ViewChild('st') st: STComponent;

  list: Array<any> = [];
  total = 0;
  loading = false;
  params = { id: null, name: '' };
  paging = new PagingOptions(null, 0, 10);

  searchSchema: SFSchema = {
    properties: {
      name: {
        type: 'string',
        title: '页面名称',
        ui: { placeholder: '支持模糊搜索' },
      },
    },
  };

  menu: any;
  msgTitle = '暂无数据';
  msgDes = '点击左侧菜单即可加载该菜单下的页面数据；';

  // 列表行列格式
  columns: STColumn[] = [
    { title: '页面名称', render: 'name', className: 'text-center' },
    { title: '备注', render: 'intro', className: 'text-center' },
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
          acl: { ability: [10, 'Menu.DeletePage'], mode: 'oneOf' } as ACLType,
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
    pageSizes: [5, 10, 20, 30, 40, 50],
  };

  constructor(
    private modal: ModalHelper,
    private http: _HttpClient,
    private notification: NzNotificationService,
  ) {}

  ngOnInit() {}

  active(item) {
    const active = item.active;
    let msg = '';
    if (active) {
      msg = '关闭';
    } else {
      msg = '开启';
    }

    this.http
      .post(ActivePageUrl, { id: item.id, active: !active })
      .subscribe((res: any) => {
        if (!res.success) {
          this.notification.create('error', msg + '失败', res.allMessages);
          item.active = active;
        } else {
          this.notification.create('success', msg + '成功', res.allMessages);
          item.active = !active;
        }
      });
  }

  edit(item) {
    const isEdit = true;
    const title = '修改页面';
    const entity = {
      id: item.id,
      name: item.name,
      url: item.url,
      icon: item.icon,
      tagColor: item.tagColor,
      intro: item.intro,
      moduleId: item.moduleId,
      menuId: this.menu.id,
      menuName: this.menu.name,
    };

    this.modal
      .createStatic(MenuPageAddComponent, { entity, isEdit, title })
      // tslint:disable-next-line:no-shadowed-variable
      .subscribe(res => {
        this.loadData(this.menu);
      });
  }

  delete(item) {
    this.http.get(DeletePageUrl, { id: item.id }).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '删除失败', res.allMessages);
      } else {
        this.notification.create('success', '删除成功', res.allMessages);
        this.loadData(this.menu);
      }
    });
  }

  search(event) {
    this.params.name = event.name;
    this.loadData(this.menu);
  }

  reset(event) {
    this.params.name = null;
    this.loadData(this.menu);
  }

  loadData(menu: any) {
    this.menu = menu;
    this.msgTitle = `【${menu.name}】`;
    this.msgDes = '页面数据管理列表';
    this.params.id = menu.id;
    this.paging.filter = this.params;
    this.loading = true;

    this.http.post(GetPagesUrl, this.paging).subscribe(
      (res: any) => {
        if (!res.success) {
          this.notification.create(
            'error',
            menu.name + '下的页面列表数据加载失败',
            res.allMessages,
          );
          this.list = [];
          this.total = 0;
        } else {
          if (res.data == null) {
            this.list = [];
          } else {
            this.list = res.data;
          }
          this.total = res.rowsCount;
        }
        this.loading = false;
      },
      (err: any) => {
        this.loading = false;
      },
    );
  }

  _click(event: STChange) {
    console.log(event); // PagingOptions
    if (event.type === 'pi' || event.type === 'ps' || event.type === 'sort') {
      this.pageUtil(event);
      this.loadData(this.menu);
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
