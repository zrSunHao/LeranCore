import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { NzNotificationService } from 'ng-zorro-antd';
import { _HttpClient, ModalHelper } from '@delon/theme';
import { PermissionAddComponent } from '../permission-add/permission-add.component';
import { PagingOptions } from '@shared/model/query-params.model';

const GetPermissionUrl = 'Permission/GetPermission';
const ActivePermissionUrl = 'Permission/ActivePermission';
const DeletePermissionUrl = 'Permission/DeletePermission';

@Component({
  selector: 'app-permission-operation',
  templateUrl: './permission-operation.component.html',
  styles: [],
})
export class PermissionOperationComponent implements OnInit {
  initLoading = false; // bug
  loadingMore = false;
  item: any;
  alertMsgShow = false;
  alertMsgTitle = '';
  alertMsgContent = '';

  list = [];
  total = 0;
  paging = new PagingOptions(null, 0, 5);

  constructor(
    private http: _HttpClient,
    private modal: ModalHelper,
    private notification: NzNotificationService,
  ) {}

  ngOnInit() {}

  public loadData(item: any) {
    this.item = item;
    this.initLoading = true;
    this.paging.filter = item.id;

    this.alertMsgShow = true;
    this.alertMsgTitle = `【${item.name}】`;
    this.alertMsgContent = `注：列表显示内容为[${item.name}]下的操作权限`;

    this.http.post(GetPermissionUrl, this.paging).subscribe(
      (res: any) => {
        if (!res.success) {
          this.notification.create(
            'error',
            '权限列表数据加载失败',
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
        this.initLoading = false;
      },
      (err: any) => {
        this.initLoading = false;
      },
    );
  }

  onLoadMore(): void {
    this.loadingMore = true;
  }

  edit(item: any): void {
    const isEdit = true;
    const title = '添加操作权限';
    const entity = {
      id: item.id,
      name: item.name,
      code: item.code,
      icon: item.icon,
      tagColor: item.tagColor,
      intro: item.intro,
      parentId: item.parentId,
    };

    this.modal
      .createStatic(PermissionAddComponent, { entity, isEdit, title })
      .subscribe(res => {
        this.loadData(this.item);
        console.log(res);
      });
  }

  active(item: any) {
    const active = item.active;
    let msg = '';
    if (active) {
      msg = '关闭';
    } else {
      msg = '开启';
    }
    this.initLoading = true;

    this.http
      .post(ActivePermissionUrl, { id: item.id, active: !active })
      .subscribe(
        (res: any) => {
          this.initLoading = false;
          if (!res.success) {
            item.active = active;
            this.notification.create('error', msg + '失败', res.allMessages);
          } else {
            this.notification.create('success', msg + '成功', res.allMessages);
            this.loadData(this.item);
          }
        },
        (err: any) => {
          this.initLoading = false;
        },
      );
  }

  delete(item: any): void {
    this.initLoading = true;
    this.http.get(DeletePermissionUrl, { id: item.id }).subscribe(
      (res: any) => {
        this.initLoading = false;
        if (!res.success) {
          this.notification.create('error', '删除失败', res.allMessages);
        } else {
          this.notification.create('success', '删除成功', res.allMessages);
          this.loadData(this.item);
        }
      },
      (err: any) => {
        this.initLoading = false;
      },
    );
  }

  pageIndexChange(event) {
    this.paging.pageIndex = event;
    this.loadData(this.item);
  }

  pageSizeChange(event) {
    this.paging.pageSize = event;
    this.loadData(this.item);
  }
}
