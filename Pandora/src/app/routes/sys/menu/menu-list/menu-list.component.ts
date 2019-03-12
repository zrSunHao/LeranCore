import { Component, OnInit, ViewChild } from '@angular/core';
import { STComponent, STColumn } from '@delon/abc';
import { SFSchema } from '@delon/form';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { NzNotificationService, isTemplateRef } from 'ng-zorro-antd';
import { MenuPageAddComponent } from '../menu-page-add/menu-page-add.component';

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
      title: '是否启用', render: 'custom', className: 'text-center',
      click: (item: any) => this.active(item),
    },
    {
      title: '操作', className: 'text-center',
      buttons: [
        {
          text: '编辑', icon: 'anticon anticon-edit',
          click: (item: any) => this.edit(item),
        },
        {
          text: '删除', icon: 'anticon anticon-delete',
          click: (item: any) => this.delete(item),
        },
      ],
    },
  ];

  constructor(
    private modal: ModalHelper,
    private http: _HttpClient,
    private notification: NzNotificationService,
  ) { }

  ngOnInit() { }

  loadData(menu: any) {
    console.log(menu);
    this.menu = menu;
    this.http.get(GetPagesUrl, { id: menu.id }).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', menu.name + '下的页面列表数据加载失败', res.allMessages);
      } else {
        this.datas = res.data;
      }
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
}
