import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { NzNotificationService, NzModalService } from 'ng-zorro-antd';
import { MenuAddComponent } from '../menu-add/menu-add.component';
import { MenuListComponent } from '../menu-list/menu-list.component';
import { MenuPageAddComponent } from '../menu-page-add/menu-page-add.component';
import { PagingOptions } from '@shared/model/query-params.model';

const GetMenusUrl = 'Menu/GetMenus';
const ActiveMenuUrl = 'Menu/ActiveMenu';
const DeleteMenuUrl = 'Menu/DeleteMenu';

@Component({
  selector: 'app-menu-root',
  templateUrl: './menu-root.component.html',
  styles: ['./menu-root.component.less'],
})
export class MenuRootComponent implements OnInit {
  @ViewChild('menulist') menulist: MenuListComponent;

  list = [];
  total = 0;
  loading = false;
  paging = new PagingOptions(null, 0, 5);

  constructor(
    private modal: ModalHelper,
    private http: _HttpClient,
    private modalService: NzModalService,
    private notification: NzNotificationService,
  ) {}

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.loading = true;
    this.http.post(GetMenusUrl, this.paging).subscribe(
      (res: any) => {
        if (!res.success) {
          this.notification.create(
            'error',
            '菜单列表数据加载失败',
            res.allMessages,
          );
          this.list = [];
          this.total = 0;
        } else {
          this.total = res.rowsCount;
          if (res.data == null) {
            res.data = [];
          } else {
            this.list = res.data;
          }
        }
        this.loading = false;
      },
      (err: any) => {
        this.loading = false;
      },
    );
  }

  add() {
    const isEdit = false;
    const title = '添加菜单';
    const entity = {
      id: null,
      name: null,
      icon: null,
      tagColor: null,
      intro: null,
      order: null,
    };

    this.modal
      .createStatic(MenuAddComponent, { entity, isEdit, title })
      .subscribe(res => {
        this.loadData();
      });
  }

  edit(item) {
    const isEdit = true;
    const title = '修改菜单';
    const entity = {
      id: item.id,
      name: item.name,
      icon: item.icon,
      tagColor: item.tagColor,
      intro: item.intro,
      order: item.order,
    };

    this.modal
      .createStatic(MenuAddComponent, { entity, isEdit, title })
      .subscribe(res => {
        this.loadData();
      });
  }

  active(item) {
    const active = item.active;
    let msg = '';
    if (active) {
      msg = '关闭';
    } else {
      msg = '开启';
    }

    this.http
      .post(ActiveMenuUrl, { id: item.id, active: !active })
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

  deleteConfirm(item) {
    this.modalService.confirm({
      nzTitle: `<i>真的要删除【${item.name}】吗？</i>`,
      nzContent: '<b></b>',
      nzOnOk: () => this.delete(item),
    });
  }

  delete(item) {
    this.http.get(DeleteMenuUrl, { id: item.id }).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '删除失败', res.allMessages);
        return;
      }
      this.notification.create('success', '删除成功', res.allMessages);
      this.loadData();
    });
  }

  clickRow(item) {
    this.menulist.loadData(item);
  }

  addPage(item) {
    const isEdit = false;
    const title = '添加页面';
    const entity = {
      id: null,
      name: null,
      url: null,
      icon: null,
      tagColor: item.tagColor,
      intro: null,
      order: null,
      moduleId: null,
      menuId: item.id,
      menuName: item.name,
    };

    this.modal
      .createStatic(MenuPageAddComponent, { entity, isEdit, title })
      // tslint:disable-next-line:no-shadowed-variable
      .subscribe(res => {
        this.menulist.loadData(item);
      });
  }

  pageIndexChange(event) {
    this.paging.pageIndex = event;
    this.loadData();
  }

  pageSizeChange(event) {
    this.paging.pageSize = event;
    this.loadData();
  }
}
