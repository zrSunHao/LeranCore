import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { PagingOptions, PagingSort } from '@shared/model/query-params.model';
import { SFSchema } from '@delon/form';
import { STPage, STComponent, STColumn, STChange } from '@delon/abc';
import { _HttpClient, ModalHelper } from '@delon/theme';
import { NzNotificationService } from 'ng-zorro-antd';
import { SettingAddComponent } from '../setting-add/setting-add.component';

const GetSettingsUrl = 'Setting/GetSettings';

@Component({
  selector: 'app-setting-list',
  templateUrl: './setting-list.component.html',
  styles: [],
})
export class SettingListComponent implements OnInit {
  list: Array<any> = [];
  total = 0;
  loading = false;
  params = { key: null, value: null };
  paging = new PagingOptions(null, 0, 10);

  searchSchema: SFSchema = {
    properties: {
      name: {
        type: 'string',
        title: 'SettingKey',
        ui: { placeholder: '支持模糊搜索' },
      },
      pageName: {
        type: 'string',
        title: 'SettingValue',
        ui: { placeholder: '支持模糊搜索' },
      },
    },
  };

  @ViewChild('st') st: STComponent;
  columns: STColumn[] = [
    { title: 'Key', render: 'key', className: 'text-center' },
    { title: 'Value', render: 'value', className: 'text-center' },
    { title: '修改者', index: 'creator', className: 'text-center' },
    {
      title: '创建时间',
      index: 'createdAt',
      type: 'date',
      className: 'text-center',
    },
    { title: '添加者', index: 'modifier', className: 'text-center' },
    {
      title: '修改时间',
      index: 'UpdatedAt',
      type: 'date',
      className: 'text-center',
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
    private http: _HttpClient,
    private modal: ModalHelper,
    private injector: Injector,
    private notification: NzNotificationService,
  ) {}

  ngOnInit() {
    this.loadData();
  }

  add() {
    const isEdit = false;
    const title = '添加Setting';
    const entity = { id: null, key: null, value: null };

    this.modal
      .createStatic(
        SettingAddComponent,
        { entity, isEdit, title },
        { size: 'md' },
      )
      .subscribe(res => {
        if (res != null) {
          this.loadData();
        }
      });
  }

  edit(item: any) {
    const isEdit = true;
    const title = '修改Setting';
    const entity = {
      id: item.id,
      key: item.key,
      value: item.value,
    };

    this.modal
      .createStatic(
        SettingAddComponent,
        { entity, isEdit, title },
        { size: 'md' },
      )
      .subscribe(res => {
        if (res != null) {
          this.loadData();
        }
      });
  }

  search(event) {
    this.params.key = event.key;
    this.params.value = event.value;
    this.paging.filter = this.params;
    this.loadData();
  }

  reset(event) {
    this.params.key = null;
    this.params.value = null;
    this.paging.filter = this.params;
    this.loadData();
  }

  loadData() {
    this.loading = true;
    this.http.post(GetSettingsUrl, this.paging).subscribe(
      (res: any) => {
        if (!res.success) {
          this.total = 0;
          this.list = [];
          this.notification.create(
            'error',
            '角色列表数据加载失败',
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
    console.log(event); // PagingOptions
    if (event.type === 'pi' || event.type === 'ps' || event.type === 'sort') {
      this.pageUtil(event);
      this.loadData();
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
