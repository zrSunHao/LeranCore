import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { SFSchema } from '@delon/form';
import {
  STComponent,
  STColumn,
  STColumnTag,
  STChange,
  STPage,
} from '@delon/abc';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { PermissionAddComponent } from '../permission-add/permission-add.component';
import { PermissionOperationComponent } from '../permission-operation/permission-operation.component';
import { NzNotificationService } from 'ng-zorro-antd';
import { PagingOptions, PagingSort } from '@shared/model/query-params.model';

const GetAllPagesUrl = 'Menu/GetAllPages';

@Component({
  selector: 'app-permission-list',
  templateUrl: './permission-list.component.html',
  styles: [],
})
export class PermissionListComponent implements OnInit {
  list: Array<any> = [];
  total = 0;
  loading = false;
  params = { name: '', menu: '' };
  paging = new PagingOptions(null, 0, 10);

  @ViewChild('pmsopt') pmsopt: PermissionOperationComponent;
  @ViewChild('st') st: STComponent;
  schema: SFSchema = {
    properties: {
      name: {
        type: 'string',
        title: '页面名称',
        ui: { placeholder: '支持模糊搜索' },
      },
      menu: {
        type: 'string',
        title: '模块名称',
        ui: { placeholder: '支持模糊搜索' },
      },
    },
  };

  // 列表行列格式
  columns: STColumn[] = [
    { title: '页面名称', render: 'name', className: 'text-center' },
    { title: '所属模块', render: 'menu', className: 'text-center' },
    { title: '备注', render: 'intro', className: 'text-center' },
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
      rank: null,
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

  // ------------------------列表信息----------------------------

  search(event) {
    this.params.name = event.name;
    this.params.menu = event.menu;
    this.paging.filter = this.params;
    this.loadData();
  }

  reset(event) {
    this.params.name = null;
    this.params.menu = null;
    this.paging.filter = this.params;
    this.loadData();
  }

  loadData() {
    this.loading = true;
    this.http.post(GetAllPagesUrl, this.paging).subscribe(
      (res: any) => {
        if (!res.success) {
          this.list = [];
          this.notification.create(
            'error',
            '页面列表数据加载失败',
            res.allMessages,
          );
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
    if (event.type === 'pi' || event.type === 'ps' || event.type === 'sort') {
      this.pageUtil(event);
      this.loadData();
    }

    if (event.type === 'click') {
      this.pmsopt.loadData(event.click.item);
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
